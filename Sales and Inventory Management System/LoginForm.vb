Imports MySql.Data.MySqlClient
Imports System.Drawing

Public Class LoginForm

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ackground
        Me.BackColor = Color.FromArgb(255, 247, 238) ' Soft peach
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = New Font("Segoe UI", 10)

        'Label Style
        For Each lbl As Label In {UsernameLabel, PasswordLabel}
            lbl.Font = New Font("Segoe UI Semibold", 10)
            lbl.ForeColor = Color.FromArgb(100, 70, 50)
            lbl.TextAlign = ContentAlignment.MiddleRight
        Next

        'TextBox Style
        For Each txt As TextBox In {usernameTextBox, passwordTextBox}
            txt.BorderStyle = BorderStyle.FixedSingle
            txt.BackColor = Color.FromArgb(255, 245, 230)
            txt.ForeColor = Color.FromArgb(50, 50, 50)
        Next
        passwordTextBox.UseSystemPasswordChar = True

        'Login Button
        loginButton.FlatStyle = FlatStyle.Flat
        loginButton.FlatAppearance.BorderSize = 0
        loginButton.BackColor = Color.FromArgb(255, 235, 215)
        loginButton.ForeColor = Color.FromArgb(120, 80, 40)
        loginButton.Font = New Font("Segoe UI Semibold", 10)
        loginButton.Cursor = Cursors.Hand
        AddHandler loginButton.MouseEnter, Sub() loginButton.BackColor = Color.FromArgb(255, 225, 200)
        AddHandler loginButton.MouseLeave, Sub() loginButton.BackColor = Color.FromArgb(255, 235, 215)

    End Sub

    'Login Logic
    Private Sub loginButton_Click(sender As Object, e As EventArgs) Handles loginButton.Click
        Try
            ConnectDB()

            Dim sql As String = "SELECT u_role FROM tb_users WHERE u_name = @username AND u_password = @password"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@username", usernameTextBox.Text.Trim())
                cmd.Parameters.AddWithValue("@password", passwordTextBox.Text.Trim())

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    Dim role As String = reader("u_role").ToString().ToLower()

                    MsgBox("Login Success! Welcome " & role, MsgBoxStyle.Information, "Login Successful")
                    Me.Hide()

                    If role = "admin" Then
                        Dim adminForm As New AdminDashboardForm()
                        adminForm.Show()
                    ElseIf role = "staff" Then
                        Dim staffForm As New SalesForm()
                        staffForm.Show()
                    End If
                Else
                    MsgBox("Invalid username or password!", MsgBoxStyle.Critical, "Login Failed")
                End If
            End Using

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
        Finally
            conn.Close()
        End Try
    End Sub
End Class
