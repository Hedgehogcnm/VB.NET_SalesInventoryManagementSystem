Imports MySql.Data.MySqlClient
Imports System.IO

Public Class InventoryForm

    ' === COLUMN POSITIONS AND WIDTHS ===
    Private columnWidths() As Integer = {80, 120, 210, 100, 160, 120, 80, 100, 110, 110, 210}
    Private columnNames() As String = {
        "Image", "Product ID", "Product Name",
        "Supplier ID", "Supplier Name", "Category",
        "Stock", "Min Stock", "Cost Price", "Sell Price", "Action"
    }

    ' === FORM LOAD ===
    Private Sub InventoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupProductHeader()
        ProductListFlowLayoutPanel.AutoScroll = True
        ProductListFlowLayoutPanel.WrapContents = False
        ProductListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown
        LoadProductTable()

        ' === Initialize placeholder text ===
        ProductSearchTextBox.Text = "Enter Product Name to Search"
        ProductSearchTextBox.ForeColor = Color.Gray
    End Sub

    Private Sub InventoryForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        LoadProductTable()
    End Sub

    ' === PRODUCT SEARCH PLACEHOLDER ===
    Private Sub ProductSearchTextBox_GotFocus(sender As Object, e As EventArgs) Handles ProductSearchTextBox.GotFocus
        If ProductSearchTextBox.Text = "Enter Product Name to Search" Then
            ProductSearchTextBox.Text = ""
            ProductSearchTextBox.ForeColor = Color.Black
        End If
    End Sub

    Private Sub ProductSearchTextBox_LostFocus(sender As Object, e As EventArgs) Handles ProductSearchTextBox.LostFocus
        If String.IsNullOrWhiteSpace(ProductSearchTextBox.Text) Then
            ProductSearchTextBox.Text = "Enter Product Name to Search"
            ProductSearchTextBox.ForeColor = Color.Gray
        End If
    End Sub

    ' === HEADER SETUP ===
    Private Sub SetupProductHeader()
        HeaderPanel.Controls.Clear()
        HeaderPanel.BackColor = Color.Bisque ' Light yellow

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

    ' === REFRESH FROM OTHER FORMS ===
    Public Sub RefreshProductListFromOtherForm()
        LoadProductTable()
    End Sub

    ' === NAVIGATION MENU ===
    Private Sub SalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem.Click
        Dim frm As New SalesForm()
        frm.Show()
        Me.Close()
    End Sub

    Private Sub InventoryToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles InventoryToolStripMenuItem.Click
        Dim frm As New InventoryForm()
        frm.Show()
        Me.Close()
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem.Click
        Dim frm As New SupplierForm()
        frm.Show()
        Me.Close()
    End Sub

    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click
        Dim frm As New ReportForm()
        frm.Show()
        Me.Close()
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

            ' ✅ Search only by Product Name
            If searchTerm <> "" Then
                sql &= " WHERE p.p_name LIKE @search"
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
                    .Text = "😕 No products found.",
                    .Font = New Font("Segoe UI", 11, FontStyle.Italic),
                    .ForeColor = Color.Gray,
                    .AutoSize = True,
                    .Margin = New Padding(20)
                }
                ProductListFlowLayoutPanel.Controls.Add(noDataLbl)
                Exit Sub
            End If

            ' === DISPLAY PRODUCT ROWS ===
            For Each row As DataRow In dt.Rows
                Dim rowPanel As New Panel With {
                    .Width = ProductListFlowLayoutPanel.Width - 25,
                    .Height = 80,
                    .BackColor = Color.White,
                    .Margin = New Padding(2)
                }

                Dim productID As Integer = Convert.ToInt32(row("p_id"))
                Dim productName As String = row("p_name").ToString()
                Dim stock As Integer = Convert.ToInt32(row("p_stock"))
                Dim minStock As Integer = Convert.ToInt32(row("p_minStock"))

                ' 🔴 Highlight low stock
                If stock <= minStock Then rowPanel.BackColor = Color.MistyRose

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
                    pic.BackColor = Color.LightGray
                End Try
                rowPanel.Controls.Add(pic)

                ' === Text fields ===
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

                Dim xPos As Integer = 90
                For i = 0 To fields.Length - 1
                    Dim lbl As New Label With {
                        .Text = fields(i),
                        .Font = New Font("Segoe UI", 9),
                        .AutoSize = False,
                        .TextAlign = ContentAlignment.MiddleCenter,
                        .Width = columnWidths(i + 1),
                        .Location = New Point(xPos, 30)
                    }
                    rowPanel.Controls.Add(lbl)
                    xPos += columnWidths(i + 1)
                Next

                ' === Operations ===
                Dim operationStartX As Integer = xPos

                Dim editBtn As New Button With {
                    .Text = "✏️ Edit",
                    .BackColor = Color.LightBlue,
                    .FlatStyle = FlatStyle.Flat,
                    .Width = 70,
                    .Location = New Point(operationStartX, 25)
                }
                editBtn.FlatAppearance.BorderSize = 0
                AddHandler editBtn.Click, Sub()
                                              Dim frm As New EditProductForm()
                                              frm.ProductID = productID
                                              If frm.ShowDialog() = DialogResult.OK Then LoadProductTable()
                                          End Sub

                Dim orderBtn As New Button With {
                    .Text = "📦 Order",
                    .BackColor = Color.LightGreen,
                    .FlatStyle = FlatStyle.Flat,
                    .Width = 70,
                    .Location = New Point(operationStartX + 80, 25)
                }
                orderBtn.FlatAppearance.BorderSize = 0
                AddHandler orderBtn.Click, Sub()
                                               Dim frm As New OrderProductForm()
                                               frm.SelectedProductID = productID
                                               frm.SelectedProductName = productName
                                               frm.ShowDialog()
                                           End Sub

                Dim deleteBtn As New Button With {
                    .Text = "🗑️ Delete",
                    .BackColor = Color.LightPink,
                    .FlatStyle = FlatStyle.Flat,
                    .Width = 70,
                    .Location = New Point(operationStartX + 160, 25)
                }
                deleteBtn.FlatAppearance.BorderSize = 0
                AddHandler deleteBtn.Click, Sub() DeleteProduct(productID, productName)

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

    ' === DELETE PRODUCT ===
    ' === DELETE PRODUCT ===
    Private Sub DeleteProduct(productID As Integer, productName As String)
        Dim confirm As DialogResult = MessageBox.Show(
        $"Are you sure you want to delete '{productName}' (ID: {productID})? " & vbCrLf &
        "This will also remove all related sales details, orders, and inventory movements.",
        "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If confirm = DialogResult.Yes Then
            Try
                ConnectDB()
                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        ' 🧾 Delete related sales detail records
                        Using cmd0 As New MySqlCommand("DELETE FROM tb_sales_detail WHERE p_id = @pid", conn, transaction)
                            cmd0.Parameters.AddWithValue("@pid", productID)
                            cmd0.ExecuteNonQuery()
                        End Using

                        ' 🧭 Delete related inventory movements
                        Using cmd1 As New MySqlCommand("DELETE FROM tb_inventorymovements WHERE p_id = @pid", conn, transaction)
                            cmd1.Parameters.AddWithValue("@pid", productID)
                            cmd1.ExecuteNonQuery()
                        End Using

                        ' 📦 Delete related orders
                        Using cmd2 As New MySqlCommand("DELETE FROM tb_orders WHERE p_id = @pid", conn, transaction)
                            cmd2.Parameters.AddWithValue("@pid", productID)
                            cmd2.ExecuteNonQuery()
                        End Using

                        ' 🧹 Finally, delete product itself
                        Using cmd3 As New MySqlCommand("DELETE FROM tb_products WHERE p_id = @pid", conn, transaction)
                            cmd3.Parameters.AddWithValue("@pid", productID)
                            cmd3.ExecuteNonQuery()
                        End Using

                        transaction.Commit()
                        MessageBox.Show($"✅ Product '{productName}' deleted successfully, including related sales, orders, and inventory data.")
                        LoadProductTable()

                    Catch ex As Exception
                        transaction.Rollback()
                        MessageBox.Show("❌ Failed to delete product: " & ex.Message)
                    End Try
                End Using
            Catch ex As Exception
                MessageBox.Show("❌ Database error: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End If
    End Sub


    ' === BUTTONS ON FORM ===
    Private Sub AddProductButton_Click(sender As Object, e As EventArgs) Handles AddProductButton.Click
        AddProductForm.ShowDialog()
    End Sub

    Private Sub SearchProductButton_Click(sender As Object, e As EventArgs) Handles SearchProductButton.Click
        Dim searchTerm As String = ProductSearchTextBox.Text.Trim()

        ' Ignore placeholder text
        If searchTerm = "Enter Product Name to Search" Then
            MessageBox.Show("Please enter a Product Name to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' --- Block empty input ---
        If String.IsNullOrWhiteSpace(searchTerm) Then
            MessageBox.Show("Please enter a Product Name to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' --- Validate letters and spaces only ---
        If Not System.Text.RegularExpressions.Regex.IsMatch(searchTerm, "^[a-zA-Z\s]+$") Then
            MessageBox.Show("❌ Only letters and spaces are allowed for Product Name search.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        LoadProductTable(searchTerm)
    End Sub

    Private Sub ViewOrderButton_Click(sender As Object, e As EventArgs) Handles ViewOrderButton.Click
        ViewOrderForm.ShowDialog()
    End Sub

End Class
