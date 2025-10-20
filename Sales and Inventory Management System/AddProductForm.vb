Imports DocumentFormat.OpenXml.Office2010.Excel
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

        ' --- Validate Supplier ID (from ComboBox) ---
        If SupplierIDComboBox.SelectedIndex = -1 Then
            MessageBox.Show("Please select a Supplier ID.")
            Exit Sub
        End If
        Dim SupplierID As Integer = CInt(SupplierIDComboBox.SelectedValue)

        ' --- Other inputs ---
        Dim ProductName As String = ProductNameTextBox.Text.Trim()
        Dim ProductCategory As String = If(ProductCategoryComboBox.SelectedItem, "").ToString()

        If String.IsNullOrEmpty(ProductName) OrElse String.IsNullOrEmpty(ProductCategory) Then
            MessageBox.Show("Please enter Product Name and select a Category.")
            Exit Sub
        End If


        Dim ProductMinStock As Integer
        If Not Integer.TryParse(ProductMinStockTextBox.Text, ProductMinStock) Then
            MessageBox.Show("Please enter a valid number for Product Minimum Stock.")
            Exit Sub
        End If

        Dim ProductCostPrice As Double
        If Not Double.TryParse(ProductCostPriceTextBox.Text, ProductCostPrice) Then
            MessageBox.Show("Please enter a valid cost price.")
            Exit Sub
        End If

        Dim ProductSellPrice As Double
        If Not Double.TryParse(ProductSellPriceTextBox.Text, ProductSellPrice) Then
            MessageBox.Show("Please enter a valid sell price.")
            Exit Sub
        End If

        Try
            ConnectDB()

            ' --- Insert into database ---
            Dim sql As String = "INSERT INTO tb_products (p_id, sup_id, p_name, p_category, p_minStock, p_costPrice, p_sellPrice) " &
                                "VALUES (@ProductID, @SupplierID, @ProductName, @ProductCategory, @ProductMinStock, @ProductCostPrice, @ProductSellPrice)"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@ProductID", ProductID)
                cmd.Parameters.AddWithValue("@SupplierID", SupplierID)
                cmd.Parameters.AddWithValue("@ProductName", ProductName)
                cmd.Parameters.AddWithValue("@ProductCategory", ProductCategory)
                cmd.Parameters.AddWithValue("@ProductMinStock", ProductMinStock)
                cmd.Parameters.AddWithValue("@ProductCostPrice", ProductCostPrice)
                cmd.Parameters.AddWithValue("@ProductSellPrice", ProductSellPrice)

                cmd.ExecuteNonQuery()
            End Using

            isSaved = True
            MessageBox.Show("✅ Product added successfully!")
            Me.DialogResult = DialogResult.OK
            Me.Close()
            InventoryForm.Show()

        Catch ex As Exception
            MessageBox.Show("❌ Error adding product: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' --- Load Supplier IDs into ComboBox ---
    Private Sub LoadSupplierComboBox()
        Try
            ConnectDB()

            Dim sql As String = "SELECT sup_id FROM tb_suppliers ORDER BY sup_id ASC"
            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            da.Fill(dt)

            SupplierIDComboBox.DataSource = dt
            SupplierIDComboBox.DisplayMember = "sup_id"
            SupplierIDComboBox.ValueMember = "sup_id"
            SupplierIDComboBox.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("❌ Failed to load supplier IDs: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub AddProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSupplierComboBox() ' 👈 Load supplier list when form opens
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        InventoryForm.Show()
        Me.Close()
    End Sub
End Class
