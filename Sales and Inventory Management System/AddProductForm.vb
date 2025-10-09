Imports MySql.Data.MySqlClient

Public Class AddProductForm

    Private isSaved As Boolean = False

    Private Sub AddProductButton_Click(sender As Object, e As EventArgs) Handles AddProductButton.Click
        ' --- Validate Product ID ---
        Dim ProductID As Integer
        If Not Integer.TryParse(ProductIDTextBox.Text, ProductID) Then
            MessageBox.Show("Please enter a valid Product ID.")
            Exit Sub
        End If

        ' --- Validate Supplier ID ---
        Dim SupplierID As Integer
        If Not Integer.TryParse(SupplierIDTextBox.Text, SupplierID) Then
            MessageBox.Show("Please enter a valid Supplier ID.")
            Exit Sub
        End If

        ' --- Validate Product Name ---
        Dim ProductName As String = ProductNameTextBox.Text.Trim()
        If String.IsNullOrWhiteSpace(ProductName) Then
            MessageBox.Show("Please enter a Product Name.")
            Exit Sub
        End If

        ' --- Validate Category ---
        Dim ProductCategory As String = ""
        If ProductCategoryComboBox.SelectedItem IsNot Nothing Then
            ProductCategory = ProductCategoryComboBox.SelectedItem.ToString()
        Else
            MessageBox.Show("Please select a Product Category.")
            Exit Sub
        End If

        ' --- Validate Stock ---
        Dim ProductStock As Integer
        If Not Integer.TryParse(ProductStockTextBox.Text, ProductStock) Then
            MessageBox.Show("Please enter a valid number for Product Stock.")
            Exit Sub
        End If

        ' --- Validate Minimum Stock ---
        Dim ProductMinStock As Integer
        If Not Integer.TryParse(ProductMinStockTextBox.Text, ProductMinStock) Then
            MessageBox.Show("Please enter a valid number for Product Minimum Stock.")
            Exit Sub
        End If

        ' --- Validate Cost Price ---
        Dim ProductCostPrice As Double
        If Not Double.TryParse(ProductCostPriceTextBox.Text, ProductCostPrice) Then
            MessageBox.Show("Please enter a valid cost price.")
            Exit Sub
        End If

        ' --- Validate Sell Price ---
        Dim ProductSellPrice As Double
        If Not Double.TryParse(ProductSellPriceTextBox.Text, ProductSellPrice) Then
            MessageBox.Show("Please enter a valid sell price.")
            Exit Sub
        End If

        ' --- Insert into Database ---
        Try
            ConnectDB()

            ' ⚠ Check your table column name: is it "p_caterogy" or "p_category"?
            ' Below uses the corrected version "p_category".
            Dim sql As String = "INSERT INTO tb_products (p_id, sup_id, p_name, p_category, p_stock, p_minStock, p_costPrice, p_sellPrice) " &
                                "VALUES (@ProductID, @SupplierID, @ProductName, @ProductCategory, @ProductStock, @ProductMinStock, @ProductCostPrice, @ProductSellPrice)"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@ProductID", ProductID)
                cmd.Parameters.AddWithValue("@SupplierID", SupplierID)
                cmd.Parameters.AddWithValue("@ProductName", ProductName)
                cmd.Parameters.AddWithValue("@ProductCategory", ProductCategory)
                cmd.Parameters.AddWithValue("@ProductStock", ProductStock)
                cmd.Parameters.AddWithValue("@ProductMinStock", ProductMinStock)
                cmd.Parameters.AddWithValue("@ProductCostPrice", ProductCostPrice)
                cmd.Parameters.AddWithValue("@ProductSellPrice", ProductSellPrice)
                cmd.ExecuteNonQuery()
            End Using

            isSaved = True
            MessageBox.Show("✅ Product added successfully!")
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("❌ Error adding product: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
End Class
