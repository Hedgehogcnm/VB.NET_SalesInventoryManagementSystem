Imports MySql.Data.MySqlClient
Imports System.IO

Public Class EditProductForm
    Public Property ProductID As Integer
    Private ProductImagePath As String = "" ' store selected image path

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
                        ' Show Product ID and Supplier ID
                        ProductIDLabel.Text = reader("p_id").ToString()
                        SupplierIDLabel.Text = reader("sup_id").ToString()

                        ' Load editable fields
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
                            ' fallback image
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
            MessageBox.Show("❌ Failed to load product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' === Change Image Button ===
    Private Sub ChangeImageButton_Click(sender As Object, e As EventArgs) Handles ChangeImageButton.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        ofd.Title = "Select Product Image"

        If ofd.ShowDialog() = DialogResult.OK Then
            ProductImagePath = ofd.FileName
            ' Load a copy to prevent file lock
            Using imgTemp As Image = Image.FromFile(ProductImagePath)
                ProductPictureBox.Image = New Bitmap(imgTemp)
            End Using
        End If
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
                    ' new image selected → convert to bytes safely
                    Dim imgBytes() As Byte = File.ReadAllBytes(ProductImagePath)
                    cmd.Parameters.Add("@img", MySqlDbType.Blob).Value = imgBytes
                ElseIf ProductPictureBox.Image IsNot Nothing Then
                    ' save existing image safely by creating a copy
                    Using copyImg As New Bitmap(ProductPictureBox.Image)
                        Using ms As New MemoryStream()
                            copyImg.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                            cmd.Parameters.Add("@img", MySqlDbType.Blob).Value = ms.ToArray()
                        End Using
                    End Using
                Else
                    ' no image → set NULL
                    cmd.Parameters.AddWithValue("@img", DBNull.Value)
                End If

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
