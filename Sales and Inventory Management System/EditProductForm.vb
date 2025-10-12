Imports MySql.Data.MySqlClient

Public Class EditProductForm
    ' --- Public properties (receive from InventoryForm) ---
    Public Property ProductID As Integer
    Public Property SupplierID As Integer
    Public Property ProductName As String
    Public Property ProductCategory As String
    Public Property ProductStock As Integer
    Public Property ProductMinStock As Integer
    Public Property ProductCostPrice As Decimal
    Public Property ProductSellPrice As Decimal

    ' --- When form loads, show product info ---
    Private Sub EditProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Show read-only IDs as labels
        ProductIDLabel.Text = ProductID.ToString()
        SupplierIDLabel.Text = SupplierID.ToString()

        ' Fill textboxes with editable values
        EditProductNameTextBox.Text = ProductName
        ProductCategoryComboBox.SelectedItem = ProductCategory
        EditProductStockTextBox.Text = ProductStock.ToString()
        EditProductMinStockTextBox.Text = ProductMinStock.ToString()
        EditProductCostPriceTextBox.Text = ProductCostPrice.ToString("F2")
        EditProductSellPriceTextBox.Text = ProductSellPrice.ToString("F2")
    End Sub

    ' --- Save Button Click: Update product info ---
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Try
            ConnectDB()

            Dim sql As String = "UPDATE tb_products SET 
                                p_name=@name, 
                                p_category=@category, 
                                p_stock=@stock, 
                                p_minStock=@minStock, 
                                p_costPrice=@costPrice, 
                                p_sellPrice=@sellPrice
                             WHERE p_id=@id"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@name", EditProductNameTextBox.Text)
                cmd.Parameters.AddWithValue("@category", ProductCategoryComboBox.SelectedItem)
                cmd.Parameters.AddWithValue("@stock", EditProductStockTextBox.Text)
                cmd.Parameters.AddWithValue("@minStock", EditProductMinStockTextBox.Text)
                cmd.Parameters.AddWithValue("@costPrice", EditProductCostPriceTextBox.Text)
                cmd.Parameters.AddWithValue("@sellPrice", EditProductSellPriceTextBox.Text)
                cmd.Parameters.AddWithValue("@id", ProductID)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("✅ Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.OK  ' <-- Important line
                    Me.Close()
                Else
                    MessageBox.Show("⚠️ No changes were made.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("❌ Error updating product: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' --- Cancel Button (optional): close the form ---
    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.Close()
    End Sub
End Class
