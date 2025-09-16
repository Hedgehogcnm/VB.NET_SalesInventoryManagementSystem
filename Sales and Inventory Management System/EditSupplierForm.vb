Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class EditSupplierForm
    Private supID As Integer
    Private isSaved As Boolean = True   ' Initially assume no unsaved changes

    ' Constructor receives sup_id from SupplierForm
    Public Sub New(sup_id As Integer)
        InitializeComponent()
        supID = sup_id
    End Sub

    ' When the form loads, fetch supplier details from the database
    Private Sub EditSupplierForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ConnectDB()
            Dim sql As String = "SELECT sup_id, sup_name, sup_contact, sup_email, status FROM tb_suppliers WHERE sup_id=@sup_id"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@sup_id", supID)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    SupplierIDLabel.Text = supID
                    SupplierNameTextBox.Text = reader("sup_name").ToString()
                    SupplierNameTextBox.Focus()
                    ContactTextBox.Text = reader("sup_contact").ToString()
                    EmailTextBox.Text = reader("sup_email").ToString()

                    Dim statusValue As String = reader("status").ToString()
                    If statusValue = "Active" Then
                        ActiveRadioButton.Checked = True
                    Else
                        InactiveRadioButton.Checked = True
                    End If
                End If
                isSaved = True   ' after loading data, mark as saved
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load supplier details: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Prevent first TextBox from being auto-selected
    Private Sub EditSupplierForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.ActiveControl = Nothing
    End Sub

    ' Detect if the user made any changes
    Private Sub AnyControl_Changed(sender As Object, e As EventArgs) Handles SupplierNameTextBox.TextChanged, ContactTextBox.TextChanged, EmailTextBox.TextChanged, ActiveRadioButton.CheckedChanged, InactiveRadioButton.CheckedChanged
        isSaved = False   ' User modified a field, mark as unsaved
    End Sub

    ' Save button updates supplier data
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim newName As String = SupplierNameTextBox.Text.Trim()
        Dim newContact As String = ContactTextBox.Text.Trim()
        Dim newEmail As String = EmailTextBox.Text.Trim()
        Dim newStatus As String = If(ActiveRadioButton.Checked, "Active", "Inactive")
        Dim emailPattern As String = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"

        ' Checking email format
        If Not Regex.IsMatch(newEmail, emailPattern) Then
            EmailErrorProvider.SetError(EmailTextBox, "Invalid email format")
            Return
        Else
            EmailErrorProvider.SetError(EmailTextBox, "") ' Clear error message
        End If

        If newName = "" OrElse newContact = "" OrElse newEmail = "" Then
            MessageBox.Show("All fields are required.")
            Return
        End If

        Try
            ConnectDB()
            Dim sql As String = "UPDATE tb_suppliers SET sup_name=@name, sup_contact=@contact, sup_email=@email, status=@status WHERE sup_id=@sup_id"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@name", newName)
                cmd.Parameters.AddWithValue("@contact", newContact)
                cmd.Parameters.AddWithValue("@email", newEmail)
                cmd.Parameters.AddWithValue("@status", newStatus)
                cmd.Parameters.AddWithValue("@sup_id", supID)
                cmd.ExecuteNonQuery()
            End Using
            ' Assume save was successful
            isSaved = True
            MessageBox.Show("Supplier updated successfully!")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error updating supplier: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub EditSupplierForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' If there are unsaved changes, show confirmation dialog
        If Not isSaved Then
            Dim result As DialogResult = MessageBox.Show("You have unsaved changes. Do you want to save before closing?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                SaveButton.PerformClick()  ' Trigger Save button
            ElseIf result = DialogResult.Cancel Then
                e.Cancel = True   ' Cancel closing
            End If
        End If
    End Sub
End Class