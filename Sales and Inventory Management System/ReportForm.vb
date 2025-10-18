Imports Microsoft.VisualBasic.Logging
Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient

Public Class ReportForm
    Private Sub SalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem.Click
        Dim Sales As New SalesForm()
        Sales.Show()
        Me.Close()
    End Sub

    Private Sub InventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventoryToolStripMenuItem.Click
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

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Dim login As New LoginForm()
        login.Show()
        Me.Close()
    End Sub

    Private WithEvents PrintDoc As New PrintDocument
    Private PageSetup As New PageSetupDialog
    Private Preview As New PrintPreviewDialog
    Private PrintDlg As New PrintDialog
    Dim bm As Bitmap
    Private currentPreview As PrintPreviewControl
    Private reportTitle As String = ""
    Private reportData As DataTable

    Private Sub ReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConnectDB()

        PrintDoc.DefaultPageSettings.Landscape = False
        PageSetup.Document = PrintDoc
        Preview.Document = PrintDoc
        PrintDlg.Document = PrintDoc
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles GenerateButton.Click
        Try
            If conn.State = ConnectionState.Closed Then
                ConnectDB()
            End If

            Dim sql As String = "SELECT s.s_invoiceNo AS 'Invoice No',
                       s.s_dateTime AS 'Date & Time',
                       s.s_customer AS 'Customer',
                       p.p_name AS 'Product Name',
                       p.p_sellPrice AS 'Unit Price',
                       d.sd_qty AS 'Quantity',
                       d.sd_total AS 'Subtotal',
                       s.s_total AS 'Total Amount'
                FROM tb_sales s
                INNER JOIN tb_sales_detail d ON s.s_id = d.s_id
                INNER JOIN tb_products p ON d.p_id = p.p_id
                WHERE s.s_dateTime BETWEEN @from AND @to
                ORDER BY s.s_dateTime ASC"

            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@from", FromDateTimePicker.Value.Date)
            cmd.Parameters.AddWithValue("@to", ToDateTimePicker.Value.Date)

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            ReportDataGridView.DataSource = dt

            If dt.Rows.Count = 0 Then
                MessageBox.Show("No records found for the selected date range.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub PrintButton_Click(sender As Object, e As EventArgs) Handles PrintButton.Click
        Try
            If PrintDlg.ShowDialog = DialogResult.OK Then
                PrintDoc.PrinterSettings = PrintDlg.PrinterSettings
                PrintDoc.Print()
            End If
        Catch ex As Exception
            MessageBox.Show("Print Error: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnMonthly_Click(sender As Object, e As EventArgs) Handles SaleReportButton.Click
        reportTitle = "Monthly Sales Report"
        LoadReport("SELECT s.s_invoiceNo AS InvoiceNo, s.s_dateTime AS DateTime, s.s_customer AS Customer, 
                           p.p_name AS ProductName, d.sd_qty AS Quantity, d.sd_total AS Subtotal
                    FROM tb_sales s
                    INNER JOIN tb_sales_detail d ON s.s_id = d.s_id
                    INNER JOIN tb_products p ON d.p_id = p.p_id
                    WHERE MONTH(s.s_dateTime) = MONTH(CURDATE())
                    ORDER BY s.s_dateTime ASC;")
    End Sub

    Private Sub BtnInventory_Click(sender As Object, e As EventArgs) Handles InventoryReportButton.Click
        reportTitle = "Inventory Report"
        LoadReport("SELECT p.p_id AS ProductID, p.p_name AS ProductName, p.p_stock AS StockQty, p.p_sellPrice AS UnitPrice
                    FROM tb_products p
                    ORDER BY p.p_name ASC;")
    End Sub

    Private Sub InventoryTrackingButton_Click(sender As Object, e As EventArgs) Handles InventoryTrackingButton.Click
        reportTitle = "Inventory Tracking Report"
        ' Havent change
        LoadReport("SELECT p.p_id AS ProductID, p.p_name AS ProductName, p.p_stock AS StockQty, p.p_sellPrice AS UnitPrice
                    FROM tb_products p
                    ORDER BY p.p_name ASC;")
    End Sub

    '=== General Loading Report ===
    Private Sub LoadReport(query As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim cmd As New MySqlCommand(query, conn)
            Dim da As New MySqlDataAdapter(cmd)
            reportData = New DataTable()
            da.Fill(reportData)
            conn.Close()

            If reportData.Rows.Count = 0 Then
                MessageBox.Show("No data found for this report.")
                Exit Sub
            End If

            ' Print Report
            AddHandler PrintDoc.PrintPage, AddressOf PrintDoc_PrintPage

            currentPreview = New PrintPreviewControl() With {
                .Document = PrintDoc,
                .Dock = DockStyle.Fill,
                .Zoom = 1.0
            }

            ReportPanel.Controls.Clear()
            ReportPanel.Controls.Add(currentPreview)
            currentPreview.Refresh()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    Private Sub PrintDoc_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)
        Dim g As Graphics = e.Graphics
        Dim left As Integer = 60
        Dim y As Integer = 80
        Dim centerX As Single = CInt((e.PageBounds.Width - 120) / 2)

        '=== Font ===
        Dim titleFont As New Font("Arial", 16, FontStyle.Bold)
        Dim infoFont As New Font("Arial", 10)
        Dim smallFont As New Font("Arial", 8)
        Dim formatCenter As New StringFormat() With {.Alignment = StringAlignment.Center}

        '=== LOGO ===
        Try
            Dim logoPath As String = IO.Path.Combine(Application.StartupPath, "VBlogo.png")
            If IO.File.Exists(logoPath) Then
                Dim logo As Image = Image.FromFile(logoPath)
                g.DrawImage(logo, CInt((e.PageBounds.Width - 120) / 2), 20, 120, 60)
            End If
        Catch
            g.DrawString("LOGO MISSING", infoFont, Brushes.Red, centerX, 30, formatCenter)
        End Try

        '=== COmpany Info ===
        g.DrawString("GEARTRACK", titleFont, Brushes.Black, centerX, y, formatCenter)
        g.DrawString("No. 88, Jalan Teknologi, Skudai, Johor, Malaysia", infoFont, Brushes.Black, centerX, y + 25, formatCenter)
        g.DrawString("Tel: +60 13-7323888 | Email: geartrack@gmail.com", infoFont, Brushes.Black, centerX, y + 45, formatCenter)

        y += 90
        g.DrawString(reportTitle, titleFont, Brushes.Black, centerX, y, formatCenter)
        y += 40

        '=== (保留数据库读取，但不显示内容) ===
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd As New MySqlCommand("SELECT * FROM tb_products", conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            ' 这里只是读，不绘制内容
            While reader.Read()
                ' 暂不打印数据
            End While
            reader.Close()
            conn.Close()
        Catch ex As Exception
            g.DrawString("Database Error: " & ex.Message, infoFont, Brushes.Red, centerX, y + 30, formatCenter)
        End Try

        '=== Footer ===
        g.DrawString("Generated on " & DateTime.Now.ToString("yyyy-MM-dd HH:mm"), smallFont, Brushes.Black, left, e.MarginBounds.Bottom + 30)
    End Sub
End Class