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

    Private Sub AboutUsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutUsToolStripMenuItem.Click
        Dim aboutbox As New AboutBox
        aboutbox.ShowDialog()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Dim login As New LoginForm
        login.Show()
        Close()
    End Sub

    ' === Form Load ===
    Private Sub SupplierForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSuppliers()
    End Sub


    Private Sub LoadSuppliers()
        Try
            ConnectDB()
            Dim sql As String = "SELECT sup_id, sup_name, sup_contact, sup_email, status, logo_image FROM tb_suppliers"
            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            conn.Close()

            SupplierFlowLayoutPanel.Controls.Clear()

            Dim headerPanel As New Panel With {
                .Width = SupplierFlowLayoutPanel.Width,
                .Height = 50,
                .BackColor = Color.AntiqueWhite,
                .Padding = New Padding(10, 10, 10, 10)
            }

            Dim columnWidths() As Integer = {230, 360, 360, 300, 300, 280}
            Dim headers() As String = {"Company Logo", "Supplier Name", "Email", "Contact", "Status", "Action"}

            Dim colX(headers.Length - 1) As Integer
            colX(0) = 10
            For i As Integer = 1 To headers.Length - 1
                colX(i) = colX(i - 1) + columnWidths(i - 1)
            Next

            ' === Header ===
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
                    .BackColor = Color.AntiqueWhite
                }
                headerPanel.Controls.Add(lbl)
            Next

            SupplierFlowLayoutPanel.Controls.Add(headerPanel)

            ' === Data ===
            For Each row As DataRow In dt.Rows
                Dim rowPanel As New Panel With {
                    .Width = SupplierFlowLayoutPanel.Width,
                    .Height = 80,
                    .BackColor = Color.White,
                    .BorderStyle = BorderStyle.None,
                    .Margin = New Padding(5),
                    .Padding = New Padding(5)
                }

                ' === Company Logo ===
                Dim logoBox As New PictureBox With {
                    .Width = columnWidths(0) - 20,
                    .Height = 70,
                    .SizeMode = PictureBoxSizeMode.Zoom,
                    .Location = New Point(colX(0) + (columnWidths(0) - (columnWidths(0) - 20)) \ 2, 5), ' ✅ 居中对齐 header
                    .BorderStyle = BorderStyle.None
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
                        .Location = New Point(colX(i + 1), 15)
                    }
                    rowPanel.Controls.Add(lbl)
                Next

                ' === Edit Button ===
                Dim editBtn As New Button With {
                    .Text = "Edit",
                    .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                    .BackColor = Color.SeaShell,
                    .ForeColor = Color.Sienna,
                    .FlatStyle = FlatStyle.Flat,
                    .Size = New Size(70, 25),
                    .Location = New Point(colX(5) + (columnWidths(5) - 70) \ 2, 20),
                    .Cursor = Cursors.Hand
                }
                editBtn.FlatAppearance.BorderSize = 0

                ' Hower Effect
                AddHandler editBtn.MouseEnter, Sub() editBtn.BackColor = Color.AntiqueWhite
                AddHandler editBtn.MouseLeave, Sub() editBtn.BackColor = Color.SeaShell

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

    Private Sub AddPictureBox_Click(sender As Object, e As EventArgs) Handles AddPictureBox.Click
        Dim addSupplierID As Integer = SupplierFlowLayoutPanel.Controls.Count + 1
        Dim addForm As New AddSupplierForm(addSupplierID)
        addForm.ShowDialog()
        LoadSuppliers()
    End Sub


    Private Sub EditSupplier(sup_id As Integer)
        Dim editForm As New EditSupplierForm(sup_id)
        editForm.ShowDialog()
        LoadSuppliers()
    End Sub
End Class