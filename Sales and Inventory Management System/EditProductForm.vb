Imports System.IO
Imports DocumentFormat.OpenXml.InkML
Imports DocumentFormat.OpenXml.Vml.Spreadsheet
Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class EditProductForm
    Public Property ProductID As Integer
    Private ProductImagePath As String = "" ' store selected image path

    Private Sub EditProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' === Background ===
        Me.BackColor = Color.FromArgb(255, 247, 238)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = New Font("Segoe UI", 10)
        Me.Text = "Edit Product"

        ' === Title ===
        TitleLabel.ForeColor = Color.FromArgb(120, 80, 40)
        TitleLabel.TextAlign = ContentAlignment.MiddleCenter
        TitleLabel.Dock = DockStyle.None

        ' === Label Style ===
        For Each lbl As Label In {ProductIDText, SupplierIDText, ProductNameText, CategoryText, StockText, MinStockText, CostText, SellText, ImageText}
            lbl.Font = New Font("Segoe UI Semibold", 10)
            lbl.ForeColor = Color.FromArgb(100, 70, 50)
            lbl.TextAlign = ContentAlignment.MiddleRight
        Next

        ' === TextBox Style ===
        For Each txt As TextBox In {EditProductNameTextBox, EditProductStockTextBox, EditProductMinStockTextBox, EditProductCostPriceTextBox, EditProductSellPriceTextBox}
            txt.BorderStyle = BorderStyle.FixedSingle
            txt.BackColor = Color.FromArgb(255, 245, 230)
            txt.ForeColor = Color.FromArgb(50, 50, 50)
        Next

        ' === ComboBox Style ===
        ProductCategoryComboBox.FlatStyle = FlatStyle.Flat
        ProductCategoryComboBox.BackColor = Color.FromArgb(255, 245, 230)
        ProductCategoryComboBox.ForeColor = Color.FromArgb(50, 50, 50)

        ' === PictureBox ===
        ProductPictureBox.BorderStyle = BorderStyle.FixedSingle
        ProductPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        ProductPictureBox.BackColor = Color.White

        ' === Change Image Button ===
        ChangeImageButton.FlatStyle = FlatStyle.Flat
        ChangeImageButton.FlatAppearance.BorderSize = 0
        ChangeImageButton.BackColor = Color.FromArgb(255, 235, 215)
        ChangeImageButton.ForeColor = Color.FromArgb(120, 80, 40)
        ChangeImageButton.Font = New Font("Segoe UI Semibold", 9)
        ChangeImageButton.Cursor = Cursors.Hand
        AddHandler ChangeImageButton.MouseEnter, Sub() ChangeImageButton.BackColor = Color.FromArgb(255, 225, 200)
        AddHandler ChangeImageButton.MouseLeave, Sub() ChangeImageButton.BackColor = Color.FromArgb(255, 235, 215)

        ' === Save Button ===
        SaveButton.FlatStyle = FlatStyle.Flat
        SaveButton.FlatAppearance.BorderSize = 0
        SaveButton.BackColor = Color.FromArgb(255, 235, 215)
        SaveButton.ForeColor = Color.FromArgb(120, 80, 40)
        SaveButton.Font = New Font("Segoe UI Semibold", 9)
        SaveButton.Cursor = Cursors.Hand
        AddHandler SaveButton.MouseEnter, Sub() SaveButton.BackColor = Color.FromArgb(255, 225, 200)
        AddHandler SaveButton.MouseLeave, Sub() SaveButton.BackColor = Color.FromArgb(255, 235, 215)

        ' === Cancel Button ===
        CancelButton.FlatStyle = FlatStyle.Flat
        CancelButton.FlatAppearance.BorderSize = 0
        CancelButton.BackColor = Color.FromArgb(255, 235, 215)
        CancelButton.ForeColor = Color.FromArgb(120, 80, 40)
        CancelButton.Font = New Font("Segoe UI Semibold", 9)
        CancelButton.Cursor = Cursors.Hand
        AddHandler CancelButton.MouseEnter, Sub() CancelButton.BackColor = Color.FromArgb(255, 225, 200)
        AddHandler CancelButton.MouseLeave, Sub() CancelButton.BackColor = Color.FromArgb(255, 235, 215)

        ' === Load Product Data ===
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
                        ProductIDLabel.Text = reader("p_id").ToString()
                        SupplierIDLabel.Text = reader("sup_id").ToString()
                        EditProductNameTextBox.Text = reader("p_name").ToString()
                        ProductCategoryComboBox.Text = reader("p_category").ToString()
                        EditProductStockTextBox.Text = reader("p_stock").ToString()
                        EditProductMinStockTextBox.Text = reader("p_minStock").ToString()
                        EditProductCostPriceTextBox.Text = reader("p_costPrice").ToString()
                        EditProductSellPriceTextBox.Text = reader("p_sellPrice").ToString()

                        ' Load Image
                        If Not IsDBNull(reader("p_image")) Then
                            Dim imgBytes() As Byte = CType(reader("p_image"), Byte())
                            Using ms As New MemoryStream(imgBytes)
                                ProductPictureBox.Image = Image.FromStream(ms)
                            End Using
                        Else
                            Dim fallbackPath As String = IO.Path.Combine(Application.StartupPath, "replace.png")
                            If IO.File.Exists(fallbackPath) Then
                                ProductPictureBox.Image = Image.FromFile(fallbackPath)
                            Else
                                ProductPictureBox.BackColor = Color.LightGray
                            End If
                        End If
                    Else
                        MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Close()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' === Change Image ===
    Private Sub ChangeImageButton_Click(sender As Object, e As EventArgs) Handles ChangeImageButton.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
            .Title = "Select Product Image"
        }

        If ofd.ShowDialog() = DialogResult.OK Then
            ProductImagePath = ofd.FileName
            Using imgTemp As Image = Image.FromFile(ProductImagePath)
                ProductPictureBox.Image = New Bitmap(imgTemp)
            End Using
        End If
    End Sub

    ' === Save Button ===
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
                    sup_id=@sup, 
                    p_image=@img
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

                ' === Handle Image Save ===
                If ProductImagePath <> "" Then
                    Dim imgBytes() As Byte = File.ReadAllBytes(ProductImagePath)
                    cmd.Parameters.Add("@img", MySqlDbType.Blob).Value = imgBytes
                ElseIf ProductPictureBox.Image IsNot Nothing Then
                    Using copyImg As New Bitmap(ProductPictureBox.Image)
                        Using ms As New MemoryStream()
                            copyImg.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                            cmd.Parameters.Add("@img", MySqlDbType.Blob).Value = ms.ToArray()
                        End Using
                    End Using
                Else
                    cmd.Parameters.AddWithValue("@img", DBNull.Value)
                End If

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Failed to update product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
