Imports MySql.Data.MySqlClient

Public Class ViewOrderForm

    Private Sub ViewOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOrders()
        AddHandler OrderDataGridView.DataError, AddressOf OrderDataGridView_DataError
    End Sub

    ' --- Load order data into DataGridView ---
    Private Sub LoadOrders()
        Try
            ConnectDB()

            Dim sql As String = "SELECT o_id, p_id, u_id, sup_id, o_qty, o_total, o_status FROM tb_orders"
            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            da.Fill(dt)

            OrderDataGridView.DataSource = dt

            ' --- DataGridView formatting ---
            With OrderDataGridView
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .ReadOnly = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = False
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .EnableHeadersVisualStyles = False
            End With

            ' --- Rename headers ---
            OrderDataGridView.Columns("o_id").HeaderText = "Order ID"
            OrderDataGridView.Columns("p_id").HeaderText = "Product ID"
            OrderDataGridView.Columns("u_id").HeaderText = "User ID"
            OrderDataGridView.Columns("sup_id").HeaderText = "Supplier ID"
            OrderDataGridView.Columns("o_qty").HeaderText = "Order Quantity"
            OrderDataGridView.Columns("o_total").HeaderText = "Order Total"
            OrderDataGridView.Columns("o_status").HeaderText = "Order Status"

            ' --- Replace o_status column with ComboBox version ---
            Dim comboColumn As New DataGridViewComboBoxColumn()
            comboColumn.HeaderText = "Order Status"
            comboColumn.Name = "o_status"
            comboColumn.DataPropertyName = "o_status"
            comboColumn.FlatStyle = FlatStyle.Flat
            comboColumn.Items.AddRange("ordered", "received", "cancelled")

            Dim oldCol As DataGridViewColumn = OrderDataGridView.Columns("o_status")
            Dim colIndex As Integer = oldCol.Index
            OrderDataGridView.Columns.Remove(oldCol)
            OrderDataGridView.Columns.Insert(colIndex, comboColumn)

            ' --- Normalize all rows ---
            For Each row As DataGridViewRow In OrderDataGridView.Rows
                Dim val As Object = row.Cells("o_status").Value
                If val Is Nothing OrElse String.IsNullOrWhiteSpace(val.ToString()) Then
                    row.Cells("o_status").Value = "ordered"
                End If
            Next

            ' ✅ Clear any selected row after binding
            OrderDataGridView.ClearSelection()

        Catch ex As Exception
            MessageBox.Show("❌ Failed to load orders: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' --- Prevent DataError crash ---
    Private Sub OrderDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        e.ThrowException = False
        e.Cancel = True
    End Sub

    ' --- Confirm Button ---
    Private Sub ConfirmButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click
        If OrderDataGridView.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an order to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim selectedRow As DataGridViewRow = OrderDataGridView.SelectedRows(0)
        Dim orderID As Integer = Convert.ToInt32(selectedRow.Cells("o_id").Value)
        Dim productID As Integer = Convert.ToInt32(selectedRow.Cells("p_id").Value)
        Dim quantity As Integer = Convert.ToInt32(selectedRow.Cells("o_qty").Value)
        Dim newStatus As String = selectedRow.Cells("o_status").Value.ToString()

        ' --- Get product name for display ---
        Dim productName As String = ""
        Try
            ConnectDB()
            Dim sqlProduct As String = "SELECT p_name FROM tb_products WHERE p_id = @p_id"
            Using cmd As New MySqlCommand(sqlProduct, conn)
                cmd.Parameters.AddWithValue("@p_id", productID)
                Dim result = cmd.ExecuteScalar()
                productName = If(result IsNot Nothing, result.ToString(), "Unknown Product")
            End Using
        Catch
            productName = "Unknown Product"
        Finally
            conn.Close()
        End Try

        ' --- Confirm update ---
        Dim confirmMsg As String = $"Confirm change status for '{productName}' (Product ID: {productID}) to '{newStatus}'?"
        Dim response As DialogResult = MessageBox.Show(confirmMsg, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If response = DialogResult.Yes Then
            Try
                ConnectDB()
                Dim sqlUpdate As String = "UPDATE tb_orders SET o_status = @status WHERE o_id = @orderID"
                Using cmd As New MySqlCommand(sqlUpdate, conn)
                    cmd.Parameters.AddWithValue("@status", newStatus)
                    cmd.Parameters.AddWithValue("@orderID", orderID)
                    cmd.ExecuteNonQuery()
                End Using
                conn.Close()

                ' ✅ If status changed to "received", increase product stock

                MessageBox.Show($"✅ Order status updated successfully for '{productName}' (Product ID: {productID}).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' ✅ Refresh orders grid
                LoadOrders()

                ' ✅ If InventoryForm is open, refresh its product list automatically
                For Each f As Form In Application.OpenForms
                    If TypeOf f Is InventoryForm Then
                        Dim invForm As InventoryForm = CType(f, InventoryForm)
                        invForm.RefreshProductListFromOtherForm()
                    End If
                Next

            Catch ex As Exception
                MessageBox.Show("❌ Failed to update order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.Close()
    End Sub
End Class
