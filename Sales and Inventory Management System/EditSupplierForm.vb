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
        ' === 窗体样式 ===
        Me.BackColor = Color.FromArgb(245, 247, 250)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = New Font("Segoe UI", 10)
        Me.Text = "Edit Supplier"

        ' === 主容器 Panel ===
        MainPanel.BackColor = Color.White
        MainPanel.BorderStyle = BorderStyle.FixedSingle
        MainPanel.Padding = New Padding(20)
        MainPanel.Size = New Size(620, 420)
        MainPanel.Location = New Point((Me.ClientSize.Width - MainPanel.Width) \ 2, (Me.ClientSize.Height - MainPanel.Height) \ 2)

        ' === 标题 ===
        TitleLabel.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        TitleLabel.ForeColor = Color.FromArgb(30, 60, 130)
        TitleLabel.TextAlign = ContentAlignment.MiddleCenter
        TitleLabel.Text = "Edit Supplier"
        TitleLabel.Dock = DockStyle.Top
        TitleLabel.Height = 50

        ' === 标签样式 ===
        For Each lbl As Label In {SupplierIDText, SupplierNameText, ContactText, EmailText, LogoText, StatusText}
            lbl.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            lbl.ForeColor = Color.FromArgb(60, 60, 60)
            lbl.TextAlign = ContentAlignment.MiddleRight
        Next

        ' === TextBox 样式 ===
        For Each txt As TextBox In {SupplierNameTextBox, ContactTextBox, EmailTextBox}
            txt.BorderStyle = BorderStyle.FixedSingle
            txt.Font = New Font("Segoe UI", 10)
            txt.BackColor = Color.FromArgb(250, 250, 250)
        Next

        ' === PictureBox 样式 ===
        With LogoPictureBox
            .BorderStyle = BorderStyle.FixedSingle
            .SizeMode = PictureBoxSizeMode.Zoom
            .BackColor = Color.White
        End With

        ' === 上传按钮 ===
        UploadFileButton.FlatStyle = FlatStyle.Flat
        UploadFileButton.FlatAppearance.BorderSize = 0
        UploadFileButton.BackColor = Color.FromArgb(230, 240, 255)
        UploadFileButton.ForeColor = Color.FromArgb(30, 60, 130)
        UploadFileButton.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        UploadFileButton.Cursor = Cursors.Hand
        AddHandler UploadFileButton.MouseEnter, Sub() UploadFileButton.BackColor = Color.FromArgb(210, 225, 255)
        AddHandler UploadFileButton.MouseLeave, Sub() UploadFileButton.BackColor = Color.FromArgb(230, 240, 255)

        ' === Save 按钮 ===
        SaveButton.FlatStyle = FlatStyle.Flat
        SaveButton.FlatAppearance.BorderSize = 0
        SaveButton.BackColor = Color.FromArgb(70, 130, 230)
        SaveButton.ForeColor = Color.White
        SaveButton.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        SaveButton.Cursor = Cursors.Hand
        AddHandler SaveButton.MouseEnter, Sub() SaveButton.BackColor = Color.FromArgb(90, 150, 255)
        AddHandler SaveButton.MouseLeave, Sub() SaveButton.BackColor = Color.FromArgb(70, 130, 230)

        ' === 载入数据 ===
        LoadSupplierData()
    End Sub

    ' === 载入供应商资料 ===
    Private Sub LoadSupplierData()
        Try
            ConnectDB()
            Dim sql As String = "SELECT sup_id, sup_name, sup_contact, sup_email, status, logo_image 
                                 FROM tb_suppliers WHERE sup_id=@sup_id"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@sup_id", supID)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    SupplierIDLabel.Text = supID.ToString()
                    SupplierNameTextBox.Text = reader("sup_name").ToString()
                    ContactTextBox.Text = reader("sup_contact").ToString()
                    EmailTextBox.Text = reader("sup_email").ToString()

                    ' === 状态单选 ===
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
                        PathLabel.Text = "logo_supplier_" & supID & ".jpg (from DB)"
                        PathLabel.ForeColor = Color.DimGray
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

    ' === 上传新 Logo ===
    Private Sub UploadFileButton_Click(sender As Object, e As EventArgs) Handles UploadFileButton.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
            .Title = "Select Company Logo"
        }

        If ofd.ShowDialog() = DialogResult.OK Then
            logoPath = ofd.FileName
            LogoPictureBox.Image = Image.FromFile(logoPath)
            PathLabel.Text = IO.Path.GetFileName(logoPath) & " (new)"
            PathLabel.ForeColor = Color.FromArgb(40, 100, 180)
            isSaved = False
        End If
    End Sub

    ' === 保存修改 ===
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim newName As String = SupplierNameTextBox.Text.Trim()
        Dim newContact As String = ContactTextBox.Text.Trim()
        Dim newEmail As String = EmailTextBox.Text.Trim()
        Dim newStatus As String = If(ActiveRadioButton.Checked, "Active", "Inactive")
        Dim emailPattern As String = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"

        ' === 邮箱验证 ===
        If Not Regex.IsMatch(newEmail, emailPattern) Then
            EmailErrorProvider.SetError(EmailTextBox, "Invalid email format")
            Return
        Else
            EmailErrorProvider.SetError(EmailTextBox, "")
        End If

        ' === 空白检查 ===
        If newName = "" OrElse newContact = "" OrElse newEmail = "" Then
            MessageBox.Show("All fields are required.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' === 处理 Logo Bytes ===
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

        ' === 执行更新 ===
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

    ' === 检测修改 ===
    Private Sub AnyControl_Changed(sender As Object, e As EventArgs) Handles SupplierNameTextBox.TextChanged, ContactTextBox.TextChanged, EmailTextBox.TextChanged, ActiveRadioButton.CheckedChanged, InactiveRadioButton.CheckedChanged
        isSaved = False
    End Sub

    ' === 离开前检测 ===
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
