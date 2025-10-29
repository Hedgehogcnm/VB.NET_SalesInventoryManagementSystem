Imports System.Drawing.Drawing2D
Imports System.IO
Imports LiveCharts
Imports LiveCharts.WinForms
Imports LiveCharts.Wpf
Imports MySql.Data.MySqlClient

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
        aboutbox.ShowDialog()
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

        LoadUserPanel()
        LoadProductPanel()
        LoadSuppliers()
        LoadChartPanel()
    End Sub

    Private Sub LoadChartPanel()
        Try
            ' === Connect to database ===
            ConnectDB()

            ' === Step 1: Get monthly total expenses from tb_orders ===
            Dim expenseQuery As String = "
            SELECT DATE_FORMAT(o_dateTime, '%b') AS monthName, 
                   SUM(o_total) AS totalExpense
            FROM tb_orders
            WHERE o_status = 'ordered' OR o_status = 'received'
            GROUP BY YEAR(o_dateTime), MONTH(o_dateTime)
            ORDER BY YEAR(o_dateTime), MONTH(o_dateTime);"

            Dim expensesDict As New Dictionary(Of String, Double)
            Using cmd As New MySqlCommand(expenseQuery, conn)
                Using rdr As MySqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        expensesDict(rdr("monthName").ToString()) = Convert.ToDouble(rdr("totalExpense"))
                    End While
                End Using
            End Using

            ' === Step 2: Get monthly total profit (sales) from tb_sales ===
            Dim profitQuery As String = "
            SELECT DATE_FORMAT(s_dateTime, '%b') AS monthName, 
                   SUM(s_total) AS totalProfit
            FROM tb_sales
            GROUP BY YEAR(s_dateTime), MONTH(s_dateTime)
            ORDER BY YEAR(s_dateTime), MONTH(s_dateTime);"

            Dim profitsDict As New Dictionary(Of String, Double)
            Using cmd As New MySqlCommand(profitQuery, conn)
                Using rdr As MySqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        profitsDict(rdr("monthName").ToString()) = Convert.ToDouble(rdr("totalProfit"))
                    End While
                End Using
            End Using

            ' === Step 3: Determine all months that appear in either table ===
            Dim allMonths = expensesDict.Keys.Union(profitsDict.Keys).ToList()
            allMonths.Sort(Function(a, b) DateTime.ParseExact(a, "MMM", Nothing).Month.CompareTo(DateTime.ParseExact(b, "MMM", Nothing).Month))

            ' === Step 4: Build data arrays ===
            Dim expenseValues As New ChartValues(Of Double)
            Dim profitValues As New ChartValues(Of Double)

            For Each m In allMonths
                expenseValues.Add(If(expensesDict.ContainsKey(m), expensesDict(m), 0))
                profitValues.Add(If(profitsDict.ContainsKey(m), profitsDict(m), 0))
            Next

            ' === Step 5: Create chart ===
            ChartPanel.Controls.Clear()

            Dim chart As New LiveCharts.WinForms.CartesianChart() With {
            .Dock = DockStyle.Fill
        }

            chart.Series = New SeriesCollection From {
            New LineSeries With {.Title = "Expense", .Values = expenseValues, .DataLabels = False, .LabelPoint = Function(point) ""},
            New LineSeries With {.Title = "Profit", .Values = profitValues, .DataLabels = False, .LabelPoint = Function(point) ""}
        }

            chart.AxisX.Add(New Axis With {.Title = "Month", .Labels = allMonths, .FontSize = 14})
            chart.AxisY.Add(New Axis With {.Title = "Amount (RM)", .FontSize = 14})

            ' === Step 6: Add title ===
            Dim titleLbl As New Label()
            titleLbl.Text = "Expense vs Profit"
            titleLbl.Font = New Font("Segoe UI", 14, FontStyle.Bold)
            titleLbl.ForeColor = Color.FromArgb(60, 60, 60)
            titleLbl.TextAlign = ContentAlignment.MiddleCenter
            titleLbl.Dock = DockStyle.Top
            titleLbl.Height = 40

            ' === Step 7: Add to ChartPanel ===
            ChartPanel.Controls.Add(chart)
            ChartPanel.Controls.Add(titleLbl)
            chart.BringToFront()

        Catch ex As Exception
            MessageBox.Show("❌ Failed to load chart data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadSuppliers()
        Try
            ConnectDB()
            Dim sql As String = "SELECT sup_id, sup_name, sup_contact, sup_email, status, logo_image FROM tb_suppliers"
            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            conn.Close()

            SupplierPanel.Controls.Clear()

            ' === Title===
            Dim titleLbl As New Label()
            titleLbl.Text = "Supplier Lists"
            titleLbl.Font = New Font("Segoe UI", 14, FontStyle.Bold)
            titleLbl.ForeColor = Color.FromArgb(60, 60, 60)
            titleLbl.TextAlign = ContentAlignment.MiddleCenter
            titleLbl.Dock = DockStyle.Top
            titleLbl.Height = 45
            titleLbl.BackColor = Color.Transparent
            SupplierPanel.Controls.Add(titleLbl)

            ' === Display each supplier ===
            For Each row As DataRow In dt.Rows
                Dim card As New Panel With {
                .Width = SupplierPanel.Width - 35,
                .Height = 100,
                .BackColor = Color.White,
                .Margin = New Padding(5)
            }

                ' --- Logo ---
                Dim logoBox As New PictureBox With {
                .Width = 70,
                .Height = 70,
                .Location = New Point(35, 15),
                .SizeMode = PictureBoxSizeMode.Zoom
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
                card.Controls.Add(logoBox)

                ' --- Supplier info ---
                Dim infoFont As New Font("Segoe UI", 9)
                Dim boldFont As New Font("Segoe UI", 9, FontStyle.Bold)
                Dim xPos As Integer = 160
                Dim yBase As Integer = 15

                ' Supplier name
                Dim lblName As New Label With {
                .Text = row("sup_name").ToString(),
                .Font = boldFont,
                .AutoSize = False,
                .Width = 280,
                .Height = 25,
                .Location = New Point(xPos, yBase)
            }
                card.Controls.Add(lblName)

                ' Contact info (email + phone)
                Dim lblContact As New Label With {
                .Text = "📧 " & row("sup_email").ToString() & vbCrLf &
                        "📞 " & row("sup_contact").ToString(),
                .Font = infoFont,
                .ForeColor = Color.Black,
                .AutoSize = False,
                .Width = 300,
                .Height = 40,
                .Location = New Point(xPos, yBase + 25)
            }
                card.Controls.Add(lblContact)

                ' Status (text color only)
                Dim statusText As String = row("status").ToString()
                Dim statusColor As Color = If(statusText.ToLower() = "active", Color.SeaGreen, Color.FromArgb(220, 53, 69))
                Dim lblStatus As New Label With {
                .Text = statusText,
                .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                .ForeColor = statusColor,
                .AutoSize = True,
                .Location = New Point(card.Width - 100, 38),
                .BackColor = Color.Transparent
            }
                card.Controls.Add(lblStatus)

                SupplierPanel.Controls.Add(card)
            Next

        Catch ex As Exception
            MessageBox.Show("❌ Error loading suppliers: " & ex.Message)
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
                    .Text = "No products found.",
                    .Font = New Font("Segoe UI", 11, FontStyle.Italic),
                    .ForeColor = Color.Gray,
                    .AutoSize = True,
                    .Margin = New Padding(20)
                }
                ProductPanel.Controls.Add(noDataLbl)
                Exit Sub
            End If

            ' === Title (centered, fixed width) ===
            Dim titleContainer As New Panel With {
                .Width = ProductPanel.Width - 35,
                .Height = 45,
                .BackColor = Color.Transparent
            }

            Dim titleLbl As New Label With {
                .Text = "Product Lists",
                .Font = New Font("Segoe UI", 14, FontStyle.Bold),
                .ForeColor = Color.FromArgb(60, 60, 60),
                .TextAlign = ContentAlignment.MiddleCenter,
                .Dock = DockStyle.Fill
            }

            titleContainer.Controls.Add(titleLbl)
            ProductPanel.Controls.Add(titleContainer)

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

                'Highlight low stock
                If stock <= minStock Then productCard.BackColor = Color.MistyRose

                ' === Product Image ===
                Dim pic As New PictureBox With {
                    .Width = 70,
                    .Height = 70,
                    .Location = New Point(50, 15),
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
                Dim xPos As Integer = 200
                Dim yBase As Integer = 25

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
                    .Location = New Point(xPos + 720, yBase)
                }
                productCard.Controls.Add(lblStock)

                ' Prices
                Dim lblPrice As New Label With {
                    .Text = $"Cost: {FormatCurrency(row("p_costPrice"), 2)}  |  Sell: {FormatCurrency(row("p_sellPrice"), 2)}",
                    .Font = detailsFont,
                    .ForeColor = Color.DarkGreen,
                    .AutoSize = False,
                    .Width = 200,
                    .Height = 20,
                    .Location = New Point(xPos + 720, yBase + 25)
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

    Private Sub LoadUserPanel()
        Try
            ConnectDB()
            Dim sql As String = "SELECT u_id, u_name, u_role FROM tb_users"
            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            conn.Close()

            UserPanel.Controls.Clear()

            ' === Title Container (for label + Add button) ===
            Dim titleContainer As New Panel With {
                .Width = UserPanel.Width - 35,
                .Height = 45,
                .Dock = DockStyle.Top,
                .BackColor = Color.Transparent
            }

            ' === Add Button (top-right transparent) ===
            Dim addBtn As New Button With {
                .Size = New Size(40, 40),
                .FlatStyle = FlatStyle.Flat,
                .Location = New Point(titleContainer.Width - 50, 8),
                .Cursor = Cursors.Hand
            }
            addBtn.FlatAppearance.BorderSize = 0

            ' Load Add icon
            Dim addImg As Image = TryCast(My.Resources.ResourceManager.GetObject("add"), Image)
            If addImg Is Nothing Then
                Dim addImagePath As String = Path.Combine(Application.StartupPath, "Resources\add.png")
                If File.Exists(addImagePath) Then
                    addImg = Image.FromFile(addImagePath)
                End If
            End If
            If addImg IsNot Nothing Then
                addBtn.BackgroundImage = addImg
                addBtn.BackgroundImageLayout = ImageLayout.Zoom
            End If

            ' === Title Label (centered) ===
            Dim titleLbl As New Label With {
                .Text = "User Lists",
                .Font = New Font("Segoe UI", 14, FontStyle.Bold),
                .ForeColor = Color.FromArgb(60, 60, 60),
                .AutoSize = True
            }
            ' Center it manually inside the panel
            titleLbl.Location = New Point((titleContainer.Width - titleLbl.Width) \ 2, (titleContainer.Height - titleLbl.Height) \ 2)

            ' === Button Click Event ===
            AddHandler addBtn.Click, Sub(sender, e)
                                         Dim addForm As New AddUserForm()
                                         addForm.ShowDialog()
                                     End Sub

            ' === Add controls to container ===
            titleContainer.Controls.Add(addBtn)
            titleContainer.Controls.Add(titleLbl)
            UserPanel.Controls.Add(titleContainer)

            ' Ensure Add button stays on top of label
            addBtn.BringToFront()

            ' === Display each user ===
            For Each row As DataRow In dt.Rows
                Dim card As New Panel With {
                .Width = UserPanel.Width - 35,
                .Height = 90,
                .BackColor = Color.White,
                .Margin = New Padding(5)
            }

                ' --- User Icon ---
                Dim userIcon As New PictureBox With {
                .Width = 30,
                .Height = 30,
                .Location = New Point(35, 30),
                .SizeMode = PictureBoxSizeMode.Zoom
            }

                Dim userImagePath As String = Path.Combine(Application.StartupPath, "Resources\user.png")
                If File.Exists(userImagePath) Then
                    userIcon.Image = Image.FromFile(userImagePath)
                Else
                    userIcon.BackColor = Color.LightGray
                End If
                card.Controls.Add(userIcon)

                ' --- User info ---
                Dim infoFont As New Font("Segoe UI", 9)
                Dim boldFont As New Font("Segoe UI", 9, FontStyle.Bold)
                Dim xPos As Integer = 120
                Dim yBase As Integer = 20

                ' User name
                Dim lblName As New Label With {
                .Text = row("u_name").ToString(),
                .Font = boldFont,
                .AutoSize = False,
                .Width = 250,
                .Height = 25,
                .Location = New Point(xPos, yBase)
            }
                card.Controls.Add(lblName)

                ' User details (ID + Role)
                Dim lblDetails As New Label With {
                .Text = $"🆔 ID: {row("u_id").ToString()}",
                .Font = infoFont,
                .ForeColor = Color.DimGray,
                .AutoSize = False,
                .Width = 350,
                .Height = 25,
                .Location = New Point(xPos, yBase + 25)
            }
                card.Controls.Add(lblDetails)

                ' === Role Highlight ===
                Dim roleText As String = row("u_role").ToString().ToLower()
                Dim roleColor As Color = If(roleText = "admin", Color.DarkOrange, Color.SeaGreen)

                Dim lblRole As New Label With {
                .Text = row("u_role").ToString(),
                .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                .ForeColor = roleColor,
                .AutoSize = True,
                .Location = New Point(card.Width - 100, 35),
                .BackColor = Color.Transparent
            }
                card.Controls.Add(lblRole)

                UserPanel.Controls.Add(card)
            Next

        Catch ex As Exception
            MessageBox.Show("❌ Error loading users: " & ex.Message)
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
