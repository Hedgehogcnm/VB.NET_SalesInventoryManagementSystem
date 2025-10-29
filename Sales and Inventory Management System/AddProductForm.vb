Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing

Public Class AddProductForm

    Private isSaved As Boolean = False
    Private ProductImagePath As String = "" ' store selected image path

    Private Sub AddProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' === Background ===
        Me.BackColor = Color.FromArgb(255, 247, 238)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = New Font("Segoe UI", 10)
        Me.Text = "Add Product"

        ' === Title Label ===
        TitleLabel.ForeColor = Color.FromArgb(120, 80, 40)
        TitleLabel.Dock = DockStyle.None
        TitleLabel.TextAlign = ContentAlignment.MiddleCenter

        ' === Label Style ===
        For Each lbl As Label In {ProductIDText, SupplierIDText, ProductNameText, ProductCategoryText,
                                  ProductMinStockText, ProductCostPriceText, ProductSellPriceText, ProductImageText}
            lbl.Font = New Font("Segoe UI Semibold", 10)
            lbl.ForeColor = Color.FromArgb(100, 70, 50)
            lbl.TextAlign = ContentAlignment.MiddleRight
        Next

        ' === TextBox Style ===
        For Each txt As TextBox In {ProductIDTextBox, ProductNameTextBox, ProductMinStockTextBox,
                                    ProductCostPriceTextBox, ProductSellPriceTextBox}
            txt.BorderStyle = BorderStyle.FixedSingle
            txt.BackColor = Color.FromArgb(255, 245, 230)
            txt.ForeColor = Color.FromArgb(50, 50, 50)
        Next

        For Each cmb As ComboBox In {SupplierIDComboBox, ProductCategoryComboBox}
            cmb.FlatStyle = FlatStyle.Flat
            cmb.BackColor = Color.FromArgb(255, 245, 230)
            cmb.ForeColor = Color.FromArgb(50, 50, 50)
            cmb.IntegralHeight = False
            cmb.DropDownHeight = 100
        Next

        ' === Product Image Box ===
        ProductImagePictureBox.BorderStyle = BorderStyle.FixedSingle
        ProductImagePictureBox.SizeMode = PictureBoxSizeMode.Zoom
        ProductImagePictureBox.BackColor = Color.FromArgb(255, 245, 230)

        ' === Upload Image Button ===
        ProductImageButton.FlatStyle = FlatStyle.Flat
        ProductImageButton.FlatAppearance.BorderSize = 0
        ProductImageButton.BackColor = Color.FromArgb(255, 235, 215)
        ProductImageButton.ForeColor = Color.FromArgb(120, 80, 40)
        ProductImageButton.Font = New Font("Segoe UI Semibold", 9)
        ProductImageButton.Cursor = Cursors.Hand
        AddHandler ProductImageButton.MouseEnter, Sub() ProductImageButton.BackColor = Color.FromArgb(255, 225, 200)
        AddHandler ProductImageButton.MouseLeave, Sub() ProductImageButton.BackColor = Color.FromArgb(255, 235, 215)

        ' === Add Product Button ===
        AddProductButton.FlatStyle = FlatStyle.Flat
        AddProductButton.FlatAppearance.BorderSize = 0
        AddProductButton.BackColor = Color.FromArgb(255, 235, 215)
        AddProductButton.ForeColor = Color.FromArgb(120, 80, 40)
        AddProductButton.Font = New Font("Segoe UI Semibold", 9)
        AddProductButton.Cursor = Cursors.Hand
        AddHandler AddProductButton.MouseEnter, Sub() AddProductButton.BackColor = Color.FromArgb(255, 225, 200)
        AddHandler AddProductButton.MouseLeave, Sub() AddProductButton.BackColor = Color.FromArgb(255, 235, 215)

        ' === Cancel Button ===
        CancelButton.FlatStyle = FlatStyle.Flat
        CancelButton.FlatAppearance.BorderSize = 0
        CancelButton.BackColor = Color.FromArgb(255, 235, 215)
        CancelButton.ForeColor = Color.FromArgb(120, 80, 40)
        CancelButton.Font = New Font("Segoe UI Semibold", 9)
        CancelButton.Cursor = Cursors.Hand
        AddHandler CancelButton.MouseEnter, Sub() CancelButton.BackColor = Color.FromArgb(255, 225, 200)
        AddHandler CancelButton.MouseLeave, Sub() CancelButton.BackColor = Color.FromArgb(255, 235, 215)

        ' === Load ComboBox Data ===
        LoadSupplierComboBox()
        ProductIDTextBox.Focus()
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
            MessageBox.Show("Failed to load supplier IDs: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' === Upload Image Button ===
    Private Sub ProductImageButton_Click(sender As Object, e As EventArgs) Handles ProductImageButton.Click
        Dim ofd As New OpenFileDialog()
        ofd.Title = "Select Product Image"
        ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        If ofd.ShowDialog() = DialogResult.OK Then
            ProductImagePath = ofd.FileName
            ProductImagePictureBox.Image = Image.FromFile(ProductImagePath)
            ProductImagePictureBox.BackColor = Color.White
        End If
    End Sub

    ' === Add Product Button ===
    Private Sub AddProductButton_Click(sender As Object, e As EventArgs) Handles AddProductButton.Click
        Dim ProductID As Integer
        If Not Integer.TryParse(ProductIDTextBox.Text, ProductID) Then
            MessageBox.Show("Please enter a valid Product ID.")
            Exit Sub
        End If

        If SupplierIDComboBox.SelectedIndex = -1 Then
            MessageBox.Show("Please select a Supplier ID.")
            Exit Sub
        End If
        Dim SupplierID As Integer = CInt(SupplierIDComboBox.SelectedValue)

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
            Dim sql As String = "
                INSERT INTO tb_products 
                (p_id, sup_id, p_name, p_category, p_minStock, p_costPrice, p_sellPrice, p_image)
                VALUES 
                (@ProductID, @SupplierID, @ProductName, @ProductCategory, @ProductMinStock, @ProductCostPrice, @ProductSellPrice, @ProductImage)
            "

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@ProductID", ProductID)
                cmd.Parameters.AddWithValue("@SupplierID", SupplierID)
                cmd.Parameters.AddWithValue("@ProductName", ProductName)
                cmd.Parameters.AddWithValue("@ProductCategory", ProductCategory)
                cmd.Parameters.AddWithValue("@ProductMinStock", ProductMinStock)
                cmd.Parameters.AddWithValue("@ProductCostPrice", ProductCostPrice)
                cmd.Parameters.AddWithValue("@ProductSellPrice", ProductSellPrice)

                If ProductImagePath <> "" Then
                    Dim imgBytes() As Byte = File.ReadAllBytes(ProductImagePath)
                    cmd.Parameters.Add("@ProductImage", MySqlDbType.Blob).Value = imgBytes
                Else
                    cmd.Parameters.AddWithValue("@ProductImage", DBNull.Value)
                End If

                cmd.ExecuteNonQuery()
            End Using

            isSaved = True
            MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error adding product: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' === Cancel Button ===
    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.Close()
    End Sub

End Class
