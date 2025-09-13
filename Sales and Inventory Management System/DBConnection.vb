Imports MySql.Data.MySqlClient
Module DBConnection
    Public conn As New MySqlConnection("server=localhost; user id=root; password=; database=db_sales_inventory_management_system;")

    '#To Open Database Connection
    'conn.Open() 

    '#To Close Database Connection
    'conn.Close()

End Module
