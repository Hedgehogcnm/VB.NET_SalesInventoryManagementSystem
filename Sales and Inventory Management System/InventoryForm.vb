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

        ' Make the whole row selected when a cell is clicked
        With ProductListDataGridView
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
        End With
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

        For Each row As DataGridViewRow In ProductListDataGridView.Rows
            If Not row.IsNewRow Then
                Dim stock As Integer = Convert.ToInt32(row.Cells("p_stock").Value)
                Dim minStock As Integer = Convert.ToInt32(row.Cells("p_minStock").Value)

                If stock <= minStock Then
                    row.DefaultCellStyle.ForeColor = Color.Red
                Else
                    row.DefaultCellStyle.ForeColor = Color.Black ' normal color
                End If
            End If
        Next
    End Sub

    Private Sub SearchProductButton_Click(sender As Object, e As EventArgs) Handles SearchProductButton.Click
        Dim searchValue As String = ProductSearchTextBox.Text.Trim()

        ' --- Validate input ---
        If String.IsNullOrEmpty(searchValue) Then
            MessageBox.Show("Please enter a Product ID or Product Name to search.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim found As Boolean = False

        ' --- Loop through DataGridView rows to find match ---
        For Each row As DataGridViewRow In ProductListDataGridView.Rows
            If Not row.IsNewRow Then
                Dim productID As String = row.Cells("p_id").Value.ToString()
                Dim productName As String = row.Cells("p_name").Value.ToString()

                ' Compare case-insensitively
                If productID.Equals(searchValue, StringComparison.OrdinalIgnoreCase) OrElse
               productName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0 Then

                    ' Select the found row
                    row.Selected = True
                    ProductListDataGridView.FirstDisplayedScrollingRowIndex = row.Index
                    found = True
                    Exit For
                End If
            End If
        Next

        ' --- If not found ---
        If Not found Then
            MessageBox.Show("No product found with that ID or Name.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub AddProductButton_Click(sender As Object, e As EventArgs) Handles AddProductButton.Click
        ' Open Add Product form as a dialog
        Dim addForm As New AddProductForm()

        ' Show the form and check if product was saved
        If addForm.ShowDialog() = DialogResult.OK Then
            ' Refresh product list automatically
            LoadProduct()
        End If
    End Sub

    Private Sub EditProductButton_Click(sender As Object, e As EventArgs) Handles EditProductButton.Click
        If ProductListDataGridView.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a product to edit.")
            Return
        End If

        Dim row As DataGridViewRow = ProductListDataGridView.SelectedRows(0)
        Dim editForm As New EditProductForm()

        editForm.ProductID = Convert.ToInt32(row.Cells("p_id").Value)
        editForm.SupplierID = Convert.ToInt32(row.Cells("sup_id").Value)
        editForm.ProductName = row.Cells("p_name").Value.ToString()
        editForm.ProductCategory = row.Cells("p_category").Value.ToString()
        editForm.ProductStock = Convert.ToInt32(row.Cells("p_stock").Value)
        editForm.ProductMinStock = Convert.ToInt32(row.Cells("p_minStock").Value)
        editForm.ProductCostPrice = Convert.ToDecimal(row.Cells("p_costPrice").Value)
        editForm.ProductSellPrice = Convert.ToDecimal(row.Cells("p_sellPrice").Value)

        ' Show as dialog, refresh if saved
        If editForm.ShowDialog() = DialogResult.OK Then
            LoadProduct()
        End If
    End Sub


    Private Sub DeleteProductButton_Click(sender As Object, e As EventArgs) Handles DeleteProductButton.Click
        ' Check if a row is selected
        If ProductListDataGridView.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a product to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get Product ID from selected row
        Dim ProductID As Integer = Convert.ToInt32(ProductListDataGridView.SelectedRows(0).Cells("p_id").Value)

        ' Confirm deletion
        Dim confirm As DialogResult = MessageBox.Show(
            "Are you sure you want to delete this product?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If confirm = DialogResult.No Then Return

        Try
            ConnectDB()

            ' --- Step 1: Check if product has related inventory movements ---
            Dim checkSql As String = "SELECT COUNT(*) FROM tb_inventorymovements WHERE p_id = @ProductID"
            Using checkCmd As New MySqlCommand(checkSql, conn)
                checkCmd.Parameters.AddWithValue("@ProductID", ProductID)
                Dim relatedCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                If relatedCount > 0 Then
                    MessageBox.Show(
                        "❌ This product cannot be deleted because it is linked to inventory movement records." & vbCrLf &
                        "Please remove related inventory records first.",
                        "Delete Blocked",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    )
                    Return
                End If
            End Using

            ' --- Step 2: Proceed with product deletion if safe ---
            Dim deleteSql As String = "DELETE FROM tb_products WHERE p_id = @ProductID"
            Using deleteCmd As New MySqlCommand(deleteSql, conn)
                deleteCmd.Parameters.AddWithValue("@ProductID", ProductID)
                Dim rowsAffected As Integer = deleteCmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("✅ Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadProduct() ' Refresh DataGridView
                Else
                    MessageBox.Show("⚠️ No product found with that ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("❌ Error deleting product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub


End Class