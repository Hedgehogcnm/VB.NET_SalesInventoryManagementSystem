Imports MySql.Data.MySqlClient

Public Class OrderProductForm

    Private Sub OrderProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSupplierComboBox()
    End Sub

    Private Sub LoadSupplierComboBox()
        Try
            ConnectDB() ' your existing function to open "conn"

            Dim sql As String = "SELECT sup_id, sup_name FROM tb_suppliers ORDER BY sup_name ASC"
            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            da.Fill(dt)

            ' --- Bind to ComboBox ---
            SupplierComboBox.DataSource = dt
            SupplierComboBox.DisplayMember = "sup_name"   ' 👈 only show supplier name
            SupplierComboBox.ValueMember = "sup_id"       ' 👈 internally store supplier ID
            SupplierComboBox.SelectedIndex = -1           ' 👈 optional: start with blank

        Catch ex As Exception
            MessageBox.Show("❌ Failed to load suppliers: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub
End Class