Imports MySql.Data.MySqlClient
Imports System.IO

Public Class InventoryForm

    ' === COLUMN POSITIONS AND WIDTHS ===
    Private columnWidths() As Integer = {80, 120, 250, 100, 160, 120, 80, 100, 120, 120, 200}
    Private columnNames() As String = {
        "Image", "Product ID", "Product Name",
        "Supplier ID", "Supplier Name", "Category",
        "Stock", "Min Stock", "Cost Price", "Sell Price", "Operation"
    }

    Private Sub InventoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupProductHeader()   ' Build header once
        ProductListFlowLayoutPanel.AutoScroll = True
        ProductListFlowLayoutPanel.WrapContents = False
        ProductListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown
        LoadProductTable()
    End Sub

    Private Sub SetupProductHeader()
        HeaderPanel.Controls.Clear()
        HeaderPanel.BackColor = Color.FromArgb(255, 255, 200) ' Light yellow

        Dim x As Integer = 10
        For i = 0 To columnNames.Length - 1
            Dim lbl As New Label With {
                .Text = columnNames(i),
                .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                .AutoSize = False,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Width = columnWidths(i),
                .Location = New Point(x, 8)
            }
            HeaderPanel.Controls.Add(lbl)
            x += columnWidths(i)
        Next
    End Sub

    Private Sub InventoryForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        LoadProductTable()
    End Sub

    ' === NAVIGATION MENU ===
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
        LoadProductTable()
    End Sub

    ' === LOAD PRODUCT TABLE ===
    Private Sub LoadProductTable(Optional searchTerm As String = "")
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
            If searchTerm <> "" Then cmd.Parameters.AddWithValue("@search", "%" & searchTerm & "%")

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            conn.Close()

            ProductListFlowLayoutPanel.Controls.Clear()

            ' === NO DATA FOUND ===
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

            ' === TABLE ROWS ===
            For Each row As DataRow In dt.Rows
                Dim rowPanel As New Panel With {
                    .Width = ProductListFlowLayoutPanel.Width - 25,
                    .Height = 80,
                    .BackColor = Color.White,
                    .Margin = New Padding(2)
                }

                Dim stock As Integer = Convert.ToInt32(row("p_stock"))
                Dim minStock As Integer = Convert.ToInt32(row("p_minStock"))

                ' 🔴 Low-stock highlight
                If stock <= minStock Then
                    rowPanel.BackColor = Color.MistyRose
                End If

                ' === Product Image ===
                Dim pic As New PictureBox With {
                    .Width = 70,
                    .Height = 60,
                    .Location = New Point(10, 10),
                    .SizeMode = PictureBoxSizeMode.Zoom
                }

                Try
                    If Not IsDBNull(row("p_image")) Then
                        Dim imgBytes() As Byte = CType(row("p_image"), Byte())
                        Using ms As New MemoryStream(imgBytes)
                            pic.Image = Image.FromStream(ms)
                        End Using
                    Else
                        Dim fallbackPath As String = Path.Combine(Application.StartupPath, "replace.png")
                        If File.Exists(fallbackPath) Then
                            pic.Image = Image.FromFile(fallbackPath)
                        Else
                            pic.BackColor = Color.LightGray
                        End If
                    End If
                Catch
                    Dim fallbackPath As String = Path.Combine(Application.StartupPath, "replace.png")
                    If File.Exists(fallbackPath) Then
                        pic.Image = Image.FromFile(fallbackPath)
                    Else
                        pic.BackColor = Color.LightGray
                    End If
                End Try

                rowPanel.Controls.Add(pic)

                ' === TEXT FIELDS (including cost and sell price) ===
                Dim fields() As String = {
                    row("p_id").ToString(),
                    row("p_name").ToString(),
                    row("sup_id").ToString(),
                    If(IsDBNull(row("sup_name")), "N/A", row("sup_name").ToString()),
                    row("p_category").ToString(),
                    row("p_stock").ToString(),
                    row("p_minStock").ToString(),
                    FormatCurrency(row("p_costPrice"), 2),
                    FormatCurrency(row("p_sellPrice"), 2)
                }

                Dim xPos As Integer = 90 ' start a bit after image
                For i = 0 To fields.Length - 1
                    Dim lbl As New Label With {
                        .Text = fields(i),
                        .Font = New Font("Segoe UI", 9),
                        .AutoSize = False,
                        .TextAlign = ContentAlignment.MiddleCenter,
                        .Width = columnWidths(i + 1), ' skip image column
                        .Location = New Point(xPos, 30)
                    }
                    rowPanel.Controls.Add(lbl)
                    xPos += columnWidths(i + 1)
                Next

                ' === OPERATIONS ===
                Dim operationStartX As Integer = xPos
                Dim editBtn As New Button With {
                    .Text = "Edit",
                    .BackColor = Color.LightSkyBlue,
                    .FlatStyle = FlatStyle.Flat,
                    .Width = 60,
                    .Location = New Point(operationStartX, 25)
                }
                editBtn.FlatAppearance.BorderSize = 0

                Dim orderBtn As New Button With {
                    .Text = "Order",
                    .BackColor = Color.LightGreen,
                    .FlatStyle = FlatStyle.Flat,
                    .Width = 60,
                    .Location = New Point(operationStartX + 70, 25)
                }
                orderBtn.FlatAppearance.BorderSize = 0

                Dim deleteBtn As New Button With {
                    .Text = "Delete",
                    .BackColor = Color.LightCoral,
                    .FlatStyle = FlatStyle.Flat,
                    .Width = 60,
                    .Location = New Point(operationStartX + 140, 25)
                }
                deleteBtn.FlatAppearance.BorderSize = 0

                Dim productID As Integer = Convert.ToInt32(row("p_id"))
                Dim productName As String = row("p_name").ToString()

                AddHandler editBtn.Click, Sub()
                                              Dim editForm As New EditProductForm()
                                              editForm.ProductID = productID
                                              If editForm.ShowDialog() = DialogResult.OK Then
                                                  LoadProductTable()
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

                rowPanel.Controls.Add(editBtn)
                rowPanel.Controls.Add(orderBtn)
                rowPanel.Controls.Add(deleteBtn)

                ProductListFlowLayoutPanel.Controls.Add(rowPanel)
            Next

        Catch ex As Exception
            MessageBox.Show("❌ Error loading products: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' === DELETE PRODUCT AND RELATED INVENTORY ===
    ' === DELETE PRODUCT AND RELATED INVENTORY AND ORDERS ===
    Private Sub DeleteProduct(productID As Integer, productName As String)
        ' Show confirmation dialog before proceeding
        Dim confirm As DialogResult = MessageBox.Show(
        $"Are you sure you want to delete '{productName}' (ID: {productID})? " & vbCrLf &
        "This will also remove all related inventory movement records and orders.",
        "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        ' If the user clicks Yes, proceed with deletion
        If confirm = DialogResult.Yes Then
            Try
                ConnectDB()

                ' Start a transaction to ensure all deletions are done atomically
                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        ' Delete related inventory movement records first
                        Using cmdDeleteMovements As New MySqlCommand("DELETE FROM tb_inventorymovements WHERE p_id = @pid", conn, transaction)
                            cmdDeleteMovements.Parameters.AddWithValue("@pid", productID)
                            cmdDeleteMovements.ExecuteNonQuery()
                        End Using

                        ' Delete related orders for this product
                        Using cmdDeleteOrders As New MySqlCommand("DELETE FROM tb_orders WHERE p_id = @pid", conn, transaction)
                            cmdDeleteOrders.Parameters.AddWithValue("@pid", productID)
                            cmdDeleteOrders.ExecuteNonQuery()
                        End Using

                        ' Delete the product record from tb_products
                        Using cmdDeleteProduct As New MySqlCommand("DELETE FROM tb_products WHERE p_id = @pid", conn, transaction)
                            cmdDeleteProduct.Parameters.AddWithValue("@pid", productID)
                            cmdDeleteProduct.ExecuteNonQuery()
                        End Using

                        ' Commit the transaction if everything is successful
                        transaction.Commit()
                        MessageBox.Show($"✅ Product '{productName}' (ID: {productID}) and related records (inventory and orders) deleted successfully.")
                        ' Reload the product table after deletion
                        LoadProductTable()

                    Catch ex As Exception
                        ' Rollback the transaction if any part fails
                        transaction.Rollback()
                        MessageBox.Show("❌ Failed to delete product and related records: " & ex.Message)
                    End Try
                End Using
            Catch ex As Exception
                MessageBox.Show("❌ Connection error: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End If
    End Sub



    Private Sub AddProductButton_Click(sender As Object, e As EventArgs) Handles AddProductButton.Click
        AddProductForm.ShowDialog()
    End Sub

    Private Sub SearchProductButton_Click(sender As Object, e As EventArgs) Handles SearchProductButton.Click
        Dim searchTerm As String = ProductSearchTextBox.Text.Trim()
        LoadProductTable(searchTerm)
    End Sub

    Private Sub ViewOrderButton_Click(sender As Object, e As EventArgs) Handles ViewOrderButton.Click
        ViewOrderForm.ShowDialog()
    End Sub
End Class
