<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddUserForm
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
        MainPanel = New Panel()
        SaveButton = New Button()
        RoleComboBox = New ComboBox()
        PasswordTextBox = New TextBox()
        UserNameTextBox = New TextBox()
        RoleText = New Label()
        PasswordText = New Label()
        UserNameText = New Label()
        TitleLabel = New Label()
        MainPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' MainPanel
        ' 
        MainPanel.Controls.Add(SaveButton)
        MainPanel.Controls.Add(RoleComboBox)
        MainPanel.Controls.Add(PasswordTextBox)
        MainPanel.Controls.Add(UserNameTextBox)
        MainPanel.Controls.Add(RoleText)
        MainPanel.Controls.Add(PasswordText)
        MainPanel.Controls.Add(UserNameText)
        MainPanel.Controls.Add(TitleLabel)
        MainPanel.Dock = DockStyle.Fill
        MainPanel.Location = New Point(0, 0)
        MainPanel.Name = "MainPanel"
        MainPanel.Size = New Size(800, 450)
        MainPanel.TabIndex = 0
        ' 
        ' SaveButton
        ' 
        SaveButton.BackColor = Color.SeaShell
        SaveButton.FlatStyle = FlatStyle.Flat
        SaveButton.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        SaveButton.ForeColor = Color.Sienna
        SaveButton.Location = New Point(353, 353)
        SaveButton.Name = "SaveButton"
        SaveButton.Size = New Size(94, 29)
        SaveButton.TabIndex = 7
        SaveButton.Text = "Save"
        SaveButton.UseVisualStyleBackColor = False
        ' 
        ' RoleComboBox
        ' 
        RoleComboBox.AllowDrop = True
        RoleComboBox.FormattingEnabled = True
        RoleComboBox.Items.AddRange(New Object() {"admin", "staff"})
        RoleComboBox.Location = New Point(410, 242)
        RoleComboBox.Name = "RoleComboBox"
        RoleComboBox.Size = New Size(151, 28)
        RoleComboBox.TabIndex = 6
        ' 
        ' PasswordTextBox
        ' 
        PasswordTextBox.Location = New Point(410, 190)
        PasswordTextBox.Name = "PasswordTextBox"
        PasswordTextBox.Size = New Size(151, 27)
        PasswordTextBox.TabIndex = 5
        ' 
        ' UserNameTextBox
        ' 
        UserNameTextBox.Location = New Point(410, 136)
        UserNameTextBox.Name = "UserNameTextBox"
        UserNameTextBox.Size = New Size(151, 27)
        UserNameTextBox.TabIndex = 4
        ' 
        ' RoleText
        ' 
        RoleText.AutoSize = True
        RoleText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        RoleText.Location = New Point(249, 242)
        RoleText.Name = "RoleText"
        RoleText.Size = New Size(78, 23)
        RoleText.TabIndex = 3
        RoleText.Text = "RoleText"
        ' 
        ' PasswordText
        ' 
        PasswordText.AutoSize = True
        PasswordText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        PasswordText.Location = New Point(249, 193)
        PasswordText.Name = "PasswordText"
        PasswordText.Size = New Size(135, 23)
        PasswordText.TabIndex = 2
        PasswordText.Text = "User Password :"
        ' 
        ' UserNameText
        ' 
        UserNameText.AutoSize = True
        UserNameText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        UserNameText.Location = New Point(249, 139)
        UserNameText.Name = "UserNameText"
        UserNameText.Size = New Size(67, 23)
        UserNameText.TabIndex = 1
        UserNameText.Text = "Name :"
        ' 
        ' TitleLabel
        ' 
        TitleLabel.AutoSize = True
        TitleLabel.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        TitleLabel.Location = New Point(333, 53)
        TitleLabel.Name = "TitleLabel"
        TitleLabel.Size = New Size(135, 37)
        TitleLabel.TabIndex = 0
        TitleLabel.Text = "Add User"
        ' 
        ' AddUserForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SeaShell
        ClientSize = New Size(800, 450)
        Controls.Add(MainPanel)
        Name = "AddUserForm"
        StartPosition = FormStartPosition.CenterScreen
        MainPanel.ResumeLayout(False)
        MainPanel.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents MainPanel As Panel
    Friend WithEvents TitleLabel As Label
    Friend WithEvents UserNameText As Label
    Friend WithEvents PasswordText As Label
    Friend WithEvents RoleText As Label
    Friend WithEvents RoleComboBox As ComboBox
    Friend WithEvents PasswordTextBox As TextBox
    Friend WithEvents UserNameTextBox As TextBox
    Friend WithEvents SaveButton As Button
End Class
