Imports MySql.Data.MySqlClient
Module DBConnection
    Public conn As MySqlConnection
    Public Sub ConnectDB()
        'Teng Testing'
        Try
            Dim connStr As String = "server=localhost;user id=root;password=;database=db_sales_inventory_management_system;"
            conn = New MySqlConnection(connStr)
            conn.Open()
            ' MsgBox("Database Connected!")  ' for testing only
        Catch ex As Exception
            MsgBox("Database connection failed: " & ex.Message)
        End Try
    End Sub
End Module
