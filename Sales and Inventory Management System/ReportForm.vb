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

    Private Sub SaleReportButton_Click(sender As Object, e As EventArgs) Handles SaleReportButton.Click
        reportTitle = "Sales Report"
        LoadReport("
        SELECT 
            s.s_invoiceNo AS InvoiceNo,
            s.s_dateTime AS DateTime,
            s.s_customer AS Customer,
            p.p_name AS ProductName,
            d.sd_qty AS Quantity,
            d.sd_total AS Subtotal
        FROM tb_sales s
        INNER JOIN tb_sales_detail d ON s.s_id = d.s_id
        INNER JOIN tb_products p ON d.p_id = p.p_id
    ")
    End Sub

    Private Sub InventoryReportButton_Click(sender As Object, e As EventArgs) Handles InventoryReportButton.Click
        reportTitle = "Inventory Report"
        LoadReport("
        SELECT 
            p.p_id AS ProductID,
            p.p_name AS ProductName,
            p.p_stock AS StockQty,
            p.p_sellPrice AS UnitPrice
        FROM tb_products p
        ORDER BY p.p_name ASC
    ")
    End Sub

    Private Sub InventoryTrackingButton_Click(sender As Object, e As EventArgs) Handles InventoryTrackingButton.Click
        reportTitle = "Inventory Tracking Report"
        LoadReport("
        SELECT 
            p.p_id AS ProductID,
            p.p_name AS ProductName,
            t.im_dateTime AS LastUpdate,
            t.im_qtyChange AS QuantityMoved,
            t.im_note AS Remark
        FROM tb_products p
        INNER JOIN tb_inventorymovements t ON p.p_id = t.p_id
    ")
    End Sub


    '=== General Loading Report ===
    Private Sub LoadReport(query As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' === 日期栏位根据报表类型自动选择 ===
            Dim dateColumn As String = ""
            If reportTitle.Contains("Sales") Then
                dateColumn = "s.s_dateTime"
            ElseIf reportTitle.Contains("Inventory Tracking") Then
                dateColumn = "t.im_dateTime"
            End If

            ' === 加入日期范围过滤 ===
            If dateColumn <> "" Then
                ' 先移除尾部的分号，避免拼接错误
                If query.Trim().EndsWith(";") Then
                    query = query.Trim().Substring(0, query.Trim().Length - 1)
                End If

                ' 如果 query 里已经有 WHERE，就加 AND；否则加 WHERE
                If query.ToUpper().Contains("WHERE") Then
                    query &= $" AND {dateColumn} BETWEEN @from AND @to"
                Else
                    query &= $" WHERE {dateColumn} BETWEEN @from AND @to"
                End If

                ' 确保 ORDER BY 放在最后
                If Not query.ToUpper().Contains("ORDER BY") Then
                    query &= $" ORDER BY {dateColumn} ASC"
                End If

                query &= ";"
            End If

            ' === 执行 SQL ===
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@from", FromDateTimePicker.Value.Date)
            cmd.Parameters.AddWithValue("@to", ToDateTimePicker.Value.Date.AddDays(1).AddSeconds(-1))

            Dim da As New MySqlDataAdapter(cmd)
            reportData = New DataTable()
            da.Fill(reportData)
            conn.Close()

            If reportData.Rows.Count = 0 Then
                MessageBox.Show("No data found for the selected date range.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ' === Print Preview ===
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
            MessageBox.Show("Error: " & ex.Message, "Load Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub PrintDoc_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)
        Dim g As Graphics = e.Graphics
        Dim left As Integer = 60
        Dim y As Integer = 80
        Dim marginBounds = e.MarginBounds
        Dim centerX As Single = marginBounds.Left + marginBounds.Width / 2

        '=== Font ===
        Dim reportTitleFont As New Font("Arial", 23, FontStyle.Bold)
        Dim companyFont As New Font("Arial", 14, FontStyle.Bold)
        Dim companyTitleFont As New Font("Arial", 12, FontStyle.Bold)
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
        g.DrawString("GEARTRACK SDN BHD", companyTitleFont, Brushes.Black, centerX, y + 5, formatCenter)
        g.DrawString("No. 88, Jalan Teknologi, Skudai, Johor, Malaysia", infoFont, Brushes.Black, centerX, y + 30, formatCenter)
        g.DrawString("Tel: +60 13-7323888 | Email: geartrack@gmail.com", infoFont, Brushes.Black, centerX, y + 50, formatCenter)

        y += 90
        g.DrawString(reportTitle, reportTitleFont, Brushes.Black, centerX, y, formatCenter)
        y += 40

        ' Invoke database based on reportTitle
        If reportTitle = "Sales Report" Then
            DrawSalesReport(g, marginBounds)
        ElseIf reportTitle = "Inventory Report" Then
            DrawInventoryReport(g, marginBounds)
        Else
            DrawInventoryTracking(g, marginBounds)
        End If

        '=== Footer ===
        g.DrawString("Generated on " & DateTime.Now.ToString("yyyy-MM-dd HH:mm"), smallFont, Brushes.Black, left, e.MarginBounds.Bottom + 30)
    End Sub

    Private Sub DrawSalesReport(g As Graphics, marginBounds As RectangleF)
        ' === 字体 ===
        Dim headerFont As New Font("Arial", 10, FontStyle.Bold)
        Dim bodyFont As New Font("Arial", 9)
        Dim smallFont As New Font("Arial", 8)

        ' === 表格居中 ===
        Dim tableWidth As Integer = 700
        Dim tableLeft As Integer = CInt((marginBounds.Left + marginBounds.Right - tableWidth) / 2)
        Dim tableTop As Integer = marginBounds.Top + 150

        ' === 列锚点 ===
        Dim colX() As Integer = {
        tableLeft,           ' Invoice
        tableLeft + 130,     ' Date
        tableLeft + 260,     ' Customer
        tableLeft + 390,     ' Product
        tableLeft + 510,     ' Qty
        tableLeft + 620      ' Subtotal
    }

        ' === 表格右边界（Subtotal 右对齐用）===
        Dim rightEdge As Integer = tableLeft + tableWidth - 15

        ' === 对齐格式 ===
        Dim centerAlign As New StringFormat() With {.Alignment = StringAlignment.Center}
        Dim rightAlign As New StringFormat() With {.Alignment = StringAlignment.Far}

        ' === 表头 ===
        g.DrawLine(Pens.Black, tableLeft, tableTop, tableLeft + tableWidth, tableTop)
        Dim headers() As String = {"Invoice", "Date & Time", "Customer", "Product", "Qty", "Subtotal"}

        For i As Integer = 0 To headers.Length - 1
            If i = headers.Length - 1 Then
                g.DrawString(headers(i), headerFont, Brushes.Black, CInt(rightEdge), tableTop + 5, rightAlign)
            Else
                Dim nextX As Integer = colX(i + 1)
                Dim xCenter As Integer = CInt((colX(i) + nextX) / 2)
                g.DrawString(headers(i), headerFont, Brushes.Black, xCenter, tableTop + 5, centerAlign)
            End If
        Next

        g.DrawLine(Pens.Black, tableLeft, tableTop + 25, tableLeft + tableWidth, tableTop + 25)

        ' === 内容 ===
        Dim currentY As Integer = tableTop + 40
        Dim lineHeight As Integer = 30
        Dim totalQty As Integer = 0
        Dim totalAmount As Decimal = 0

        If reportData IsNot Nothing AndAlso reportData.Rows.Count > 0 Then
            For Each r As DataRow In reportData.Rows
                Try
                    Dim invoice As String = r("InvoiceNo").ToString()
                    Dim dt As String = r("DateTime").ToString()
                    Dim cust As String = r("Customer").ToString()
                    Dim prod As String = r("ProductName").ToString()

                    ' 去括号里的文字
                    If prod.Contains("("c) Then prod = prod.Substring(0, prod.IndexOf("("c)).Trim()

                    ' 格式化日期
                    Dim parsed As DateTime
                    If DateTime.TryParse(dt, parsed) Then dt = parsed.ToString("dd/MM/yy HH:mm")

                    ' 截断过长
                    If cust.Length > 18 Then cust = cust.Substring(0, 18) & "..."
                    If prod.Length > 18 Then prod = prod.Substring(0, 18) & "..."

                    Dim qty As Integer = CInt(r("Quantity"))
                    Dim subtotal As Decimal = CDec(r("Subtotal"))

                    ' 居中列绘制
                    g.DrawString(invoice, bodyFont, Brushes.Black, CInt((colX(0) + colX(1)) / 2), currentY, centerAlign)
                    g.DrawString(dt, smallFont, Brushes.Black, CInt((colX(1) + colX(2)) / 2), currentY, centerAlign)
                    g.DrawString(cust, bodyFont, Brushes.Black, CInt((colX(2) + colX(3)) / 2), currentY, centerAlign)
                    g.DrawString(prod, bodyFont, Brushes.Black, CInt((colX(3) + colX(4)) / 2), currentY, centerAlign)
                    g.DrawString(qty.ToString(), bodyFont, Brushes.Black, CInt((colX(4) + colX(5)) / 2), currentY, centerAlign)

                    ' Subtotal 右对齐
                    g.DrawString(subtotal.ToString("0.00"), bodyFont, Brushes.Black, CInt(rightEdge), currentY, rightAlign)

                    totalQty += qty
                    totalAmount += subtotal
                    currentY += lineHeight
                Catch
                    ' 忽略空行
                End Try
            Next
        Else
            g.DrawString("No data found.", bodyFont, Brushes.Red, CInt(tableLeft + tableWidth / 2), tableTop + 60, centerAlign)
        End If

        ' === 底部合计 ===
        currentY += 5
        g.DrawLine(Pens.Black, tableLeft, currentY, tableLeft + tableWidth, currentY)
        currentY += 20

        g.DrawString("Total:", headerFont, Brushes.Black, CInt((colX(3) + colX(4)) / 2), currentY, centerAlign)
        g.DrawString(totalQty.ToString(), headerFont, Brushes.Black, CInt((colX(4) + colX(5)) / 2), currentY, centerAlign)
        g.DrawString(totalAmount.ToString("0.00"), headerFont, Brushes.Black, CInt(rightEdge), currentY, rightAlign)
    End Sub



    Private Sub DrawInventoryReport(g As Graphics, marginBounds As RectangleF)
        Dim headerFont As New Font("Arial", 10, FontStyle.Bold)
        Dim bodyFont As New Font("Arial", 9)
        Dim leftMargin As Integer = marginBounds.Left
        Dim tableTop As Integer = marginBounds.Top + 230

        Dim colX() As Integer = {leftMargin, leftMargin + 150, leftMargin + 350, leftMargin + 450}

        ' 表头
        g.DrawLine(Pens.Black, leftMargin, tableTop, colX.Last + 70, tableTop)
        Dim headers() As String = {"Product ID", "Product Name", "Stock Qty", "Unit Price"}
        For i As Integer = 0 To headers.Length - 1
            g.DrawString(headers(i), headerFont, Brushes.Black, colX(i), tableTop + 5)
        Next
        g.DrawLine(Pens.Black, leftMargin, tableTop + 25, colX.Last + 70, tableTop + 25)

        ' 数据
        Dim currentY As Integer = tableTop + 35
        For Each r As DataRow In reportData.Rows
            g.DrawString(r("ProductID").ToString(), bodyFont, Brushes.Black, colX(0), currentY)
            g.DrawString(r("ProductName").ToString(), bodyFont, Brushes.Black, colX(1), currentY)
            g.DrawString(r("StockQty").ToString(), bodyFont, Brushes.Black, colX(2), currentY)
            g.DrawString(Format(CDec(r("UnitPrice")), "0.00"), bodyFont, Brushes.Black, colX(3), currentY)
            currentY += 20
        Next
    End Sub

    Private Sub DrawInventoryTracking(g As Graphics, marginBounds As RectangleF)
        Dim headerFont As New Font("Arial", 10, FontStyle.Bold)
        Dim bodyFont As New Font("Arial", 9)
        Dim leftMargin As Integer = marginBounds.Left
        Dim tableTop As Integer = marginBounds.Top + 230

        Dim colX() As Integer = {leftMargin, leftMargin + 150, leftMargin + 350, leftMargin + 500}
        Dim headers() As String = {"Product ID", "Product Name", "Last Update", "Quantity Moved"}

        ' 表头
        g.DrawLine(Pens.Black, leftMargin, tableTop, colX.Last + 70, tableTop)
        For i As Integer = 0 To headers.Length - 1
            g.DrawString(headers(i), headerFont, Brushes.Black, colX(i), tableTop + 5)
        Next
        g.DrawLine(Pens.Black, leftMargin, tableTop + 25, colX.Last + 70, tableTop + 25)

        ' 数据
        Dim currentY As Integer = tableTop + 35
        For Each r As DataRow In reportData.Rows
            g.DrawString(r("ProductID").ToString(), bodyFont, Brushes.Black, colX(0), currentY)
            g.DrawString(r("ProductName").ToString(), bodyFont, Brushes.Black, colX(1), currentY)
            g.DrawString(r("LastUpdate").ToString(), bodyFont, Brushes.Black, colX(2), currentY)
            g.DrawString(r("QuantityMoved").ToString(), bodyFont, Brushes.Black, colX(3), currentY)
            currentY += 20
        Next
    End Sub

End Class