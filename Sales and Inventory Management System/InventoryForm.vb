Imports MySql.Data.MySqlClient
Public Class InventoryForm
    Private Sub SalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem.Click
        Dim Sales As New SalesForm()
        Sales.Show()
        Me.Close()
    End Sub

    Private Sub InventoryToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles InventoryToolStripMenuItem.Click
        Dim Inventory As New InventoryForm()
        Inventory.Show()
        Me.Close()
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem.Click
        Dim Supplier As New SupplierForm()
        Supplier.Show()
        Me.Close()
    End Sub

    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click
        Dim Report As New ReportForm()
        Report.Show()
        Me.Close()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Dim login As New LoginForm()
        login.Show()
        Me.Close()
    End Sub

    Private Sub InventoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProduct()
    End Sub

    Private Sub LoadProduct()
        Try
            ConnectDB()

            Dim sql As String = "SELECT p_id, sup_id, p_name, p_category, p_stock, p_minStock, p_costPrice, p_sellPrice FROM tb_products"

            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            da.Fill(dt)

            ProductListDataGridView.DataSource = dt

            ' Adjust DataGridView style
            ProductListDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            ProductListDataGridView.EnableHeadersVisualStyles = False
            'ProductListDataGridView.ColumnHeadersDefaultCellStyle.Font = New Font(ProductListDataGridView.Font, FontStyle.Bold)
            'ProductListDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'ProductListDataGridView.Columns("p_id").Width = 60
            'ProductListDataGridView.Columns("sup_id").Width = 170
            'ProductListDataGridView.Columns("p_name").Width = 80
            'ProductListDataGridView.Columns("p_stock").Width = 60
            'ProductListDataGridView.Columns("p_minStock").Width = 60
            'ProductListDataGridView.Columns("p_costPrice").Width = 60
            'ProductListDataGridView.Columns("p_sellPrice").Width = 60
            'ProductListDataGridView.Columns("p_costPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'ProductListDataGridView.Columns("p_sellPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'ProductListDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            ProductListDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = ProductListDataGridView.ColumnHeadersDefaultCellStyle.BackColor
            ProductListDataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = ProductListDataGridView.ColumnHeadersDefaultCellStyle.ForeColor
            ProductListDataGridView.MultiSelect = True
            ProductListDataGridView.ReadOnly = True
            ProductListDataGridView.AllowUserToAddRows = False

            ' Change column header text
            ProductListDataGridView.Columns("p_id").HeaderText = "Product ID"
            ProductListDataGridView.Columns("sup_id").HeaderText = "Supplier ID"
            ProductListDataGridView.Columns("p_name").HeaderText = "Product Name"
            ProductListDataGridView.Columns("p_stock").HeaderText = "Product Stock"
            ProductListDataGridView.Columns("p_minStock").HeaderText = "Product Minimum Stock"
            ProductListDataGridView.Columns("p_costPrice").HeaderText = "Product Cost Price"
            ProductListDataGridView.Columns("p_sellPrice").HeaderText = "Product Sell Price"
        Catch ex As Exception
            MessageBox.Show("Failed to load products: " & ex.Message)
        End Try
    End Sub

    Private Sub SearchProductButton_Click(sender As Object, e As EventArgs) Handles SearchProductButton.Click

    End Sub

    Private Sub AddProductButton_Click(sender As Object, e As EventArgs) Handles AddProductButton.Click
        AddProductForm.ShowDialog()
    End Sub
End Class