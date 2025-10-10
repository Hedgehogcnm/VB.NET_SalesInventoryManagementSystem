Imports System.Drawing.Printing
Imports Microsoft.VisualBasic.Logging
Imports MySql.Data.MySqlClient

Public Class ReportForm
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

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Dim login As New LoginForm()
        login.Show()
        Me.Close()
    End Sub

    Dim bm As Bitmap

    Private Sub frmSalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConnectDB()
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

    ' 🔹 打印报表
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles PrintButton.Click
        Try
            ' 建立 PrintDocument 物件
            Dim pd As New PrintDocument
            AddHandler pd.PrintPage, AddressOf Me.PrintPageHandler

            ' 打印预览
            Dim dlg As New PrintPreviewDialog
            dlg.Document = pd
            dlg.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Print Error: " & ex.Message)
        End Try
    End Sub

    Private Sub PrintPageHandler(sender As Object, e As Printing.PrintPageEventArgs)
        '=== 绘制 DataGridView ===
        bm = New Bitmap(Me.ReportDataGridView.Width, Me.ReportDataGridView.Height)
        ReportDataGridView.DrawToBitmap(bm, New Rectangle(0, 0, ReportDataGridView.Width, ReportDataGridView.Height))

        '=== 字体设定 ===
        Dim titleFont As New Font("Arial", 16, FontStyle.Bold)
        Dim companyFont As New Font("Arial", 14, FontStyle.Bold)
        Dim infoFont As New Font("Arial", 10, FontStyle.Regular)
        Dim smallFont As New Font("Arial", 8, FontStyle.Regular)

        '=== 设置文字居中用的格式 ===
        Dim formatCenter As New StringFormat()
        formatCenter.Alignment = StringAlignment.Center
        formatCenter.LineAlignment = StringAlignment.Center

        '=== 页面中心 X 位置 ===
        Dim centerX As Single = e.PageBounds.Width / 2

        '=== 插入 Logo 图片 ===
        Try
            Dim logoPath As String = Application.StartupPath & "\VBlogo.png"
            logoPath = IO.Path.GetFullPath(logoPath)

            If IO.File.Exists(logoPath) Then
                Dim original As Image = Image.FromFile(logoPath)
                Dim logo As New Bitmap(original.Width, original.Height)
                Using g As Graphics = Graphics.FromImage(logo)
                    g.Clear(Color.White)
                    g.DrawImage(original, 0, 0, original.Width, original.Height)
                End Using

                ' 高质量绘图防模糊
                e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality

                ' 居中 Logo
                Dim logoWidth As Integer = 180
                Dim logoHeight As Integer = 90
                Dim logoX As Integer = (e.PageBounds.Width - logoWidth) \ 2
                e.Graphics.DrawImage(logo, logoX, 30, logoWidth, logoHeight)
            Else
                e.Graphics.DrawString("⚠ Logo not found", infoFont, Brushes.Red, centerX, 50, formatCenter)
            End If
        Catch ex As Exception
            e.Graphics.DrawString("⚠ Error loading logo: " & ex.Message, infoFont, Brushes.Red, centerX, 50, formatCenter)
        End Try

        '=== 公司信息（居中对齐） ===
        Dim companyName As String = "GEARTRACK"
        Dim companyAddr As String = "No. 88, Jalan Teknologi, Skudai, Johor, Malaysia"
        Dim companyContact As String = "Tel: +60 13-7323888  |  Email: geartrack@gmail.com"

        Dim textY As Integer = 140
        e.Graphics.DrawString(companyName, companyFont, Brushes.Black, centerX, textY, formatCenter)
        e.Graphics.DrawString(companyAddr, infoFont, Brushes.Black, centerX, textY + 25, formatCenter)
        e.Graphics.DrawString(companyContact, infoFont, Brushes.Black, centerX, textY + 45, formatCenter)

        '=== 报表标题（居中） ===
        e.Graphics.DrawString("Inventory Report", titleFont, Brushes.Black, centerX, textY + 85, formatCenter)

        '=== 日期区间（居中） ===
        e.Graphics.DrawString("From: " & FromDateTimePicker.Text & "    To: " & ToDateTimePicker.Text, infoFont, Brushes.Black, centerX, textY + 110, formatCenter)

        '=== 打印 DataGridView ===
        e.Graphics.DrawImage(bm, 50, textY + 140)

        '=== 页脚信息（左下角） ===
        e.Graphics.DrawString("Generated on " & DateTime.Now.ToString("yyyy-MM-dd HH:mm"), smallFont, Brushes.Black, 50, e.MarginBounds.Bottom + 30)
    End Sub


End Class