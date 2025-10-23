Imports System.IO
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class EditSupplierForm
    Private supID As Integer
    Private isSaved As Boolean = True
    Private logoPath As String = ""
    Private currentLogoBytes As Byte()

    Public Sub New(sup_id As Integer)
        InitializeComponent()
        supID = sup_id
    End Sub

    Private Sub EditSupplierForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' === Background ===
        Me.BackColor = Color.FromArgb(255, 247, 238) ' 柔和米橙色
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Edit Supplier"

        ' === Main Panel ===
        MainPanel.BackColor = Color.SeaShell
        MainPanel.BorderStyle = BorderStyle.None
        MainPanel.Padding = New Padding(30)
        MainPanel.Size = New Size(600, 420)
        MainPanel.Location = New Point((Me.ClientSize.Width - MainPanel.Width) \ 2, (Me.ClientSize.Height - MainPanel.Height) \ 2)

        ' === Center title inside MainPanel ===
        TitleLabel.Dock = DockStyle.None
        TitleLabel.AutoSize = False
        TitleLabel.Size = New Size(MainPanel.Width, 45)
        TitleLabel.Location = New Point(0, 20)
        TitleLabel.TextAlign = ContentAlignment.MiddleCenter

        ' === Title ===
        TitleLabel.Font = New Font("Segoe UI Semibold", 16, FontStyle.Bold)
        TitleLabel.ForeColor = Color.FromArgb(120, 80, 40) ' 深棕色
        TitleLabel.TextAlign = ContentAlignment.MiddleCenter
        TitleLabel.Text = "Edit Supplier"
        TitleLabel.Dock = DockStyle.Top
        TitleLabel.Height = 45

        ' === Label Style ===
        For Each lbl As Label In {SupplierNameText, ContactText, EmailText, LogoText, StatusText}
            lbl.Font = New Font("Segoe UI Semibold", 10)
            lbl.ForeColor = Color.FromArgb(100, 70, 50)
            lbl.TextAlign = ContentAlignment.MiddleRight
        Next

        ' === TextBox Style ===
        For Each txt As TextBox In {SupplierNameTextBox, ContactTextBox, EmailTextBox}
            txt.BorderStyle = BorderStyle.FixedSingle
            txt.Font = New Font("Segoe UI", 10)
            txt.BackColor = Color.FromArgb(255, 245, 230)
            txt.ForeColor = Color.FromArgb(50, 50, 50)
        Next

        ' === PictureBox ===
        With LogoPictureBox
            .BorderStyle = BorderStyle.FixedSingle
            .SizeMode = PictureBoxSizeMode.Zoom
            .BackColor = Color.White
        End With

        ' === Upload Button ===
        UploadFileButton.FlatStyle = FlatStyle.Flat
        UploadFileButton.FlatAppearance.BorderSize = 0
        UploadFileButton.BackColor = Color.FromArgb(255, 235, 215)
        UploadFileButton.ForeColor = Color.FromArgb(120, 80, 40)
        UploadFileButton.Font = New Font("Segoe UI Semibold", 9)
        UploadFileButton.Cursor = Cursors.Hand
        AddHandler UploadFileButton.MouseEnter, Sub() UploadFileButton.BackColor = Color.FromArgb(255, 225, 200)
        AddHandler UploadFileButton.MouseLeave, Sub() UploadFileButton.BackColor = Color.FromArgb(255, 235, 215)

        ' === Save Button ===
        SaveButton.FlatStyle = FlatStyle.Flat
        SaveButton.FlatAppearance.BorderSize = 0
        SaveButton.BackColor = Color.FromArgb(255, 235, 215)
        SaveButton.ForeColor = Color.FromArgb(120, 80, 40)
        SaveButton.Font = New Font("Segoe UI Semibold", 9)
        SaveButton.Cursor = Cursors.Hand
        AddHandler SaveButton.MouseEnter, Sub() SaveButton.BackColor = Color.FromArgb(255, 225, 200)
        AddHandler SaveButton.MouseLeave, Sub() SaveButton.BackColor = Color.FromArgb(255, 235, 215)

        ' === RadioButton Style ===
        For Each rb As RadioButton In {ActiveRadioButton, InactiveRadioButton}
            rb.Font = New Font("Segoe UI", 9.5, FontStyle.Regular)
            rb.ForeColor = Color.FromArgb(100, 70, 50)
            rb.BackColor = Color.SeaShell
        Next

        ' === Path Label ===
        PathLabel.ForeColor = Color.FromArgb(100, 70, 50)

        ' === Load Data ===
        LoadSupplierData()

        ' === Center title horizontally in the whole form ===
        TitleLabel.Dock = DockStyle.None
        TitleLabel.AutoSize = False
        TitleLabel.Size = New Size(Me.ClientSize.Width, 45)
        TitleLabel.Location = New Point(0, 20)
        TitleLabel.TextAlign = ContentAlignment.MiddleCenter
    End Sub

    ' === Load Supplier Info ===
    Private Sub LoadSupplierData()
        Try
            ConnectDB()
            Dim sql As String = "SELECT sup_id, sup_name, sup_contact, sup_email, status, logo_image 
                                 FROM tb_suppliers WHERE sup_id=@sup_id"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@sup_id", supID)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    SupplierNameTextBox.Text = reader("sup_name").ToString()
                    ContactTextBox.Text = reader("sup_contact").ToString()
                    EmailTextBox.Text = reader("sup_email").ToString()

                    Dim statusValue As String = reader("status").ToString()
                    If statusValue = "Active" Then
                        ActiveRadioButton.Checked = True
                    Else
                        InactiveRadioButton.Checked = True
                    End If

                    ' === Logo ===
                    If Not IsDBNull(reader("logo_image")) Then
                        currentLogoBytes = DirectCast(reader("logo_image"), Byte())
                        Using ms As New MemoryStream(currentLogoBytes)
                            LogoPictureBox.Image = Image.FromStream(ms)
                        End Using
                        PathLabel.Text = "logo_supplier_" & supID & ".png"
                        PathLabel.ForeColor = Color.FromArgb(80, 60, 40)
                    Else
                        LogoPictureBox.Image = Nothing
                        PathLabel.Text = "(No logo uploaded)"
                        PathLabel.ForeColor = Color.Gray
                    End If
                End If
            End Using
            isSaved = True
        Catch ex As Exception
            MessageBox.Show("Failed to load supplier details: " & ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' === Upload New Logo ===
    Private Sub UploadFileButton_Click(sender As Object, e As EventArgs) Handles UploadFileButton.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
            .Title = "Select Company Logo"
        }

        If ofd.ShowDialog() = DialogResult.OK Then
            logoPath = ofd.FileName
            LogoPictureBox.Image = Image.FromFile(logoPath)
            PathLabel.Text = IO.Path.GetFileName(logoPath) & " (new)"
            PathLabel.ForeColor = Color.FromArgb(120, 80, 40)
            isSaved = False
        End If
    End Sub

    ' === Save Changes ===
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim newName As String = SupplierNameTextBox.Text.Trim()
        Dim newContact As String = ContactTextBox.Text.Trim()
        Dim newEmail As String = EmailTextBox.Text.Trim()
        Dim newStatus As String = If(ActiveRadioButton.Checked, "Active", "Inactive")
        Dim emailPattern As String = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"

        If Not Regex.IsMatch(newEmail, emailPattern) Then
            EmailErrorProvider.SetError(EmailTextBox, "Invalid email format")
            Return
        Else
            EmailErrorProvider.SetError(EmailTextBox, "")
        End If

        If newName = "" OrElse newContact = "" OrElse newEmail = "" Then
            MessageBox.Show("All fields are required.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' === Process Logo Bytes ===
        Dim logoBytes() As Byte = Nothing
        Try
            If logoPath <> "" AndAlso IO.File.Exists(logoPath) Then
                logoBytes = IO.File.ReadAllBytes(logoPath)
            Else
                logoBytes = currentLogoBytes
            End If
        Catch ex As Exception
            MessageBox.Show("Error reading logo file: " & ex.Message)
            Return
        End Try

        ' === Update Database ===
        Try
            ConnectDB()
            Dim sql As String = "UPDATE tb_suppliers 
                                 SET sup_name=@name, sup_contact=@contact, sup_email=@email, 
                                     status=@status, logo_image=@logo 
                                 WHERE sup_id=@sup_id"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@name", newName)
                cmd.Parameters.AddWithValue("@contact", newContact)
                cmd.Parameters.AddWithValue("@email", newEmail)
                cmd.Parameters.AddWithValue("@status", newStatus)
                cmd.Parameters.AddWithValue("@logo", If(logoBytes, DBNull.Value))
                cmd.Parameters.AddWithValue("@sup_id", supID)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Supplier information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            isSaved = True
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error updating supplier: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' === Detect Changes ===
    Private Sub AnyControl_Changed(sender As Object, e As EventArgs) Handles SupplierNameTextBox.TextChanged, ContactTextBox.TextChanged, EmailTextBox.TextChanged, ActiveRadioButton.CheckedChanged, InactiveRadioButton.CheckedChanged
        isSaved = False
    End Sub

    ' === Form Closing ===
    Private Sub EditSupplierForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not isSaved Then
            Dim result As DialogResult = MessageBox.Show("You have unsaved changes. Save before closing?",
                                                         "Unsaved Changes",
                                                         MessageBoxButtons.YesNoCancel,
                                                         MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                SaveButton.PerformClick()
            ElseIf result = DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class
