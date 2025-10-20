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

    ' When the form loads, call LoadSuppliers to show supplier data
    Private Sub SupplierForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSuppliers()
    End Sub

    ' Load supplier data from the database into DataGridView
    Private Sub LoadSuppliers()
        Try
            ' Use the existing DBConnection module to connect
            ConnectDB()

            ' SQL query to select supplier details
            Dim sql As String = "SELECT sup_id, sup_name, sup_contact, sup_email, status FROM tb_suppliers"

            ' Data adapter and DataTable to hold results
            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            da.Fill(dt)

            ' Bind the results to DataGridView
            DataGridViewSupplier.DataSource = dt

            ' Adjust DataGridView style
            DataGridViewSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            DataGridViewSupplier.EnableHeadersVisualStyles = False
            DataGridViewSupplier.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridViewSupplier.Font, FontStyle.Bold)
            DataGridViewSupplier.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridViewSupplier.Columns("sup_id").Width = 60
            DataGridViewSupplier.Columns("sup_name").Width = 170
            DataGridViewSupplier.Columns("sup_contact").Width = 80
            DataGridViewSupplier.Columns("sup_email").Width = 170
            DataGridViewSupplier.Columns("status").Width = 60
            DataGridViewSupplier.Columns("sup_id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridViewSupplier.Columns("sup_contact").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridViewSupplier.Columns("status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridViewSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridViewSupplier.ColumnHeadersDefaultCellStyle.SelectionBackColor = DataGridViewSupplier.ColumnHeadersDefaultCellStyle.BackColor
            DataGridViewSupplier.ColumnHeadersDefaultCellStyle.SelectionForeColor = DataGridViewSupplier.ColumnHeadersDefaultCellStyle.ForeColor
            DataGridViewSupplier.MultiSelect = True
            DataGridViewSupplier.ReadOnly = True
            DataGridViewSupplier.AllowUserToAddRows = False


            ' Change column header text
            DataGridViewSupplier.Columns("sup_id").HeaderText = "Supplier ID"
            DataGridViewSupplier.Columns("sup_name").HeaderText = "Supplier Name"
            DataGridViewSupplier.Columns("sup_contact").HeaderText = "Contact"
            DataGridViewSupplier.Columns("sup_email").HeaderText = "Email"
            DataGridViewSupplier.Columns("status").HeaderText = "Status"

            ' Add Edit Icon one time in DataGridView Column
            If Not DataGridViewSupplier.Columns.Contains("EditColumn") Then
                Dim editColumn As New DataGridViewImageColumn()
                editColumn.Image = Image.FromFile(IO.Path.Combine(Application.StartupPath, "EditIcon.png"))
                editColumn.HeaderText = ""
                editColumn.Name = "EditColumn"
                editColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
                DataGridViewSupplier.Columns.Add(editColumn)
                DataGridViewSupplier.EnableHeadersVisualStyles = False
                DataGridViewSupplier.Columns("EditColumn").Width = 35
                DataGridViewSupplier.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

        Catch ex As Exception
            MessageBox.Show("Failed to load suppliers: " & ex.Message)
        Finally
            ' Always close the connection after use
            conn.Close()
        End Try
    End Sub

    Private Sub DataGridViewSupplier_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSupplier.CellContentClick
        If e.ColumnIndex = DataGridViewSupplier.Columns("EditColumn").Index AndAlso e.RowIndex >= 0 Then
            Dim sup_id As Integer = Convert.ToInt32(DataGridViewSupplier.Rows(e.RowIndex).Cells("sup_id").Value)
            Dim editForm As New EditSupplierForm(sup_id)
            editForm.ShowDialog()
            LoadSuppliers()
            DataGridViewSupplier.ClearSelection()
        End If
    End Sub

    Private Sub AddPictureBox_Click(sender As Object, e As EventArgs) Handles AddPictureBox.Click
        Dim addSupplierID As Integer = DataGridViewSupplier.Rows.Count + 1
        Dim addForm As New AddSupplierForm(addSupplierID)
        addForm.ShowDialog()
        LoadSuppliers()
        DataGridViewSupplier.ClearSelection()
    End Sub
End Class