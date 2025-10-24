Imports System.Drawing.Drawing2D
Imports LiveCharts
Imports LiveCharts.WinForms
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class AdminDashboardForm
    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click
        Dim frm As New AdminReportForm()
        frm.Show()
        Me.Close()
    End Sub

    Private Sub DashboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashboardToolStripMenuItem.Click
        Dim frm As New AdminDashboardForm()
        frm.Show()
        Me.Close()
    End Sub

    Private Sub AboutUsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutUsToolStripMenuItem.Click
        Dim aboutbox As New AboutBox
        aboutbox.Show()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Dim login As New LoginForm
        login.Show()
        Close()
    End Sub

    Private Sub AdminDashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Apply rounded corners to panels
        RoundifyPanel(ChartPanel)
        RoundifyPanel(SupplierPanel)
        RoundifyPanel(ProductPanel)
        RoundifyPanel(UserPanel)

        ' === Create and configure chart ===
        Dim chart As New LiveCharts.WinForms.CartesianChart() With {.Dock = DockStyle.Fill}

        Dim months = {"Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct"}
        Dim expenses As Double() = {2800, 1500, 2000, 32000, 25000, 27000, 30000}
        Dim profits As Double() = {2200, 1800, 2300, 19000, 26000, 31000, 35000}

        chart.Series = New SeriesCollection From {
            New LiveCharts.Wpf.LineSeries With {
                .Title = "Expense",
                .Values = New ChartValues(Of Double)(expenses)
            },
            New LiveCharts.Wpf.LineSeries With {
                .Title = "Profit",
                .Values = New ChartValues(Of Double)(profits)
            }
        }

        chart.AxisX.Add(New LiveCharts.Wpf.Axis With {.Labels = months})
        chart.AxisY.Add(New LiveCharts.Wpf.Axis With {.Title = "RM"})

        ' Add chart into ChartPanel
        ChartPanel.Controls.Add(chart)
        chart.Dock = DockStyle.Fill

        LoadUserPanel()
        LoadProductPanel()
        LoadSuppliers()
    End Sub

    ' === When UserPanel is clicked, open AddUserForm ===
    Private Sub UserPanel_Click(sender As Object, e As EventArgs) Handles UserPanel.Click
        Dim frm As New AddUserForm()
        frm.ShowDialog()
    End Sub
    Private Sub LoadSuppliers()
        Try
            ConnectDB()
            Dim sql As String = "SELECT sup_id, sup_name, sup_contact, sup_email, status, logo_image FROM tb_suppliers"
            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            conn.Close()

            SupplierPanel.Controls.Clear()  ' Clear previous controls

            ' === Flow Panel Settings ===
            With SupplierPanel
                .AutoScroll = True
                .WrapContents = False
                .FlowDirection = FlowDirection.TopDown
                .BackColor = Color.WhiteSmoke
            End With

            ' === HEADER ===
            Dim headerPanel As New Panel With {
            .Width = SupplierPanel.Width - 30,
            .Height = 50,
            .BackColor = Color.FromArgb(255, 236, 214),
            .Margin = New Padding(5)
        }

            Dim columnWidths() As Integer = {230, 360, 360, 300, 200}
            Dim headers() As String = {"Company Logo", "Supplier Name", "Email", "Contact", "Status"}

            Dim colX(headers.Length - 1) As Integer
            colX(0) = 10
            For i As Integer = 1 To headers.Length - 1
                colX(i) = colX(i - 1) + columnWidths(i - 1)
            Next

            For i As Integer = 0 To headers.Length - 1
                Dim lbl As New Label With {
                .Text = headers(i),
                .Font = New Font("Segoe UI", 10, FontStyle.Bold),
                .ForeColor = Color.Black,
                .AutoSize = False,
                .Width = columnWidths(i),
                .Height = 40,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Location = New Point(colX(i), 5),
                .BackColor = Color.FromArgb(255, 236, 214)
            }
                headerPanel.Controls.Add(lbl)
            Next

            SupplierPanel.Controls.Add(headerPanel)

            ' === ROWS ===
            For Each row As DataRow In dt.Rows
                Dim rowPanel As New Panel With {
                .Width = SupplierPanel.Width - 30,
                .Height = 80,
                .BackColor = Color.White,
                .Margin = New Padding(3)
            }

                ' === Company Logo ===
                Dim logoBox As New PictureBox With {
                .Width = columnWidths(0) - 60,
                .Height = 70,
                .SizeMode = PictureBoxSizeMode.Zoom,
                .Location = New Point(colX(0) + 30, 5)
            }

                Try
                    If Not IsDBNull(row("logo_image")) Then
                        Dim imgData() As Byte = DirectCast(row("logo_image"), Byte())
                        Using ms As New IO.MemoryStream(imgData)
                            logoBox.Image = Image.FromStream(ms)
                        End Using
                    Else
                        logoBox.BackColor = Color.LightGray
                    End If
                Catch
                    logoBox.BackColor = Color.LightGray
                End Try
                rowPanel.Controls.Add(logoBox)

                ' === Supplier Details ===
                Dim values() As String = {
                row("sup_name").ToString(),
                row("sup_email").ToString(),
                row("sup_contact").ToString(),
                row("status").ToString()
            }

                For i As Integer = 0 To values.Length - 1
                    Dim lbl As New Label With {
                    .Text = values(i),
                    .Font = New Font("Segoe UI", 9),
                    .ForeColor = If(i = 3 AndAlso values(i).ToLower() = "active", Color.SeaGreen,
                                   If(i = 3, Color.Gray, Color.Black)),
                    .AutoSize = False,
                    .Width = columnWidths(i + 1),
                    .Height = 40,
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Location = New Point(colX(i + 1), 20)
                }
                    rowPanel.Controls.Add(lbl)
                Next

                SupplierPanel.Controls.Add(rowPanel)
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading suppliers: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub LoadProductPanel()
        Try
            ' === Connect Database ===
            ConnectDB()

            Dim sql As String =
                "SELECT p.p_id, p.sup_id, s.sup_name, p.p_name, p.p_category, p.p_stock, 
                        p.p_minStock, p.p_costPrice, p.p_sellPrice, p.p_image
                 FROM tb_products p
                 LEFT JOIN tb_suppliers s ON p.sup_id = s.sup_id"

            Dim cmd As New MySqlCommand(sql, conn)
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            conn.Close()

            ProductPanel.Controls.Clear()

            ' === No Data Found ===
            If dt.Rows.Count = 0 Then
                Dim noDataLbl As New Label With {
                    .Text = "😕 No products found.",
                    .Font = New Font("Segoe UI", 11, FontStyle.Italic),
                    .ForeColor = Color.Gray,
                    .AutoSize = True,
                    .Margin = New Padding(20)
                }
                ProductPanel.Controls.Add(noDataLbl)
                Exit Sub
            End If

            ' === Display Each Product ===
            For Each row As DataRow In dt.Rows
                Dim productCard As New Panel With {
                    .Width = ProductPanel.Width - 35,
                    .Height = 100,
                    .BackColor = Color.White,
                    .Margin = New Padding(5)
                }

                Dim productID As Integer = Convert.ToInt32(row("p_id"))
                Dim productName As String = row("p_name").ToString()
                Dim stock As Integer = Convert.ToInt32(row("p_stock"))
                Dim minStock As Integer = Convert.ToInt32(row("p_minStock"))

                ' 🔴 Highlight low stock
                If stock <= minStock Then productCard.BackColor = Color.MistyRose

                ' === Product Image ===
                Dim pic As New PictureBox With {
                    .Width = 70,
                    .Height = 70,
                    .Location = New Point(15, 15),
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
                productCard.Controls.Add(pic)

                ' === Product Details ===
                Dim detailsFont As New Font("Segoe UI", 9)
                Dim boldFont As New Font("Segoe UI", 9, FontStyle.Bold)
                Dim xPos As Integer = 100
                Dim yBase As Integer = 15

                ' Product ID + Name
                Dim lblName As New Label With {
                    .Text = $"{productName}",
                    .Font = boldFont,
                    .AutoSize = False,
                    .Width = 250,
                    .Height = 25,
                    .Location = New Point(xPos, yBase)
                }
                productCard.Controls.Add(lblName)

                ' Supplier & Category
                Dim supplierText As String = If(IsDBNull(row("sup_name")), "N/A", row("sup_name").ToString())
                Dim lblSupCat As New Label With {
                    .Text = $"{supplierText}  •  {row("p_category")}",
                    .Font = detailsFont,
                    .ForeColor = Color.DimGray,
                    .AutoSize = False,
                    .Width = 300,
                    .Height = 20,
                    .Location = New Point(xPos, yBase + 25)
                }
                productCard.Controls.Add(lblSupCat)

                ' Stock info
                Dim lblStock As New Label With {
                    .Text = $"Stock: {stock}  |  Min: {minStock}",
                    .Font = detailsFont,
                    .ForeColor = Color.Black,
                    .AutoSize = False,
                    .Width = 200,
                    .Height = 20,
                    .Location = New Point(xPos + 310, yBase)
                }
                productCard.Controls.Add(lblStock)

                ' Prices
                Dim lblPrice As New Label With {
                    .Text = $"Cost: {FormatCurrency(row("p_costPrice"), 2)}  |  Sell: {FormatCurrency(row("p_sellPrice"), 2)}",
                    .Font = detailsFont,
                    .ForeColor = Color.DarkGreen,
                    .AutoSize = False,
                    .Width = 250,
                    .Height = 20,
                    .Location = New Point(xPos + 310, yBase + 25)
                }
                productCard.Controls.Add(lblPrice)

                ' Add to FlowLayoutPanel
                ProductPanel.Controls.Add(productCard)
            Next

        Catch ex As Exception
            MessageBox.Show("❌ Error loading products: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub


    ' === Rounded corners helper ===
    Private Sub RoundifyPanel(pnl As Panel)
        Dim radius As Integer = 20
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(New Rectangle(0, 0, radius, radius), 180, 90)
        path.AddArc(New Rectangle(pnl.Width - radius, 0, radius, radius), 270, 90)
        path.AddArc(New Rectangle(pnl.Width - radius, pnl.Height - radius, radius, radius), 0, 90)
        path.AddArc(New Rectangle(0, pnl.Height - radius, radius, radius), 90, 90)
        path.CloseFigure()
        pnl.Region = New Region(path)
    End Sub


    Private Sub LoadUserPanel()
        ' === Database Connection ===
        Dim connStr As String = "server=localhost;user=root;password=;database=db_sales_inventory_management_system;"
        Dim query As String = "SELECT u_id, u_name, u_role FROM tb_users"

        Dim dt As New DataTable()
        Using conn As New MySqlConnection(connStr)
            conn.Open()
            Using da As New MySqlDataAdapter(query, conn)
                da.Fill(dt)
            End Using
        End Using

        ' === Clear panel ===
        UserPanel.Controls.Clear()

        ' === Create a vertical layout (for title + table) ===
        Dim mainLayout As New TableLayoutPanel()
        mainLayout.Dock = DockStyle.Fill
        mainLayout.BackColor = Color.White
        mainLayout.RowCount = 2
        mainLayout.ColumnCount = 1
        mainLayout.RowStyles.Add(New RowStyle(SizeType.Absolute, 50)) ' Title
        mainLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 100)) ' Table
        mainLayout.Padding = New Padding(10)

        ' === Add Title ===
        Dim titleLbl As New Label()
        titleLbl.Text = "User List"
        titleLbl.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        titleLbl.ForeColor = Color.FromArgb(60, 60, 60)
        titleLbl.TextAlign = ContentAlignment.MiddleCenter
        titleLbl.Dock = DockStyle.Fill
        mainLayout.Controls.Add(titleLbl, 0, 0)

        ' === Create Table ===
        Dim table As New TableLayoutPanel()
        table.Dock = DockStyle.Fill
        table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        table.ColumnCount = 3
        table.RowCount = dt.Rows.Count + 1
        table.BackColor = Color.White
        table.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20))
        table.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50))
        table.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30))

        ' === Header Row ===
        AddCell(table, "User ID", True, 0, 0)
        AddCell(table, "User Name", True, 1, 0)
        AddCell(table, "Role", True, 2, 0)

        ' === Fill Rows ===
        Dim r As Integer = 1
        For Each row As DataRow In dt.Rows
            AddCell(table, row("u_id").ToString(), False, 0, r)
            AddCell(table, row("u_name").ToString(), False, 1, r)
            AddCell(table, row("u_role").ToString(), False, 2, r)
            r += 1
        Next

        mainLayout.Controls.Add(table, 0, 1)
        UserPanel.Controls.Add(mainLayout)
    End Sub

    ' === Helper Function for Table Cells ===
    Private Sub AddCell(table As TableLayoutPanel, text As String, isHeader As Boolean, col As Integer, row As Integer)
        Dim lbl As New Label()
        lbl.Text = text
        lbl.Dock = DockStyle.Fill
        lbl.TextAlign = ContentAlignment.MiddleCenter
        lbl.AutoSize = False
        lbl.Margin = New Padding(0)

        If isHeader Then
            lbl.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            lbl.BackColor = Color.FromArgb(255, 236, 214)  ' soft orange
        Else
            lbl.Font = New Font("Segoe UI", 10, FontStyle.Regular)
            lbl.BackColor = Color.White
        End If

        table.Controls.Add(lbl, col, row)
    End Sub


End Class
