Imports System.IO
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class AddSupplierForm
    Private isSaved As Boolean = True
    Private id As Integer

    ' 初始化
    Public Sub New(addSupplierID As Integer)
        InitializeComponent()
        id = addSupplierID
    End Sub

    Private Sub AddSupplierForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' === 整体背景 ===
        Me.BackColor = Color.FromArgb(255, 247, 238) ' 柔和米橙色
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = New Font("Segoe UI", 10)
        Me.Text = "Add Supplier"

        ' === 主Panel ===
        MainPanel.BackColor = Color.White
        MainPanel.BorderStyle = BorderStyle.None
        MainPanel.Padding = New Padding(30)
        MainPanel.Size = New Size(600, 400)
        MainPanel.Location = New Point((Me.ClientSize.Width - MainPanel.Width) \ 2, (Me.ClientSize.Height - MainPanel.Height) \ 2)

        ' === 标题 ===
        TitleLabel.Font = New Font("Segoe UI Semibold", 16, FontStyle.Bold)
        TitleLabel.ForeColor = Color.FromArgb(120, 80, 40) ' 深咖橙色
        TitleLabel.TextAlign = ContentAlignment.MiddleLeft
        TitleLabel.Text = "Add Supplier"
        TitleLabel.Dock = DockStyle.Top
        TitleLabel.Height = 45

        ' === 标签样式 ===
        For Each lbl As Label In {SupplierIDText, SupplierNameText, ContactText, EmailText, LogoText}
            lbl.Font = New Font("Segoe UI Semibold", 10)
            lbl.ForeColor = Color.FromArgb(100, 70, 50)
            lbl.TextAlign = ContentAlignment.MiddleRight
        Next

        ' === TextBox 样式 ===
        For Each txt As TextBox In {SupplierNameTextBox, ContactTextBox, EmailTextBox}
            txt.BorderStyle = BorderStyle.FixedSingle
            txt.Font = New Font("Segoe UI", 10)
            txt.BackColor = Color.White
            txt.ForeColor = Color.FromArgb(50, 50, 50)
        Next

        ' === 上传按钮 ===
        UploadFileButton.FlatStyle = FlatStyle.Flat
        UploadFileButton.FlatAppearance.BorderSize = 0
        UploadFileButton.BackColor = Color.FromArgb(255, 235, 215) ' 浅杏色
        UploadFileButton.ForeColor = Color.FromArgb(120, 80, 40)
        UploadFileButton.Font = New Font("Segoe UI Semibold", 9)
        UploadFileButton.Cursor = Cursors.Hand
        AddHandler UploadFileButton.MouseEnter, Sub() UploadFileButton.BackColor = Color.FromArgb(255, 225, 200)
        AddHandler UploadFileButton.MouseLeave, Sub() UploadFileButton.BackColor = Color.FromArgb(255, 235, 215)

        ' === Save 按钮 ===
        SaveButton.FlatStyle = FlatStyle.Flat
        SaveButton.FlatAppearance.BorderSize = 0
        SaveButton.BackColor = Color.FromArgb(230, 140, 70)
        SaveButton.ForeColor = Color.White
        SaveButton.Font = New Font("Segoe UI Semibold", 10)
        SaveButton.Cursor = Cursors.Hand
        AddHandler SaveButton.MouseEnter, Sub() SaveButton.BackColor = Color.FromArgb(255, 160, 90)
        AddHandler SaveButton.MouseLeave, Sub() SaveButton.BackColor = Color.FromArgb(230, 140, 70)

        ' === 图片预览 ===
        LogoPictureBox.BorderStyle = BorderStyle.FixedSingle
        LogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        LogoPictureBox.BackColor = Color.FromArgb(255, 245, 230)

    End Sub

    ' 检测修改
    Private Sub AnyControl_Changed(sender As Object, e As EventArgs) Handles SupplierNameTextBox.TextChanged, ContactTextBox.TextChanged, EmailTextBox.TextChanged
        isSaved = False
    End Sub

    ' 保存按钮
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim name As String = SupplierNameTextBox.Text.Trim()
        Dim contact As String = ContactTextBox.Text.Trim()
        Dim email As String = EmailTextBox.Text.Trim()
        Dim emailPattern As String = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"

        ' === Email 验证 ===
        If Not Regex.IsMatch(email, emailPattern) Then
            EmailErrorProvider.SetError(EmailTextBox, "Invalid email format")
            Return
        Else
            EmailErrorProvider.SetError(EmailTextBox, "")
        End If

        ' === 空白检查 ===
        If name = "" OrElse contact = "" OrElse email = "" Then
            MessageBox.Show("All fields are required.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ConnectDB()

            ' === 图片转 BLOB ===
            Dim logoBytes() As Byte = Nothing
            If PathLabel.Text <> "" AndAlso IO.File.Exists(PathLabel.Text) Then
                logoBytes = IO.File.ReadAllBytes(PathLabel.Text)
            End If

            Dim sql As String = "INSERT INTO tb_suppliers (sup_name, sup_contact, sup_email, status, logo_image)
                                 VALUES (@name, @contact, @email, @status, @logo)"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@name", name)
                cmd.Parameters.AddWithValue("@contact", contact)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@status", "Active")
                cmd.Parameters.AddWithValue("@logo", If(logoBytes, DBNull.Value))
                cmd.ExecuteNonQuery()
            End Using

            isSaved = True
            MessageBox.Show("Supplier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error adding supplier: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' 上传 Logo
    Private Sub UploadFileButton_Click(sender As Object, e As EventArgs) Handles UploadFileButton.Click
        Dim ofd As New OpenFileDialog With {
            .Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
            .Title = "Select Company Logo"
        }

        If ofd.ShowDialog() = DialogResult.OK Then
            LogoPictureBox.Image = Image.FromFile(ofd.FileName)
            PathLabel.Text = System.IO.Path.GetFileName(ofd.FileName)
            PathLabel.ForeColor = Color.FromArgb(60, 60, 60)
            LogoPictureBox.BackColor = Color.White
        End If

    End Sub

    ' 离开前检测是否保存
    Private Sub AddSupplierForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not isSaved Then
            Dim result As DialogResult = MessageBox.Show("You have unsaved changes. Save before closing?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                SaveButton.PerformClick()
            ElseIf result = DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class
