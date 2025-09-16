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
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        EmailErrorProvider = New ErrorProvider(components)
        CType(EmailErrorProvider, ComponentModel.ISupportInitialize).BeginInit()
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
        ContactTextBox.Location = New Point(274, 217)
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
        EmailTextBox.Location = New Point(274, 265)
        EmailTextBox.Name = "EmailTextBox"
        EmailTextBox.Size = New Size(307, 27)
        EmailTextBox.TabIndex = 2
        ' 
        ' SupplierNameTextBox
        ' 
        SupplierNameTextBox.Location = New Point(274, 167)
        SupplierNameTextBox.Name = "SupplierNameTextBox"
        SupplierNameTextBox.Size = New Size(307, 27)
        SupplierNameTextBox.TabIndex = 0
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label6.Location = New Point(183, 268)
        Label6.Name = "Label6"
        Label6.Size = New Size(64, 23)
        Label6.TabIndex = 9
        Label6.Text = "Email :"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(0, 421)
        Label5.Name = "Label5"
        Label5.Size = New Size(801, 20)
        Label5.TabIndex = 10
        Label5.Text = "------------------------------------------------------------------------------------------------------------------------------------"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label4.Location = New Point(165, 218)
        Label4.Name = "Label4"
        Label4.Size = New Size(82, 23)
        Label4.TabIndex = 8
        Label4.Text = "Contact :"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label3.Location = New Point(107, 168)
        Label3.Name = "Label3"
        Label3.Size = New Size(140, 23)
        Label3.TabIndex = 7
        Label3.Text = "Supplier Name :"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        Label2.Location = New Point(316, 31)
        Label2.Name = "Label2"
        Label2.Size = New Size(169, 35)
        Label2.TabIndex = 4
        Label2.Text = "Add Supplier"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label1.Location = New Point(136, 118)
        Label1.Name = "Label1"
        Label1.Size = New Size(111, 23)
        Label1.TabIndex = 5
        Label1.Text = "Supplier ID :"
        ' 
        ' EmailErrorProvider
        ' 
        EmailErrorProvider.ContainerControl = Me
        ' 
        ' AddSupplierForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(SupplierIDLabel)
        Controls.Add(ContactTextBox)
        Controls.Add(SaveButton)
        Controls.Add(EmailTextBox)
        Controls.Add(SupplierNameTextBox)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "AddSupplierForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "AddSupplierForm"
        CType(EmailErrorProvider, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents SupplierIDLabel As Label
    Friend WithEvents ContactTextBox As TextBox
    Friend WithEvents SaveButton As Button
    Friend WithEvents EmailTextBox As TextBox
    Friend WithEvents SupplierNameTextBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents EmailErrorProvider As ErrorProvider
End Class
