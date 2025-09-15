Imports MySql.Data.MySqlClient
Public Class LoginForm
    Private Sub loginButton_Clicked(sender As Object, e As EventArgs) Handles loginButton.Click
        ConnectDB()

        Try
            Dim sql As String = "SELECT * FROM tb_users WHERE u_name = @username AND u_password = @password"
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@username", usernameTextBox.Text.Trim())
            cmd.Parameters.AddWithValue("@password", passwordTextBox.Text.Trim())

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                Dim role As String = reader("u_role").ToString()
                MsgBox("Login Success! Welcome " & role)

                'Open different form based on role
                If role = "admin" Then
                    Dim Sales As New SalesForm()
                    Sales.Show()
                ElseIf role = "staff" Then
                    Dim Sales As New SalesForm()
                    Sales.Show()
                End If

                'Hide login form
                Me.Hide()
            Else
                MsgBox("Invalid username or password!")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)

        Finally
            conn.Close()
        End Try

    End Sub
End Class
