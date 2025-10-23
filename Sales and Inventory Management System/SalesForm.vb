Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing

Public Class SalesForm
    Private Sub SalesToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem.Click
        Dim Sales As New SalesForm
        Sales.Show()
        Close()
    End Sub

    Private Sub InventoryToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles InventoryToolStripMenuItem.Click
        Dim Inventory As New InventoryForm
        Inventory.Show()
        Close()
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem.Click
        Dim Supplier As New SupplierForm
        Supplier.Show()
        Close()
    End Sub

    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click
        Dim Report As New ReportForm
        Report.Show()
        Close()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Dim login As New LoginForm
        login.Show()
        Close()
    End Sub

    Private Sub SalesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerateInvoiceNo()
        ComboBoxCategory.SelectedIndex = 0
        ButtonSearch_Click(Nothing, Nothing)
    End Sub

    'Genarate Invoice Number
    Private Sub GenerateInvoiceNo()
        Try
            ConnectDB()

            ' Always ensure no reader is still open
            Dim today As String = DateTime.Now.ToString("yyyyMMdd")
            Dim query As String = "SELECT s_invoiceNo FROM tb_sales 
                               WHERE s_invoiceNo LIKE @todayPrefix 
                               ORDER BY s_id DESC LIMIT 1"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@todayPrefix", "INV" & today & "%")

                ' Use ExecuteScalar (it does NOT leave a DataReader open)
                Dim latestInvoice As Object = cmd.ExecuteScalar()
                Dim newInvoice As String

                If latestInvoice IsNot Nothing Then
                    Dim lastNumber As Integer = CInt(Mid(latestInvoice.ToString(), 12))
                    newInvoice = "INV" & today & (lastNumber + 1).ToString("D3")
                Else
                    newInvoice = "INV" & today & "001"
                End If

                labelInvoiceNo.Text = "#" & newInvoice
            End Using

        Catch ex As Exception
            MessageBox.Show("Error generating invoice number: " & ex.Message)

        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        FlowLayoutPanelSales.Controls.Clear()
        FlowLayoutPanelSales.AutoScroll = True

        Dim selectedCategory As String = ComboBoxCategory.SelectedItem.ToString()

        Try
            ConnectDB()

            ' Include the image column in your query
            Dim query As String
            If selectedCategory = "All" Then
                query = "SELECT p_name, p_sellPrice, p_image, p_stock FROM tb_products"
            Else
                query = "SELECT p_name, p_sellPrice, p_image, p_stock FROM tb_products WHERE p_category = @cat"
            End If

            Dim cmd As New MySqlCommand(query, conn)
            If selectedCategory <> "All" Then
                cmd.Parameters.AddWithValue("@cat", selectedCategory)
            End If

            ' Step 1: Load data into list
            Dim productList As New List(Of Product)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim p As New Product()
                p.Name = reader("p_name").ToString()
                p.Price = Convert.ToDecimal(reader("p_sellPrice"))
                p.Stock = Convert.ToInt32(reader("p_stock"))

                ' Read the image bytes safely
                If Not IsDBNull(reader("p_image")) Then
                    p.ImageData = DirectCast(reader("p_image"), Byte())
                Else
                    p.ImageData = Nothing
                End If

                productList.Add(p)
            End While
            reader.Close()

            ' Step 2: Display all cards
            For Each item As Product In productList
                Dim card As New Panel()
                card.Width = 150
                card.Height = 180
                card.BackColor = Color.White
                card.Margin = New Padding(30)
                card.BorderStyle = BorderStyle.None
                card.Region = CreateRoundedRegion(card, 13)

                Dim pic As New PictureBox()
                pic.Width = 100
                pic.Height = 80
                pic.SizeMode = PictureBoxSizeMode.Zoom
                pic.Location = New Point((card.Width - pic.Width) \ 2, 5)

                ' ✅ Load image from BLOB
                If item.ImageData IsNot Nothing Then
                    Dim ms As New IO.MemoryStream(item.ImageData)
                    pic.Image = Image.FromStream(ms)
                Else
                    ' fallback image if no image in DB
                    pic.Image = Image.FromFile(Application.StartupPath & "\replace.png")
                End If

                Dim lblName As New Label()
                Dim cleanName As String = System.Text.RegularExpressions.Regex.Replace(item.Name, "\(.*?\)", "").Trim()
                lblName.Text = cleanName
                lblName.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                lblName.AutoSize = False
                lblName.Width = card.Width
                lblName.Height = 35
                lblName.TextAlign = ContentAlignment.MiddleCenter
                lblName.Location = New Point(0, 90)

                Dim lblPrice As New Label()
                lblPrice.Text = "RM " & item.Price.ToString("0.00")
                lblPrice.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                lblPrice.AutoSize = False
                lblPrice.Width = card.Width
                lblPrice.Height = 25
                lblPrice.ForeColor = Color.Gray
                lblPrice.TextAlign = ContentAlignment.MiddleCenter
                lblPrice.Location = New Point(0, 130)

                card.Controls.Add(pic)
                card.Controls.Add(lblName)
                card.Controls.Add(lblPrice)

                AddHandler card.Click, Sub(sender2, e2) AddToCart(item)
                For Each ctrl As Control In card.Controls
                    AddHandler ctrl.Click, Sub(sender2, e2) AddToCart(item)
                Next
                FlowLayoutPanelSales.Controls.Add(card)
            Next

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Cart As New Dictionary(Of String, CartItem)  ' Key = product name

    Private Sub AddToCart(item As Product)
        ' If already in cart, just increase quantity
        If Cart.ContainsKey(item.Name) Then
            Cart(item.Name).Quantity += 1
        Else
            Dim newItem As New CartItem With {
            .Name = item.Name,
            .Price = item.Price,
            .Quantity = 1,
            .Stock = item.Stock,
            .ImageData = item.ImageData
        }
            Cart.Add(item.Name, newItem)
        End If

        RefreshCartPanel()
    End Sub

    Private Sub RefreshCartPanel()
        FlowLayoutPanelItem.Controls.Clear()
        FlowLayoutPanelItem.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanelItem.WrapContents = False
        FlowLayoutPanelItem.AutoScroll = True

        For Each c In Cart.Values
            ' === Create the main container card ===
            Dim card As New Panel With {
            .Width = FlowLayoutPanelItem.Width - 35,
            .Height = 100,
            .BackColor = Color.White,
            .Margin = New Padding(5),
            .BorderStyle = BorderStyle.None
        }

            ' === Product image ===
            Dim pic As New PictureBox With {
            .Width = 70,
            .Height = 70,
            .SizeMode = PictureBoxSizeMode.Zoom,
            .Location = New Point(10, 15)
        }
            ' Try to load from product (you can store in CartItem later)
            If c.ImageData IsNot Nothing Then
                Dim ms As New IO.MemoryStream(c.ImageData)
                pic.Image = Image.FromStream(ms)
            Else
                pic.Image = Image.FromFile(Application.StartupPath & "\replace.png")
            End If

            ' === Product name ===
            Dim lblName As New Label With {
            .Text = c.Name,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .AutoSize = False,
            .Width = 300,
            .Height = 25,
            .Location = New Point(90, 10)
        }

            ' === Single item price ===
            Dim lblUnitPrice As New Label With {
            .Text = "RM " & c.Price.ToString("0.00"),
            .Font = New Font("Segoe UI", 9, FontStyle.Regular),
            .ForeColor = Color.Gray,
            .AutoSize = False,
            .Width = 100,
            .Height = 20,
            .Location = New Point(90, 35)
        }

            ' === Quantity buttons & textbox ===
            Dim btnMinus As New Button With {
            .Text = "-",
            .Width = 25,
            .Location = New Point(90, 60)
        }

            Dim txtQty As New TextBox With {
            .Text = c.Quantity.ToString(),
            .Width = 40,
            .Location = New Point(120, 60),
            .TextAlign = HorizontalAlignment.Center
        }

            Dim btnPlus As New Button With {
            .Text = "+",
            .Width = 25,
            .Location = New Point(165, 60)
        }

            ' === Stock label (top-right) ===
            Dim lblStock As New Label With {
            .Text = "Stock: " & c.Stock.ToString(),
            .Font = New Font("Segoe UI", 8, FontStyle.Italic),
            .ForeColor = Color.DimGray,
            .AutoSize = False,
            .Width = 100,
            .Height = 18,
            .TextAlign = ContentAlignment.MiddleRight,
            .Location = New Point(card.Width - 110, 10)
        }
            lblStock.Text = "Stock: " & (c.Stock - c.Quantity).ToString()

            ' === Total price label (right side) ===
            Dim lblTotal As New Label With {
            .Text = "RM " & c.Total.ToString("0.00"),
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .AutoSize = False,
            .Width = 200,
            .Height = 20,
            .TextAlign = ContentAlignment.MiddleRight,
            .Location = New Point(card.Width - 210, 65)
        }

            ' === Event Handlers ===
            ' === Plus button ===
            AddHandler btnPlus.Click, Sub()
                                          If c.Quantity + 1 > c.Stock Then
                                              MessageBox.Show("Only " & c.Stock & " units available.", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                          Else
                                              c.Quantity += 1
                                          End If
                                          RefreshCartPanel()
                                      End Sub

            ' === Minus button ===
            AddHandler btnMinus.Click, Sub()
                                           c.Quantity -= 1
                                           If c.Quantity <= 0 Then Cart.Remove(c.Name)
                                           RefreshCartPanel()
                                       End Sub

            ' === TextBox (Enter/Leave method) ===
            AddHandler txtQty.KeyDown, Sub(sender3, e3)
                                           If e3.KeyCode = Keys.Enter Then
                                               e3.SuppressKeyPress = True ' prevent the "ding" sound

                                               Dim qty As Integer
                                               If Integer.TryParse(txtQty.Text, qty) Then
                                                   If qty <= 0 Then
                                                       Cart.Remove(c.Name)
                                                   ElseIf qty > c.Stock Then
                                                       qty = c.Stock
                                                       MessageBox.Show("Only " & c.Stock & " units available.", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                   End If
                                                   c.Quantity = qty
                                               End If

                                               RefreshCartPanel()
                                           End If
                                       End Sub

            ' === Add controls into card ===
            card.Controls.Add(pic)
            card.Controls.Add(lblName)
            card.Controls.Add(lblUnitPrice)
            card.Controls.Add(btnMinus)
            card.Controls.Add(txtQty)
            card.Controls.Add(btnPlus)
            card.Controls.Add(lblStock)
            card.Controls.Add(lblTotal)
            card.Region = CreateRoundedRegion(card, 6)

            ' === Add card to flow panel ===
            FlowLayoutPanelItem.Controls.Add(card)
        Next

        UpdateTotals()
    End Sub

    Private Function CreateRoundedRegion(ctrl As Control, radius As Integer) As Region
        Dim path As New Drawing2D.GraphicsPath()
        Dim rect As Rectangle = ctrl.ClientRectangle

        ' Draw smooth corners
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90) ' top-left
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90) ' top-right
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90) ' bottom-right
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90) ' bottom-left
        path.CloseFigure()

        Return New Region(path)
    End Function


    Private Sub UpdateTotals()
        Dim subtotal As Decimal = Cart.Values.Sum(Function(x) x.Total)
        LabelSubTotal.Text = "RM " & subtotal.ToString("0.00")

        Dim discountPercent As Decimal
        Decimal.TryParse(TextBoxDiscount.Text, discountPercent)
        Dim discountValue = subtotal * (discountPercent / 100D)

        LabelDiscount.Text = "- RM " & discountValue.ToString("0.00")
        LabelTotal.Text = "RM " & (subtotal - discountValue).ToString("0.00")
    End Sub

    Private Sub TextBoxDiscount_TextChanged(sender As Object, e As EventArgs) Handles TextBoxDiscount.TextChanged
        UpdateTotals()
    End Sub

    Private WithEvents PrintDoc As New PrintDocument
    Private PrintDlg As New PrintDialog
    Private currentInvoiceNo As String
    Private invoiceTable As DataTable
    Private customerName As String
    Private totalAmount As Decimal
    Private discountValue As Decimal
    Private subTotal As Decimal

    Private Sub ButtonCheckOut_Click(sender As Object, e As EventArgs) Handles ButtonCheckOut.Click
        customerName = TextBoxCustomerName.Text.Trim()
        If customerName = "" Or customerName = "Customer Name" Then
            MessageBox.Show("Please enter customer name.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Cart.Count = 0 Then
            MessageBox.Show("Your cart is empty.", "No Items", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            ConnectDB()

            currentInvoiceNo = labelInvoiceNo.Text.Replace("#", "").Trim()
            subTotal = Cart.Values.Sum(Function(x) x.Total)
            Dim discountPercent As Decimal
            Decimal.TryParse(TextBoxDiscount.Text, discountPercent)
            discountValue = subTotal * (discountPercent / 100D)
            totalAmount = subTotal - discountValue

            ' === Save into tb_sales ===
            Dim sqlSale As String = "INSERT INTO tb_sales (u_id, s_invoiceNo, s_customer, s_total) VALUES (@uid, @inv, @cust, @total)"
            Using cmd As New MySqlCommand(sqlSale, conn)
                cmd.Parameters.AddWithValue("@uid", 1)
                cmd.Parameters.AddWithValue("@inv", currentInvoiceNo)
                cmd.Parameters.AddWithValue("@cust", customerName)
                cmd.Parameters.AddWithValue("@total", totalAmount)
                cmd.ExecuteNonQuery()
            End Using

            ' === Get the new sale id ===
            Dim saleId As Integer
            Using cmd As New MySqlCommand("SELECT LAST_INSERT_ID()", conn)
                saleId = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            ' === Save sale details ===
            For Each item In Cart.Values
                Dim productId As Integer
                Using cmd As New MySqlCommand("SELECT p_id FROM tb_products WHERE p_name=@pname LIMIT 1", conn)
                    cmd.Parameters.AddWithValue("@pname", item.Name)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then productId = Convert.ToInt32(result)
                End Using

                If productId > 0 Then
                    Dim sqlDetail As String = "INSERT INTO tb_sales_detail (s_id, p_id, sd_qty, sd_total) VALUES (@sid, @pid, @qty, @total)"
                    Using cmdDetail As New MySqlCommand(sqlDetail, conn)
                        cmdDetail.Parameters.AddWithValue("@sid", saleId)
                        cmdDetail.Parameters.AddWithValue("@pid", productId)
                        cmdDetail.Parameters.AddWithValue("@qty", item.Quantity)
                        cmdDetail.Parameters.AddWithValue("@total", item.Total)
                        cmdDetail.ExecuteNonQuery()
                    End Using
                End If
            Next

            ' === Prepare data for printing ===
            invoiceTable = New DataTable()
            invoiceTable.Columns.Add("Product")
            invoiceTable.Columns.Add("Qty", GetType(Integer))
            invoiceTable.Columns.Add("Price", GetType(Decimal))
            invoiceTable.Columns.Add("Total", GetType(Decimal))

            For Each c In Cart.Values
                invoiceTable.Rows.Add(c.Name, c.Quantity, c.Price, c.Total)
            Next

            ' === Show Print Dialog ===
            PrintDlg.Document = PrintDoc
            PrintDoc.DocumentName = currentInvoiceNo
            If PrintDlg.ShowDialog() = DialogResult.OK Then
                PrintDoc.PrinterSettings = PrintDlg.PrinterSettings
                PrintDoc.Print()
            End If

            MessageBox.Show("Sale saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cart.Clear()
            RefreshCartPanel()
            GenerateInvoiceNo()
            TextBoxCustomerName.Clear()
            TextBoxDiscount.Clear()
            ButtonSearch_Click(Nothing, Nothing)

        Catch ex As Exception
            MessageBox.Show("Checkout Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub PrintDoc_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Dim g As Graphics = e.Graphics
        Dim left As Integer = 60
        Dim y As Integer = 80
        Dim marginBounds = e.MarginBounds
        Dim centerX As Single = marginBounds.Left + marginBounds.Width / 2

        Dim reportTitleFont As New Font("Arial", 20, FontStyle.Bold)
        Dim companyFont As New Font("Arial", 12, FontStyle.Bold)
        Dim infoFont As New Font("Arial", 9)
        Dim smallFont As New Font("Arial", 8)
        Dim headerFont As New Font("Arial", 10, FontStyle.Bold)
        Dim bodyFont As New Font("Arial", 9)
        Dim formatCenter As New StringFormat() With {.Alignment = StringAlignment.Center}
        Dim rightAlign As New StringFormat() With {.Alignment = StringAlignment.Far}

        ' === Logo ===
        Try
            Dim logoPath As String = IO.Path.Combine(Application.StartupPath, "VBlogo.png")
            If IO.File.Exists(logoPath) Then
                Dim logo As Image = Image.FromFile(logoPath)
                g.DrawImage(logo, centerX - 50, 20, 100, 50)
            End If
        Catch
        End Try

        ' === Company Info ===
        g.DrawString("GEARTRACK SDN BHD", companyFont, Brushes.Black, centerX, y, formatCenter)
        g.DrawString("No. 88, Jalan Teknologi, Skudai, Johor", infoFont, Brushes.Black, centerX, y + 20, formatCenter)
        g.DrawString("Tel: +60 13-7323888 | geartrack@gmail.com", infoFont, Brushes.Black, centerX, y + 40, formatCenter)
        y += 80

        ' === Invoice Header ===
        g.DrawString("INVOICE", reportTitleFont, Brushes.Black, centerX, y, formatCenter)
        y += 40
        g.DrawString("Invoice No: " & currentInvoiceNo, bodyFont, Brushes.Black, left, y)
        y += 20
        g.DrawString("Customer: " & customerName, bodyFont, Brushes.Black, left, y)
        y += 20
        g.DrawString("Date: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm"), bodyFont, Brushes.Black, left, y)
        y += 30

        ' === Table Header ===
        g.DrawLine(Pens.Black, left, y, marginBounds.Right, y)
        y += 10
        g.DrawString("Product", headerFont, Brushes.Black, left + 10, y)
        g.DrawString("Qty", headerFont, Brushes.Black, left + 250, y)
        g.DrawString("Price", headerFont, Brushes.Black, left + 330, y)
        g.DrawString("Total", headerFont, Brushes.Black, marginBounds.Right - 10, y, rightAlign)
        y += 20
        g.DrawLine(Pens.Black, left, y, marginBounds.Right, y)
        y += 10

        ' === Items ===
        For Each row As DataRow In invoiceTable.Rows
            g.DrawString(row("Product").ToString(), bodyFont, Brushes.Black, left + 10, y)
            g.DrawString(row("Qty").ToString(), bodyFont, Brushes.Black, left + 260, y)
            g.DrawString("RM " & Format(row("Price"), "0.00"), bodyFont, Brushes.Black, left + 330, y)
            g.DrawString("RM " & Format(row("Total"), "0.00"), bodyFont, Brushes.Black, marginBounds.Right - 10, y, rightAlign)
            y += 20
        Next

        y += 10
        g.DrawLine(Pens.Black, left, y, marginBounds.Right, y)
        y += 30

        ' === Totals ===
        g.DrawString("Subtotal: RM " & subTotal.ToString("0.00"), bodyFont, Brushes.Black, marginBounds.Right - 10, y, rightAlign)
        y += 20
        g.DrawString("Discount: RM " & discountValue.ToString("0.00"), bodyFont, Brushes.Black, marginBounds.Right - 10, y, rightAlign)
        y += 20
        g.DrawString("Total: RM " & totalAmount.ToString("0.00"), headerFont, Brushes.Black, marginBounds.Right - 10, y, rightAlign)
        y += 40

        g.DrawString("Thank you for your purchase!", bodyFont, Brushes.Black, centerX, y, formatCenter)
        y += 20

        g.DrawString("Generated on " & DateTime.Now.ToString("yyyy-MM-dd HH:mm"), smallFont, Brushes.Black, left, e.MarginBounds.Bottom + 30)
    End Sub

End Class

Public Class Product
    Public Property Name As String
    Public Property Price As Decimal
    Public Property ImageData As Byte()
    Public Property Stock As Integer
End Class

Public Class CartItem
    Public Property Name As String
    Public Property Price As Decimal
    Public Property Quantity As Integer
    Public Property ImageData As Byte()
    Public Property Stock As Integer

    Public ReadOnly Property Total As Decimal
        Get
            Return Price * Quantity
        End Get
    End Property
End Class
