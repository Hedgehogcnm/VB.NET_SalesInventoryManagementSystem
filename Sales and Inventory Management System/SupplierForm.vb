Imports MySql.Data.MySqlClient

Public Class SupplierForm
    Private Sub SalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem.Click
        Dim Sales As New SalesForm()
        Sales.Show()
        Me.Close()
    End Sub

    Private Sub InventoryToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles InventoryToolStripMenuItem.Click
        Dim Inventory As New InventoryForm()
        Inventory.Show()
        Me.Close()
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem.Click
        Dim Supplier As New SupplierForm()
        Supplier.Show()
        Me.Close()
    End Sub

    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click
        Dim Report As New ReportForm()
        Report.Show()
        Me.Close()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Dim login As New LoginForm()
        login.Show()
        Me.Close()
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
            DataGridViewSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridViewSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridViewSupplier.MultiSelect = True
            DataGridViewSupplier.ReadOnly = True

            ' Change column header text
            DataGridViewSupplier.Columns("sup_id").HeaderText = "Supplier ID"
            DataGridViewSupplier.Columns("sup_name").HeaderText = "Supplier Name"
            DataGridViewSupplier.Columns("sup_contact").HeaderText = "Contact"
            DataGridViewSupplier.Columns("sup_email").HeaderText = "Email"
            DataGridViewSupplier.Columns("status").HeaderText = "Status"

        Catch ex As Exception
            MessageBox.Show("Failed to load suppliers: " & ex.Message)
        Finally
            ' Always close the connection after use
            conn.Close()
        End Try
    End Sub

    Private Sub btnChangeStatus_Click(sender As Object, e As EventArgs) Handles btnChangeStatus.Click
        If DataGridViewSupplier.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select at least one supplier.")
            Return
        End If

        ' Ask user for the new status once
        Dim newStatus = InputBox("Enter new status: Active, or Inactive", "Change Supplier Status", "Inactive")

        If newStatus <> "Active" AndAlso newStatus <> "Inactive" Then
            Return
        End If

        Try
            ConnectDB()

            ' Loop through all selected rows
            For Each row As DataGridViewRow In DataGridViewSupplier.SelectedRows
                Dim sup_id = Convert.ToInt32(row.Cells("sup_id").Value)

                Dim sql = "UPDATE tb_suppliers SET status=@status WHERE sup_id=@sup_id"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@status", newStatus)
                    cmd.Parameters.AddWithValue("@sup_id", sup_id)
                    cmd.ExecuteNonQuery()
                End Using
            Next

            MessageBox.Show("Status updated to " & newStatus & " for " & DataGridViewSupplier.SelectedRows.Count & " suppliers.")
            LoadSuppliers() ' refresh table

        Catch ex As Exception
            MessageBox.Show("Error updating status: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
End Class