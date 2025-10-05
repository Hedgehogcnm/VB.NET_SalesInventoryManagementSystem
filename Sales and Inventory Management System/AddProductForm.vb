Imports MySql.Data.MySqlClient

Public Class AddProductForm

    Private isSaved As Boolean = True

    Private Sub AddProductButton_Click(sender As Object, e As EventArgs) Handles AddProductButton.Click
        Dim ProductName As String = ProductNameTextBox.Text
        Dim ProductCategory As String = ProductCategoryComboBox.SelectedItem
        Dim ProductStock As Integer
        If Integer.TryParse(ProductStockTextBox.Text, ProductStock) Then
            ' Conversion successful — ProductStock now holds the number
        Else
            MessageBox.Show("Please enter a valid number for Product Stock.")
        End If

        Dim ProductMinStock As Integer
        If Integer.TryParse(ProductMinStockTextBox.Text, ProductMinStock) Then
            ' Conversion successful — ProductStock now holds the number
        Else
            MessageBox.Show("Please enter a valid number for Product Minimum Stock.")
        End If

        Dim ProductCostPrice As Double
        If Double.TryParse(ProductCostPriceTextBox.Text, ProductCostPrice) Then
            ' Conversion successful — ProductCostPrice now holds the number
        Else
            MessageBox.Show("Please enter a valid cost price.")
        End If

        Dim ProductSellPrice As Double
        If Double.TryParse(ProductSellPriceTextBox.Text, ProductSellPrice) Then
            ' Conversion successful — ProductCostPrice now holds the number
        Else
            MessageBox.Show("Please enter a valid sell price.")
        End If

        Try
            ConnectDB()
            Dim sql As String = "INSERT INTO tb_products (p_id, sup_id, p_name, p_caterogy, p_stock, p_minStock, p_costPrice, p_sellPrice) VALUES (@ProductName, @ProductName, @ProductCategory, @ProductStock, @ProductMinStock, @ProductCostPrice, @ProductSellPrice)"
            Using cmd As New MySqlCommand(sql, conn)
                'cmd.Parameters.AddWithValue("@ProductID", ProductID)
                'cmd.Parameters.AddWithValue("@SID", ProductName)
                cmd.Parameters.AddWithValue("@ProductName", ProductName)
                cmd.Parameters.AddWithValue("@ProductCategory", ProductCategory)
                cmd.Parameters.AddWithValue("@ProductStock", ProductStock)
                cmd.Parameters.AddWithValue("@ProductMinStock", ProductMinStock)
                cmd.Parameters.AddWithValue("@ProductCostPrice", ProductCostPrice)
                cmd.Parameters.AddWithValue("@ProductSellPrice", ProductSellPrice)
                cmd.ExecuteNonQuery()
            End Using
            isSaved = True
            MessageBox.Show("Product added successfully!")
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error adding product: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
End Class