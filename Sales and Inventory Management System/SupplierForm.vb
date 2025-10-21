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
    End Sub


    ' === 加载供应商卡片 ===
    Private Sub LoadSuppliers()
        Try
            ConnectDB()
            Dim sql As String = "SELECT sup_id, sup_name, sup_contact, sup_email, status FROM tb_suppliers"
            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            conn.Close()

            SupplierFlowLayoutPanel.Controls.Clear()

            If dt.Rows.Count = 0 Then
                Dim noDataLbl As New Label With {
                    .Text = "No suppliers found.",
                    .Font = New Font("Segoe UI", 11, FontStyle.Italic),
                    .ForeColor = Color.Gray,
                    .AutoSize = True,
                    .Margin = New Padding(20)
                }
                SupplierFlowLayoutPanel.Controls.Add(noDataLbl)
                Exit Sub
            End If

            ' === Create Cards ===
            For Each row As DataRow In dt.Rows
                Dim card As New Panel With {
                    .Width = 260,
                    .Height = 140,
                    .BackColor = Color.White,
                    .Margin = New Padding(15),
                    .BorderStyle = BorderStyle.FixedSingle
                }

                ' Name
                Dim nameLbl As New Label With {
                    .Text = row("sup_name").ToString(),
                    .Font = New Font("Segoe UI", 10, FontStyle.Bold),
                    .AutoSize = True,
                    .Location = New Point(15, 10)
                }

                ' Email
                Dim emailLbl As New Label With {
                    .Text = row("sup_email").ToString(),
                    .Font = New Font("Segoe UI", 9),
                    .AutoSize = True,
                    .Location = New Point(15, 35)
                }

                ' Phone
                Dim phoneLbl As New Label With {
                    .Text = "📞 " & row("sup_contact").ToString(),
                    .Font = New Font("Segoe UI", 9),
                    .AutoSize = True,
                    .Location = New Point(15, 55)
                }

                ' Status
                Dim statusText As String = row("status").ToString()
                Dim statusColor As Color = If(statusText.ToLower() = "active", Color.SeaGreen, Color.Gray)
                Dim statusLbl As New Label With {
                    .Text = "Status: " & statusText,
                    .Font = New Font("Segoe UI", 9, FontStyle.Italic),
                    .ForeColor = statusColor,
                    .AutoSize = True,
                    .Location = New Point(15, 80)
                }

                ' Edit Button
                Dim editBtn As New Button With {
                    .Text = "Edit ✎",
                    .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                    .BackColor = Color.LightSteelBlue,
                    .ForeColor = Color.Black,
                    .FlatStyle = FlatStyle.Flat,
                    .Size = New Size(70, 28),
                    .Location = New Point(170, 100)
                }
                editBtn.FlatAppearance.BorderSize = 0

                Dim supID As Integer = Convert.ToInt32(row("sup_id"))
                AddHandler editBtn.Click, Sub() EditSupplier(supID)

                card.Controls.AddRange({nameLbl, emailLbl, phoneLbl, statusLbl, editBtn})
                SupplierFlowLayoutPanel.Controls.Add(card)
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