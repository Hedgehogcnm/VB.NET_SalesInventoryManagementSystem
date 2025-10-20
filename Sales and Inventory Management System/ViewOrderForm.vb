Imports MySql.Data.MySqlClient

Public Class ViewOrderForm
    Private Sub ViewOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOrders()
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
                .ReadOnly = False ' Allow editing for combo box
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

            ' --- Replace o_status column with ComboBox column ---
            Dim statusCombo As New DataGridViewComboBoxColumn()
            statusCombo.HeaderText = "Order Status"
            statusCombo.Name = "o_status"
            statusCombo.DataPropertyName = "o_status" ' Bind to data source field
            statusCombo.Items.AddRange("Ordered", "Received", "Cancelled")

            ' Remove the existing text column for o_status
            OrderDataGridView.Columns.Remove("o_status")
            ' Add the ComboBox column
            OrderDataGridView.Columns.Add(statusCombo)

        Catch ex As Exception
            MessageBox.Show("❌ Failed to load orders: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub
End Class
