<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        UsernameLabel = New Label()
        PasswordLabel = New Label()
        usernameTextBox = New TextBox()
        passwordTextBox = New TextBox()
        loginButton = New Button()
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' UsernameLabel
        ' 
        UsernameLabel.AutoSize = True
        UsernameLabel.Location = New Point(967, 336)
        UsernameLabel.Name = "UsernameLabel"
        UsernameLabel.Size = New Size(78, 20)
        UsernameLabel.TabIndex = 0
        UsernameLabel.Text = "Username:"
        ' 
        ' PasswordLabel
        ' 
        PasswordLabel.AutoSize = True
        PasswordLabel.Location = New Point(967, 390)
        PasswordLabel.Name = "PasswordLabel"
        PasswordLabel.Size = New Size(73, 20)
        PasswordLabel.TabIndex = 1
        PasswordLabel.Text = "Password:"
        ' 
        ' usernameTextBox
        ' 
        usernameTextBox.Location = New Point(1111, 340)
        usernameTextBox.Name = "usernameTextBox"
        usernameTextBox.Size = New Size(125, 27)
        usernameTextBox.TabIndex = 2
        ' 
        ' passwordTextBox
        ' 
        passwordTextBox.Location = New Point(1111, 387)
        passwordTextBox.Name = "passwordTextBox"
        passwordTextBox.Size = New Size(125, 27)
        passwordTextBox.TabIndex = 3
        ' 
        ' loginButton
        ' 
        loginButton.Location = New Point(1049, 462)
        loginButton.Name = "loginButton"
        loginButton.Size = New Size(94, 29)
        loginButton.TabIndex = 4
        loginButton.Text = "Log In"
        loginButton.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.logo__500_
        PictureBox1.Location = New Point(278, 171)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(500, 500)
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        ' 
        ' LoginForm
        ' 
        AcceptButton = loginButton
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SeaShell
        ClientSize = New Size(1502, 773)
        Controls.Add(PictureBox1)
        Controls.Add(loginButton)
        Controls.Add(passwordTextBox)
        Controls.Add(usernameTextBox)
        Controls.Add(PasswordLabel)
        Controls.Add(UsernameLabel)
        Name = "LoginForm"
        StartPosition = FormStartPosition.CenterScreen
        WindowState = FormWindowState.Maximized
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents UsernameLabel As Label
    Friend WithEvents PasswordLabel As Label
    Friend WithEvents usernameTextBox As TextBox
    Friend WithEvents passwordTextBox As TextBox
    Friend WithEvents loginButton As Button
    Friend WithEvents PictureBox1 As PictureBox

End Class
