Imports MySql.Data.MySqlClient

Public Class EditProductForm
    Public Property ProductID As Integer

    Private Sub EditProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProductDetails()
    End Sub

    ' === Load product data into fields ===
    Private Sub LoadProductDetails()
        Try
            ConnectDB()

            Dim sql As String = "SELECT * FROM tb_products WHERE p_id = @id"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@id", ProductID)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' ✅ Show Product ID and Supplier ID
                        ProductIDLabel.Text = reader("p_id").ToString()
                        SupplierIDLabel.Text = reader("sup_id").ToString()

                        ' ✅ Load all editable fields
                        EditProductNameTextBox.Text = reader("p_name").ToString()
                        ProductCategoryComboBox.Text = reader("p_category").ToString()
                        EditProductStockTextBox.Text = reader("p_stock").ToString()
                        EditProductMinStockTextBox.Text = reader("p_minStock").ToString()
                        EditProductCostPriceTextBox.Text = reader("p_costPrice").ToString()
                        EditProductSellPriceTextBox.Text = reader("p_sellPrice").ToString()

                    Else
                        MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Close()
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("❌ Failed to load product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' === Save Button Click ===
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Try
            ConnectDB()

            Dim sql As String = "
                UPDATE tb_products 
                SET 
                    p_name=@name, 
                    p_category=@category, 
                    p_stock=@stock, 
                    p_minStock=@minStock, 
                    p_costPrice=@cost, 
                    p_sellPrice=@sell, 
                    sup_id=@sup 
                WHERE p_id=@id
            "

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@name", EditProductNameTextBox.Text)
                cmd.Parameters.AddWithValue("@category", ProductCategoryComboBox.Text)
                cmd.Parameters.AddWithValue("@stock", Integer.Parse(EditProductStockTextBox.Text))
                cmd.Parameters.AddWithValue("@minStock", Integer.Parse(EditProductMinStockTextBox.Text))
                cmd.Parameters.AddWithValue("@cost", Decimal.Parse(EditProductCostPriceTextBox.Text))
                cmd.Parameters.AddWithValue("@sell", Decimal.Parse(EditProductSellPriceTextBox.Text))
                cmd.Parameters.AddWithValue("@sup", Integer.Parse(SupplierIDLabel.Text))
                cmd.Parameters.AddWithValue("@id", Integer.Parse(ProductIDLabel.Text))

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("✅ Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("❌ Failed to update product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' === Cancel Button ===
    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
