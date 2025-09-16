Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions ' Check regex for email

Public Class AddSupplierForm
    Private isSaved As Boolean = True   ' Initially assume saved
    Private id As Integer

    ' Initialize Component
    Public Sub New(addSupplierID As Integer)
        InitializeComponent()
        id = addSupplierID
    End Sub

    Private Sub AddSupplierForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SupplierIDLabel.Text = id.ToString
    End Sub

    Private Sub AnyControl_Changed(sender As Object, e As EventArgs) Handles SupplierNameTextBox.TextChanged, ContactTextBox.TextChanged, EmailTextBox.TextChanged
        isSaved = False   ' User modified a field, mark as unsaved
    End Sub

    ' Save button updates supplier data
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim name As String = SupplierNameTextBox.Text.Trim()
        Dim contact As String = ContactTextBox.Text.Trim()
        Dim email As String = EmailTextBox.Text.Trim()
        Dim emailPattern As String = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"

        ' Checking email format
        If Not Regex.IsMatch(email, emailPattern) Then
            EmailErrorProvider.SetError(EmailTextBox, "Invalid email format")
            Return
        Else
            EmailErrorProvider.SetError(EmailTextBox, "") ' Clear error message
        End If

        If name = "" OrElse contact = "" OrElse email = "" Then
            MessageBox.Show("All fields are required.")
            Return
        End If

        Try
            ConnectDB()
            Dim sql As String = "INSERT INTO tb_suppliers (sup_name, sup_contact, sup_email) VALUES (@name, @contact, @email)"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@name", name)
                cmd.Parameters.AddWithValue("@contact", contact)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.ExecuteNonQuery()
            End Using
            isSaved = True
            MessageBox.Show("Supplier added successfully!")
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error adding supplier: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub AddSupplierForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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