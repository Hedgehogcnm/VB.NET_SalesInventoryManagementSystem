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
        Label2 = New Label()
        Label1 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        SupplierNameTextBox = New TextBox()
        EmailTextBox = New TextBox()
        Label8 = New Label()
        ActiveRadioButton = New RadioButton()
        InactiveRadioButton = New RadioButton()
        SaveButton = New Button()
        ContactTextBox = New TextBox()
        SupplierIDLabel = New Label()
        EmailErrorProvider = New ErrorProvider(components)
        CType(EmailErrorProvider, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        Label2.Location = New Point(316, 32)
        Label2.Name = "Label2"
        Label2.Size = New Size(166, 35)
        Label2.TabIndex = 7
        Label2.Text = "Edit Supplier"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label1.Location = New Point(135, 119)
        Label1.Name = "Label1"
        Label1.Size = New Size(111, 23)
        Label1.TabIndex = 8
        Label1.Text = "Supplier ID :"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label3.Location = New Point(106, 169)
        Label3.Name = "Label3"
        Label3.Size = New Size(140, 23)
        Label3.TabIndex = 10
        Label3.Text = "Supplier Name :"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label4.Location = New Point(164, 219)
        Label4.Name = "Label4"
        Label4.Size = New Size(82, 23)
        Label4.TabIndex = 11
        Label4.Text = "Contact :"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(-1, 422)
        Label5.Name = "Label5"
        Label5.Size = New Size(801, 20)
        Label5.TabIndex = 14
        Label5.Text = "------------------------------------------------------------------------------------------------------------------------------------"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label6.Location = New Point(182, 269)
        Label6.Name = "Label6"
        Label6.Size = New Size(64, 23)
        Label6.TabIndex = 12
        Label6.Text = "Email :"
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
        SupplierNameTextBox.Location = New Point(273, 168)
        SupplierNameTextBox.Name = "SupplierNameTextBox"
        SupplierNameTextBox.Size = New Size(307, 27)
        SupplierNameTextBox.TabIndex = 0
        ' 
        ' EmailTextBox
        ' 
        EmailTextBox.Location = New Point(273, 266)
        EmailTextBox.Name = "EmailTextBox"
        EmailTextBox.Size = New Size(307, 27)
        EmailTextBox.TabIndex = 2
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label8.Location = New Point(176, 319)
        Label8.Name = "Label8"
        Label8.Size = New Size(70, 23)
        Label8.TabIndex = 13
        Label8.Text = "Status :"
        ' 
        ' ActiveRadioButton
        ' 
        ActiveRadioButton.AutoSize = True
        ActiveRadioButton.Location = New Point(274, 319)
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
        InactiveRadioButton.Location = New Point(371, 318)
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
        ContactTextBox.Location = New Point(273, 218)
        ContactTextBox.Name = "ContactTextBox"
        ContactTextBox.Size = New Size(307, 27)
        ContactTextBox.TabIndex = 1
        ' 
        ' SupplierIDLabel
        ' 
        SupplierIDLabel.AutoSize = True
        SupplierIDLabel.Font = New Font("Segoe UI", 10F)
        SupplierIDLabel.Location = New Point(274, 122)
        SupplierIDLabel.Name = "SupplierIDLabel"
        SupplierIDLabel.Size = New Size(0, 23)
        SupplierIDLabel.TabIndex = 9
        ' 
        ' EmailErrorProvider
        ' 
        EmailErrorProvider.ContainerControl = Me
        ' 
        ' EditSupplierForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(SupplierIDLabel)
        Controls.Add(ContactTextBox)
        Controls.Add(SaveButton)
        Controls.Add(InactiveRadioButton)
        Controls.Add(ActiveRadioButton)
        Controls.Add(Label8)
        Controls.Add(EmailTextBox)
        Controls.Add(SupplierNameTextBox)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "EditSupplierForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "EditSupplierForm"
        CType(EmailErrorProvider, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents SupplierNameTextBox As TextBox
    Friend WithEvents EmailTextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents ActiveRadioButton As RadioButton
    Friend WithEvents InactiveRadioButton As RadioButton
    Friend WithEvents SaveButton As Button
    Friend WithEvents ContactTextBox As TextBox
    Friend WithEvents SupplierIDLabel As Label
    Friend WithEvents EmailErrorProvider As ErrorProvider
End Class
