Imports MySql.Data.MySqlClient

Public Class SupplierForm
    Private Sub SalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem.Click
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

    ' === Form Load ===
    Private Sub SupplierForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSuppliers()
        ' Remove the blue highlight focus border
        MenuStrip1.Renderer = New ToolStripProfessionalRenderer(New NoHighlightColorTable())
    End Sub


    ' === 加载供应商卡片 ===
    Private Sub LoadSuppliers()
        Try
            ConnectDB()
            ' ✅ 从数据库取出图片栏位 logo_image
            Dim sql As String = "SELECT sup_id, sup_name, sup_contact, sup_email, status, logo_image FROM tb_suppliers"
            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            conn.Close()

            SupplierFlowLayoutPanel.Controls.Clear()
            SupplierFlowLayoutPanel.AutoScroll = True
            SupplierFlowLayoutPanel.BackColor = Color.FromArgb(248, 249, 252)

            ' === 表头 ===
            Dim headerPanel As New Panel With {
            .Width = SupplierFlowLayoutPanel.Width - 40,
            .Height = 40,
            .BackColor = Color.FromArgb(240, 242, 247),
            .Padding = New Padding(10, 10, 10, 10)
        }

            Dim headers() As String = {"Company Logo", "Supplier Name", "Email", "Contact", "Status", "Action"}
            Dim headerWidths() As Integer = {100, 180, 220, 130, 100, 80}
            Dim xPos As Integer = 10

            For i As Integer = 0 To headers.Length - 1
                Dim lbl As New Label With {
                .Text = headers(i),
                .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                .ForeColor = Color.Black,
                .AutoSize = False,
                .Width = headerWidths(i),
                .TextAlign = ContentAlignment.MiddleLeft,
                .Location = New Point(xPos, 5)
            }
                headerPanel.Controls.Add(lbl)
                xPos += headerWidths(i)
            Next

            SupplierFlowLayoutPanel.Controls.Add(headerPanel)

            ' === 数据行 ===
            For Each row As DataRow In dt.Rows
                Dim rowPanel As New Panel With {
                .Width = SupplierFlowLayoutPanel.Width - 40,
                .Height = 55,
                .BackColor = Color.White,
                .BorderStyle = BorderStyle.FixedSingle,
                .Margin = New Padding(3)
            }

                ' Hover 效果
                AddHandler rowPanel.MouseEnter, Sub() rowPanel.BackColor = Color.FromArgb(245, 248, 255)
                AddHandler rowPanel.MouseLeave, Sub() rowPanel.BackColor = Color.White

                Dim xPosRow As Integer = 10

                ' === 公司Logo ===
                Dim logoBox As New PictureBox With {
                .Width = 80,
                .Height = 40,
                .SizeMode = PictureBoxSizeMode.Zoom,
                .Location = New Point(xPosRow + 5, 7),
                .BorderStyle = BorderStyle.None
            }

                Try
                    ' ✅ 从数据库 BLOB 转回图片
                    If Not IsDBNull(row("logo_image")) Then
                        Dim imgData() As Byte = DirectCast(row("logo_image"), Byte())
                        Using ms As New IO.MemoryStream(imgData)
                            logoBox.Image = Image.FromStream(ms)
                        End Using
                    Else
                        ' ❌ 如果没图片，就显示灰色背景或默认图
                        logoBox.BackColor = Color.LightGray
                    End If
                Catch
                    logoBox.BackColor = Color.LightGray
                End Try

                rowPanel.Controls.Add(logoBox)
                xPosRow += 100

                ' === 文字列 ===
                Dim values() As String = {
                row("sup_name").ToString(),
                row("sup_email").ToString(),
                row("sup_contact").ToString(),
                row("status").ToString()
            }

                Dim widths() As Integer = {180, 220, 130, 100}
                For i As Integer = 0 To values.Length - 1
                    Dim lbl As New Label With {
                    .Text = values(i),
                    .Font = New Font("Segoe UI", 9),
                    .ForeColor = If(i = 3 AndAlso values(i).ToLower() = "active", Color.SeaGreen,
                                   If(i = 3, Color.Gray, Color.Black)),
                    .AutoSize = False,
                    .Width = widths(i),
                    .TextAlign = ContentAlignment.MiddleLeft,
                    .Location = New Point(xPosRow, 15)
                }
                    rowPanel.Controls.Add(lbl)
                    xPosRow += widths(i)
                Next

                ' === Edit 按钮 ===
                Dim editBtn As New Button With {
                .Text = "Edit",
                .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                .BackColor = Color.FromArgb(230, 238, 255),
                .ForeColor = Color.FromArgb(30, 60, 140),
                .FlatStyle = FlatStyle.Flat,
                .Size = New Size(70, 25),
                .Location = New Point(xPosRow + 5, 13),
                .Cursor = Cursors.Hand
            }
                editBtn.FlatAppearance.BorderSize = 0

                Dim supID As Integer = Convert.ToInt32(row("sup_id"))
                AddHandler editBtn.Click, Sub() EditSupplier(supID)

                rowPanel.Controls.Add(editBtn)
                SupplierFlowLayoutPanel.Controls.Add(rowPanel)
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading suppliers: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub



    ' === 打开添加供应商表单 ===
    Private Sub AddPictureBox_Click(sender As Object, e As EventArgs) Handles AddPictureBox.Click
        Dim addSupplierID As Integer = SupplierFlowLayoutPanel.Controls.Count + 1
        Dim addForm As New AddSupplierForm(addSupplierID)
        addForm.ShowDialog()
        LoadSuppliers()
    End Sub


    ' === 打开编辑供应商表单 ===
    Private Sub EditSupplier(sup_id As Integer)
        Dim editForm As New EditSupplierForm(sup_id)
        editForm.ShowDialog()
        LoadSuppliers()
    End Sub

End Class