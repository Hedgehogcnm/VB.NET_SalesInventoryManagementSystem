Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class AddUserForm
    Private isSaved As Boolean = True

    Private Sub AddUserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
