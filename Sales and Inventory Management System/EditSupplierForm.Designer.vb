<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditSupplierForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        TitleLabel = New Label()
        SupplierNameText = New Label()
        ContactText = New Label()
        EmailText = New Label()
        Label7 = New Label()
        SupplierNameTextBox = New TextBox()
        EmailTextBox = New TextBox()
        StatusText = New Label()
        ActiveRadioButton = New RadioButton()
        InactiveRadioButton = New RadioButton()
        SaveButton = New Button()
        ContactTextBox = New TextBox()
        EmailErrorProvider = New ErrorProvider(components)
        MainPanel = New Panel()
        LogoPictureBox = New PictureBox()
        PathLabel = New Label()
        UploadFileButton = New Button()
        LogoText = New Label()
        CType(EmailErrorProvider, ComponentModel.ISupportInitialize).BeginInit()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TitleLabel
        ' 
        TitleLabel.AutoSize = True
        TitleLabel.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        TitleLabel.Location = New Point(316, 32)
        TitleLabel.Name = "TitleLabel"
        TitleLabel.Size = New Size(166, 35)
        TitleLabel.TabIndex = 7
        TitleLabel.Text = "Edit Supplier"
        ' 
        ' SupplierNameText
        ' 
        SupplierNameText.AutoSize = True
        SupplierNameText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        SupplierNameText.Location = New Point(111, 97)
        SupplierNameText.Name = "SupplierNameText"
        SupplierNameText.Size = New Size(140, 23)
        SupplierNameText.TabIndex = 10
        SupplierNameText.Text = "Supplier Name :"
        ' 
        ' ContactText
        ' 
        ContactText.AutoSize = True
        ContactText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        ContactText.Location = New Point(169, 147)
        ContactText.Name = "ContactText"
        ContactText.Size = New Size(82, 23)
        ContactText.TabIndex = 11
        ContactText.Text = "Contact :"
        ' 
        ' EmailText
        ' 
        EmailText.AutoSize = True
        EmailText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        EmailText.Location = New Point(187, 197)
        EmailText.Name = "EmailText"
        EmailText.Size = New Size(64, 23)
        EmailText.TabIndex = 12
        EmailText.Text = "Email :"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(0, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(0, 20)
        Label7.TabIndex = 6
        ' 
        ' SupplierNameTextBox
        ' 
        SupplierNameTextBox.Location = New Point(278, 96)
        SupplierNameTextBox.Name = "SupplierNameTextBox"
        SupplierNameTextBox.Size = New Size(307, 27)
        SupplierNameTextBox.TabIndex = 0
        ' 
        ' EmailTextBox
        ' 
        EmailTextBox.Location = New Point(278, 194)
        EmailTextBox.Name = "EmailTextBox"
        EmailTextBox.Size = New Size(307, 27)
        EmailTextBox.TabIndex = 2
        ' 
        ' StatusText
        ' 
        StatusText.AutoSize = True
        StatusText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        StatusText.Location = New Point(181, 247)
        StatusText.Name = "StatusText"
        StatusText.Size = New Size(70, 23)
        StatusText.TabIndex = 13
        StatusText.Text = "Status :"
        ' 
        ' ActiveRadioButton
        ' 
        ActiveRadioButton.AutoSize = True
        ActiveRadioButton.Location = New Point(279, 248)
        ActiveRadioButton.Name = "ActiveRadioButton"
        ActiveRadioButton.Size = New Size(71, 24)
        ActiveRadioButton.TabIndex = 3
        ActiveRadioButton.TabStop = True
        ActiveRadioButton.Text = "Active"
        ActiveRadioButton.UseVisualStyleBackColor = True
        ' 
        ' InactiveRadioButton
        ' 
        InactiveRadioButton.AutoSize = True
        InactiveRadioButton.Location = New Point(376, 248)
        InactiveRadioButton.Name = "InactiveRadioButton"
        InactiveRadioButton.Size = New Size(81, 24)
        InactiveRadioButton.TabIndex = 4
        InactiveRadioButton.TabStop = True
        InactiveRadioButton.Text = "Inactive"
        InactiveRadioButton.UseVisualStyleBackColor = True
        ' 
        ' SaveButton
        ' 
        SaveButton.Location = New Point(622, 370)
        SaveButton.Name = "SaveButton"
        SaveButton.Size = New Size(94, 29)
        SaveButton.TabIndex = 5
        SaveButton.Text = "Save"
        SaveButton.UseVisualStyleBackColor = True
        ' 
        ' ContactTextBox
        ' 
        ContactTextBox.Location = New Point(278, 146)
        ContactTextBox.Name = "ContactTextBox"
        ContactTextBox.Size = New Size(307, 27)
        ContactTextBox.TabIndex = 1
        ' 
        ' EmailErrorProvider
        ' 
        EmailErrorProvider.ContainerControl = Me
        ' 
        ' MainPanel
        ' 
        MainPanel.Dock = DockStyle.Fill
        MainPanel.Location = New Point(0, 0)
        MainPanel.Name = "MainPanel"
        MainPanel.Size = New Size(800, 467)
        MainPanel.TabIndex = 16
        ' 
        ' LogoPictureBox
        ' 
        LogoPictureBox.BackColor = Color.White
        LogoPictureBox.Location = New Point(279, 328)
        LogoPictureBox.Name = "LogoPictureBox"
        LogoPictureBox.Size = New Size(115, 114)
        LogoPictureBox.TabIndex = 13
        LogoPictureBox.TabStop = False
        ' 
        ' PathLabel
        ' 
        PathLabel.AutoSize = True
        PathLabel.Location = New Point(397, 420)
        PathLabel.Name = "PathLabel"
        PathLabel.Size = New Size(0, 20)
        PathLabel.TabIndex = 19
        ' 
        ' UploadFileButton
        ' 
        UploadFileButton.Location = New Point(279, 293)
        UploadFileButton.Name = "UploadFileButton"
        UploadFileButton.Size = New Size(94, 29)
        UploadFileButton.TabIndex = 18
        UploadFileButton.Text = "Upload File"
        UploadFileButton.UseVisualStyleBackColor = True
        ' 
        ' LogoText
        ' 
        LogoText.AutoSize = True
        LogoText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        LogoText.Location = New Point(119, 295)
        LogoText.Name = "LogoText"
        LogoText.Size = New Size(133, 23)
        LogoText.TabIndex = 17
        LogoText.Text = "Supplier Logo :"
        ' 
        ' EditSupplierForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 467)
        Controls.Add(LogoPictureBox)
        Controls.Add(PathLabel)
        Controls.Add(UploadFileButton)
        Controls.Add(LogoText)
        Controls.Add(ContactTextBox)
        Controls.Add(SaveButton)
        Controls.Add(InactiveRadioButton)
        Controls.Add(ActiveRadioButton)
        Controls.Add(StatusText)
        Controls.Add(EmailTextBox)
        Controls.Add(SupplierNameTextBox)
        Controls.Add(Label7)
        Controls.Add(EmailText)
        Controls.Add(ContactText)
        Controls.Add(SupplierNameText)
        Controls.Add(TitleLabel)
        Controls.Add(MainPanel)
        Name = "EditSupplierForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "EditSupplierForm"
        CType(EmailErrorProvider, ComponentModel.ISupportInitialize).EndInit()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents TitleLabel As Label
    Friend WithEvents SupplierNameText As Label
    Friend WithEvents ContactText As Label
    Friend WithEvents EmailText As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents SupplierNameTextBox As TextBox
    Friend WithEvents EmailTextBox As TextBox
    Friend WithEvents StatusText As Label
    Friend WithEvents ActiveRadioButton As RadioButton
    Friend WithEvents InactiveRadioButton As RadioButton
    Friend WithEvents SaveButton As Button
    Friend WithEvents ContactTextBox As TextBox
    Friend WithEvents EmailErrorProvider As ErrorProvider
    Friend WithEvents MainPanel As Panel
    Friend WithEvents LogoPictureBox As PictureBox
    Friend WithEvents PathLabel As Label
    Friend WithEvents UploadFileButton As Button
    Friend WithEvents LogoText As Label
End Class
