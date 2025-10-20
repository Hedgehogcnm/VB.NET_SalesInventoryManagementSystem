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

            ' --- Custom header names ---
            OrderDataGridView.Columns("o_id").HeaderText = "Order ID"
            OrderDataGridView.Columns("p_id").HeaderText = "Product ID"
            OrderDataGridView.Columns("u_id").HeaderText = "User ID"
            OrderDataGridView.Columns("sup_id").HeaderText = "Supplier ID"
            OrderDataGridView.Columns("o_qty").HeaderText = "Order Quantity"
            OrderDataGridView.Columns("o_total").HeaderText = "Order Total"

            ' --- Always use the same ComboBox options ---
            Dim statusCombo As New DataGridViewComboBoxColumn()
            statusCombo.HeaderText = "Order Status"
            statusCombo.Name = "o_status"
            statusCombo.DataPropertyName = "o_status"
            statusCombo.Items.AddRange(" ", "Ordered", "Received", "Cancelled")
            statusCombo.DefaultCellStyle.NullValue = " "

            ' --- Replace the old o_status column safely ---
            If OrderDataGridView.Columns.Contains("o_status") Then
                OrderDataGridView.Columns.Remove("o_status")
            End If
            OrderDataGridView.Columns.Add(statusCombo)

            ' --- Normalize database values to match ComboBox options ---
            For Each row As DataGridViewRow In OrderDataGridView.Rows
                If row.Cells("o_status").Value IsNot Nothing Then
                    Dim val As String = row.Cells("o_status").Value.ToString().Trim()
                    Select Case val.ToLower()
                        Case "", " ", "null"
                            row.Cells("o_status").Value = " "
                        Case "ordered"
                            row.Cells("o_status").Value = "Ordered"
                        Case "received"
                            row.Cells("o_status").Value = "Received"
                        Case "cancelled"
                            row.Cells("o_status").Value = "Cancelled"
                        Case Else
                            row.Cells("o_status").Value = " "
                    End Select
                Else
                    row.Cells("o_status").Value = " "
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("❌ Failed to load orders: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub


    ' --- Prevent ComboBox crash ---
    Private Sub OrderDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        e.Cancel = True
    End Sub

    ' --- ConfirmButton click handler ---
    Private Sub ConfirmButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click
        If OrderDataGridView.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an order to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim selectedRow As DataGridViewRow = OrderDataGridView.SelectedRows(0)
        Dim orderID As Integer = Convert.ToInt32(selectedRow.Cells("o_id").Value)
        Dim productID As Integer = Convert.ToInt32(selectedRow.Cells("p_id").Value)
        Dim newStatus As String = selectedRow.Cells("o_status").Value.ToString()

        ' --- Retrieve product name ---
        Dim productName As String = ""
        Try
            ConnectDB()
            Dim sqlProduct As String = "SELECT p_name FROM tb_products WHERE p_id = @p_id"
            Using cmd As New MySqlCommand(sqlProduct, conn)
                cmd.Parameters.AddWithValue("@p_id", productID)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    productName = result.ToString()
                Else
                    productName = "Unknown Product"
                End If
            End Using
        Catch
            productName = "Unknown Product"
        Finally
            conn.Close()
        End Try

        ' --- Confirmation message ---
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

                MessageBox.Show($"✅ Order status updated successfully for '{productName}' (Product ID: {productID}).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' 🔄 Automatically refresh the grid after update
                LoadOrders()

            Catch ex As Exception
                MessageBox.Show("❌ Failed to update order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conn.Close()
            End Try
        End If
    End Sub

End Class
