Imports MySql.Data.MySqlClient
Imports System.IO

Public Class InventoryForm

    Private Sub InventoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProductListFlowLayoutPanel.AutoScroll = True
        ProductListFlowLayoutPanel.WrapContents = True
        ProductListFlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight
        LoadProductCards()
    End Sub

    Private Sub InventoryForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        LoadProductCards()
    End Sub

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

    Public Sub RefreshProductListFromOtherForm()
        LoadProductCards()
    End Sub

    ' === LOAD PRODUCT CARDS ===
    Private Sub LoadProductCards(Optional searchTerm As String = "")
        Try
            ConnectDB()

            Dim sql As String =
                "SELECT p.p_id, p.sup_id, s.sup_name, p.p_name, p.p_category, p.p_stock, 
                        p.p_minStock, p.p_costPrice, p.p_sellPrice, p.p_image
                 FROM tb_products p
                 LEFT JOIN tb_suppliers s ON p.sup_id = s.sup_id"

            If searchTerm <> "" Then
                sql &= " WHERE p.p_name LIKE @search OR p.p_id LIKE @search"
            End If

            Dim cmd As New MySqlCommand(sql, conn)
            If searchTerm <> "" Then
                cmd.Parameters.AddWithValue("@search", "%" & searchTerm & "%")
            End If

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            conn.Close()

            ProductListFlowLayoutPanel.Controls.Clear()

            If dt.Rows.Count = 0 Then
                Dim noDataLbl As New Label With {
                    .Text = "No products found.",
                    .Font = New Font("Segoe UI", 11, FontStyle.Italic),
                    .ForeColor = Color.Gray,
                    .AutoSize = True,
                    .Margin = New Padding(20)
                }
                ProductListFlowLayoutPanel.Controls.Add(noDataLbl)
                Exit Sub
            End If
            ' === CREATE PRODUCT CARDS ===
            For Each row As DataRow In dt.Rows
                Dim stock As Integer = Convert.ToInt32(row("p_stock"))
                Dim minStock As Integer = Convert.ToInt32(row("p_minStock"))

                ' ✨ Product Card Style - clean white background, no border
                Dim card As New Panel With {
        .Width = 300,
        .Height = 440,
        .Margin = New Padding(10),
        .BackColor = Color.White,          ' ✅ Clean white background
        .BorderStyle = BorderStyle.None,   ' ✅ No border
        .Padding = New Padding(10)
    }

                ' 🔴 Low-stock highlight
                If stock <= minStock Then
                    card.BackColor = Color.MistyRose
                End If

                ' 🔵 Search highlight
                If searchTerm <> "" Then
                    Dim idStr As String = row("p_id").ToString().ToLower()
                    Dim nameStr As String = row("p_name").ToString().ToLower()
                    If idStr.Contains(searchTerm.ToLower()) Or nameStr.Contains(searchTerm.ToLower()) Then
                        card.BackColor = Color.LightBlue
                    End If
                End If


                ' === Product Image ===
                Dim picture As New PictureBox With {
    .Width = 270,
    .Height = 140,
    .SizeMode = PictureBoxSizeMode.Zoom,
    .Location = New Point(15, 10)
}

                Try
                    If Not IsDBNull(row("p_image")) Then
                        Dim imgBytes() As Byte = CType(row("p_image"), Byte())
                        Using ms As New MemoryStream(imgBytes)
                            picture.Image = Image.FromStream(ms)
                        End Using
                    Else
                        ' Fallback if no image in database
                        Dim fallbackPath As String = IO.Path.Combine(Application.StartupPath, "replace.png")
                        If IO.File.Exists(fallbackPath) Then
                            picture.Image = Image.FromFile(fallbackPath)
                        Else
                            picture.BackColor = Color.LightGray ' safety fallback if image missing
                        End If
                    End If
                Catch ex As Exception
                    ' In case of corrupted or invalid image data, also use fallback
                    Dim fallbackPath As String = IO.Path.Combine(Application.StartupPath, "replace.png")
                    If IO.File.Exists(fallbackPath) Then
                        picture.Image = Image.FromFile(fallbackPath)
                    Else
                        picture.BackColor = Color.LightGray
                    End If
                End Try


                ' === Labels ===
                Dim nameLbl As New Label With {
                    .Text = "Name: " & row("p_name").ToString(),
                    .Font = New Font("Segoe UI", 10, FontStyle.Bold),
                    .AutoSize = True,
                    .Location = New Point(15, 160)
                }

                Dim idLbl As New Label With {
                    .Text = "Product ID: " & row("p_id").ToString(),
                    .Font = New Font("Segoe UI", 9),
                    .AutoSize = True,
                    .Location = New Point(15, 185)
                }

                Dim supplierNameLbl As New Label With {
                    .Text = "Supplier Name: " & If(IsDBNull(row("sup_name")), "N/A", row("sup_name").ToString()),
                    .Font = New Font("Segoe UI", 9),
                    .AutoSize = True,
                    .Location = New Point(15, 205)
                }

                Dim supplierLbl As New Label With {
                    .Text = "Supplier ID: " & row("sup_id").ToString(),
                    .Font = New Font("Segoe UI", 9),
                    .AutoSize = True,
                    .Location = New Point(15, 225)
                }

                Dim categoryLbl As New Label With {
                    .Text = "Category: " & row("p_category").ToString(),
                    .Font = New Font("Segoe UI", 9),
                    .AutoSize = True,
                    .Location = New Point(15, 245)
                }

                Dim stockLbl As New Label With {
                    .Text = "Stock: " & stock.ToString(),
                    .Font = New Font("Segoe UI", 9),
                    .AutoSize = True,
                    .Location = New Point(15, 265)
                }

                Dim minStockLbl As New Label With {
                    .Text = "Min Stock: " & minStock.ToString(),
                    .Font = New Font("Segoe UI", 9),
                    .AutoSize = True,
                    .Location = New Point(15, 285)
                }

                If stock <= minStock Then
                    stockLbl.ForeColor = Color.Red
                    minStockLbl.ForeColor = Color.Red
                    stockLbl.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                End If

                Dim priceLbl As New Label With {
                    .Text = "Price: RM " & Convert.ToDecimal(row("p_sellPrice")).ToString("N2"),
                    .Font = New Font("Segoe UI", 9),
                    .AutoSize = True,
                    .Location = New Point(15, 305)
                }

                ' === Buttons ===
                Dim editBtn As New Button With {
                    .Text = "Edit ✏️",
                    .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                    .BackColor = Color.LightSkyBlue,
                    .FlatStyle = FlatStyle.Flat,
                    .Size = New Size(80, 30),
                    .Location = New Point(25, 380)
                }
                editBtn.FlatAppearance.BorderSize = 0

                Dim orderBtn As New Button With {
                    .Text = "Order ⬆️",
                    .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                    .BackColor = Color.LightGreen,
                    .FlatStyle = FlatStyle.Flat,
                    .Size = New Size(80, 30),
                    .Location = New Point(110, 380)
                }
                orderBtn.FlatAppearance.BorderSize = 0

                Dim deleteBtn As New Button With {
                    .Text = "Delete 🗑️",
                    .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                    .BackColor = Color.LightCoral,
                    .FlatStyle = FlatStyle.Flat,
                    .Size = New Size(80, 30),
                    .Location = New Point(195, 380)
                }
                deleteBtn.FlatAppearance.BorderSize = 0

                Dim productID As Integer = Convert.ToInt32(row("p_id"))
                Dim productName As String = row("p_name").ToString()

                AddHandler editBtn.Click, Sub()
                                              Dim editForm As New EditProductForm()
                                              editForm.ProductID = productID
                                              If editForm.ShowDialog() = DialogResult.OK Then
                                                  LoadProductCards()
                                              End If
                                          End Sub

                AddHandler orderBtn.Click, Sub()
                                               Dim orderForm As New OrderProductForm()
                                               orderForm.SelectedProductID = productID
                                               orderForm.SelectedProductName = productName
                                               orderForm.ShowDialog()
                                           End Sub

                AddHandler deleteBtn.Click, Sub()
                                                DeleteProduct(productID, productName)
                                            End Sub

                card.Controls.Add(picture)
                card.Controls.Add(nameLbl)
                card.Controls.Add(idLbl)
                card.Controls.Add(supplierNameLbl)
                card.Controls.Add(supplierLbl)
                card.Controls.Add(categoryLbl)
                card.Controls.Add(stockLbl)
                card.Controls.Add(minStockLbl)
                card.Controls.Add(priceLbl)
                card.Controls.Add(editBtn)
                card.Controls.Add(orderBtn)
                card.Controls.Add(deleteBtn)

                ProductListFlowLayoutPanel.Controls.Add(card)
            Next

        Catch ex As Exception
            MessageBox.Show("❌ Error loading products: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' === DELETE PRODUCT ===
    Private Sub DeleteProduct(productID As Integer, productName As String)
        Dim confirm As DialogResult = MessageBox.Show(
            $"Are you sure you want to delete '{productName}' (ID: {productID})?",
            "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If confirm = DialogResult.Yes Then
            Try
                ConnectDB()
                Using cmd As New MySqlCommand("DELETE FROM tb_products WHERE p_id = @pid", conn)
                    cmd.Parameters.AddWithValue("@pid", productID)
                    cmd.ExecuteNonQuery()
                End Using
                MessageBox.Show($"✅ Product '{productName}' deleted successfully!")
                LoadProductCards()
            Catch ex As Exception
                MessageBox.Show("❌ Failed to delete product: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub AddProductButton_Click(sender As Object, e As EventArgs) Handles AddProductButton.Click
        AddProductForm.Show()
    End Sub

    Private Sub SearchProductButton_Click(sender As Object, e As EventArgs) Handles SearchProductButton.Click
        Dim searchTerm As String = ProductSearchTextBox.Text.Trim()
        If searchTerm = "" Then
            LoadProductCards()
            Exit Sub
        End If
        LoadProductCards(searchTerm)
    End Sub

End Class
