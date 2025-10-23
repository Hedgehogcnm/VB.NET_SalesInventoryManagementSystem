<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddSupplierForm
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
        SupplierIDLabel = New Label()
        ContactTextBox = New TextBox()
        SaveButton = New Button()
        EmailTextBox = New TextBox()
        SupplierNameTextBox = New TextBox()
        EmailText = New Label()
        Label5 = New Label()
        ContactText = New Label()
        SupplierNameText = New Label()
        TitleLabel = New Label()
        SupplierIDText = New Label()
        EmailErrorProvider = New ErrorProvider(components)
        LogoText = New Label()
        UploadFileButton = New Button()
        PathLabel = New Label()
        MainPanel = New Panel()
        LogoPictureBox = New PictureBox()
        CType(EmailErrorProvider, ComponentModel.ISupportInitialize).BeginInit()
        MainPanel.SuspendLayout()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' SupplierIDLabel
        ' 
        SupplierIDLabel.AutoSize = True
        SupplierIDLabel.Font = New Font("Segoe UI", 10F)
        SupplierIDLabel.Location = New Point(275, 121)
        SupplierIDLabel.Name = "SupplierIDLabel"
        SupplierIDLabel.Size = New Size(0, 23)
        SupplierIDLabel.TabIndex = 6
        ' 
        ' ContactTextBox
        ' 
        ContactTextBox.Location = New Point(275, 284)
        ContactTextBox.Name = "ContactTextBox"
        ContactTextBox.Size = New Size(307, 27)
        ContactTextBox.TabIndex = 1
        ' 
        ' SaveButton
        ' 
        SaveButton.Location = New Point(623, 369)
        SaveButton.Name = "SaveButton"
        SaveButton.Size = New Size(94, 29)
        SaveButton.TabIndex = 3
        SaveButton.Text = "Save"
        SaveButton.UseVisualStyleBackColor = True
        ' 
        ' EmailTextBox
        ' 
        EmailTextBox.Location = New Point(275, 332)
        EmailTextBox.Name = "EmailTextBox"
        EmailTextBox.Size = New Size(307, 27)
        EmailTextBox.TabIndex = 2
        ' 
        ' SupplierNameTextBox
        ' 
        SupplierNameTextBox.Location = New Point(275, 234)
        SupplierNameTextBox.Name = "SupplierNameTextBox"
        SupplierNameTextBox.Size = New Size(307, 27)
        SupplierNameTextBox.TabIndex = 0
        ' 
        ' EmailText
        ' 
        EmailText.AutoSize = True
        EmailText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        EmailText.Location = New Point(184, 335)
        EmailText.Name = "EmailText"
        EmailText.Size = New Size(64, 23)
        EmailText.TabIndex = 9
        EmailText.Text = "Email :"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(0, 421)
        Label5.Name = "Label5"
        Label5.Size = New Size(0, 20)
        Label5.TabIndex = 10
        ' 
        ' ContactText
        ' 
        ContactText.AutoSize = True
        ContactText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        ContactText.Location = New Point(166, 285)
        ContactText.Name = "ContactText"
        ContactText.Size = New Size(82, 23)
        ContactText.TabIndex = 8
        ContactText.Text = "Contact :"
        ' 
        ' SupplierNameText
        ' 
        SupplierNameText.AutoSize = True
        SupplierNameText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        SupplierNameText.Location = New Point(108, 235)
        SupplierNameText.Name = "SupplierNameText"
        SupplierNameText.Size = New Size(140, 23)
        SupplierNameText.TabIndex = 7
        SupplierNameText.Text = "Supplier Name :"
        ' 
        ' TitleLabel
        ' 
        TitleLabel.AutoSize = True
        TitleLabel.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        TitleLabel.Location = New Point(316, 31)
        TitleLabel.Name = "TitleLabel"
        TitleLabel.Size = New Size(169, 35)
        TitleLabel.TabIndex = 4
        TitleLabel.Text = "Add Supplier"
        ' 
        ' SupplierIDText
        ' 
        SupplierIDText.AutoSize = True
        SupplierIDText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        SupplierIDText.Location = New Point(136, 118)
        SupplierIDText.Name = "SupplierIDText"
        SupplierIDText.Size = New Size(111, 23)
        SupplierIDText.TabIndex = 5
        SupplierIDText.Text = "Supplier ID :"
        ' 
        ' EmailErrorProvider
        ' 
        EmailErrorProvider.ContainerControl = Me
        ' 
        ' LogoText
        ' 
        LogoText.AutoSize = True
        LogoText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        LogoText.Location = New Point(114, 163)
        LogoText.Name = "LogoText"
        LogoText.Size = New Size(133, 23)
        LogoText.TabIndex = 11
        LogoText.Text = "Supplier Logo :"
        ' 
        ' UploadFileButton
        ' 
        UploadFileButton.Location = New Point(274, 161)
        UploadFileButton.Name = "UploadFileButton"
        UploadFileButton.Size = New Size(94, 29)
        UploadFileButton.TabIndex = 12
        UploadFileButton.Text = "Upload File"
        UploadFileButton.UseVisualStyleBackColor = True
        ' 
        ' PathLabel
        ' 
        PathLabel.AutoSize = True
        PathLabel.Location = New Point(274, 194)
        PathLabel.Name = "PathLabel"
        PathLabel.Size = New Size(0, 20)
        PathLabel.TabIndex = 14
        ' 
        ' MainPanel
        ' 
        MainPanel.Controls.Add(LogoPictureBox)
        MainPanel.Dock = DockStyle.Fill
        MainPanel.Location = New Point(0, 0)
        MainPanel.Name = "MainPanel"
        MainPanel.Size = New Size(800, 450)
        MainPanel.TabIndex = 15
        ' 
        ' LogoPictureBox
        ' 
        LogoPictureBox.BackColor = Color.White
        LogoPictureBox.Location = New Point(613, 27)
        LogoPictureBox.Name = "LogoPictureBox"
        LogoPictureBox.Size = New Size(115, 114)
        LogoPictureBox.TabIndex = 14
        LogoPictureBox.TabStop = False
        ' 
        ' AddSupplierForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(PathLabel)
        Controls.Add(UploadFileButton)
        Controls.Add(LogoText)
        Controls.Add(SupplierIDLabel)
        Controls.Add(ContactTextBox)
        Controls.Add(SaveButton)
        Controls.Add(EmailTextBox)
        Controls.Add(SupplierNameTextBox)
        Controls.Add(EmailText)
        Controls.Add(Label5)
        Controls.Add(ContactText)
        Controls.Add(SupplierNameText)
        Controls.Add(TitleLabel)
        Controls.Add(SupplierIDText)
        Controls.Add(MainPanel)
        Name = "AddSupplierForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "AddSupplierForm"
        CType(EmailErrorProvider, ComponentModel.ISupportInitialize).EndInit()
        MainPanel.ResumeLayout(False)
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents SupplierIDLabel As Label
    Friend WithEvents ContactTextBox As TextBox
    Friend WithEvents SaveButton As Button
    Friend WithEvents EmailTextBox As TextBox
    Friend WithEvents SupplierNameTextBox As TextBox
    Friend WithEvents EmailText As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ContactText As Label
    Friend WithEvents SupplierNameText As Label
    Friend WithEvents TitleLabel As Label
    Friend WithEvents SupplierIDText As Label
    Friend WithEvents EmailErrorProvider As ErrorProvider
    Friend WithEvents UploadFileButton As Button
    Friend WithEvents LogoText As Label
    Friend WithEvents PathLabel As Label
    Friend WithEvents MainPanel As Panel
    Friend WithEvents LogoPictureBox As PictureBox
End Class
