Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class AddUserForm
    Private isSaved As Boolean = True

    Private Sub AddUserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' === Background ===
        Me.BackColor = Color.FromArgb(255, 247, 238)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterScreen

        ' === Main Panel ===
        MainPanel.BackColor = Color.SeaShell
        MainPanel.BorderStyle = BorderStyle.None
        MainPanel.Padding = New Padding(30)
        MainPanel.Size = New Size(600, 350)
        MainPanel.Location = New Point((Me.ClientSize.Width - MainPanel.Width) \ 2, (Me.ClientSize.Height - MainPanel.Height) \ 2)

        ' === Title ===
        TitleLabel.Font = New Font("Segoe UI Semibold", 16, FontStyle.Bold)
        TitleLabel.ForeColor = Color.FromArgb(120, 80, 40)
        TitleLabel.Text = "Add User"
        TitleLabel.TextAlign = ContentAlignment.MiddleCenter
        TitleLabel.Dock = DockStyle.Top
        TitleLabel.Height = 45

        ' === Label Style ===
        For Each lbl As Label In {UserNameText, PasswordText, RoleText}
            lbl.Font = New Font("Segoe UI Semibold", 10)
            lbl.ForeColor = Color.FromArgb(100, 70, 50)
            lbl.TextAlign = ContentAlignment.MiddleRight
        Next

        ' === TextBox Style ===
        For Each txt As TextBox In {UserNameTextBox, PasswordTextBox}
            txt.BorderStyle = BorderStyle.FixedSingle
            txt.BackColor = Color.FromArgb(255, 245, 230)
            txt.ForeColor = Color.FromArgb(50, 50, 50)
        Next
        PasswordTextBox.UseSystemPasswordChar = True

        ' === Role ComboBox ===
        RoleComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        RoleComboBox.Items.Clear()
        RoleComboBox.Items.AddRange({"admin", "staff"})
        RoleComboBox.BackColor = Color.FromArgb(255, 245, 230)
        RoleComboBox.ForeColor = Color.FromArgb(50, 50, 50)

        ' === Save Button ===
        SaveButton.FlatStyle = FlatStyle.Flat
        SaveButton.FlatAppearance.BorderSize = 0
        SaveButton.BackColor = Color.FromArgb(255, 235, 215)
        SaveButton.ForeColor = Color.FromArgb(120, 80, 40)
        SaveButton.Font = New Font("Segoe UI Semibold", 9)
        SaveButton.Cursor = Cursors.Hand
        AddHandler SaveButton.MouseEnter, Sub() SaveButton.BackColor = Color.FromArgb(255, 225, 200)
        AddHandler SaveButton.MouseLeave, Sub() SaveButton.BackColor = Color.FromArgb(255, 235, 215)
    End Sub

    ' Detect changes
    Private Sub AnyControl_Changed(sender As Object, e As EventArgs) Handles UserNameTextBox.TextChanged, PasswordTextBox.TextChanged, RoleComboBox.SelectedIndexChanged
        isSaved = False
    End Sub

    ' Save Button
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim uname As String = UserNameTextBox.Text.Trim()
        Dim upass As String = PasswordTextBox.Text.Trim()
        Dim urole As String = RoleComboBox.Text.Trim()

        If uname = "" OrElse upass = "" OrElse urole = "" Then
            MessageBox.Show("All fields are required.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ConnectDB()
            Dim sql As String = "INSERT INTO tb_users (u_name, u_password, u_role) VALUES (@name, @pass, @role)"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@name", uname)
                cmd.Parameters.AddWithValue("@pass", upass)
                cmd.Parameters.AddWithValue("@role", urole)
                cmd.ExecuteNonQuery()
            End Using

            isSaved = True
            MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error adding user: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub AddUserForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not isSaved Then
            Dim result As DialogResult = MessageBox.Show("You have unsaved changes. Save before closing?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                SaveButton.PerformClick()
            ElseIf result = DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class
