Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn.Open()
            MessageBox.Show("Database Connected!")
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Connection failed: " & ex.Message)
        End Try
    End Sub
End Class
