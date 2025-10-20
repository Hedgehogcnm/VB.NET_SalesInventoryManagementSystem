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
        Label1 = New Label()
        Label2 = New Label()
        usernameTextBox = New TextBox()
        passwordTextBox = New TextBox()
        loginButton = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(491, 261)
        Label1.Name = "Label1"
        Label1.Size = New Size(78, 20)
        Label1.TabIndex = 0
        Label1.Text = "Username:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(491, 315)
        Label2.Name = "Label2"
        Label2.Size = New Size(73, 20)
        Label2.TabIndex = 1
        Label2.Text = "Password:"
        ' 
        ' usernameTextBox
        ' 
        usernameTextBox.Location = New Point(635, 265)
        usernameTextBox.Name = "usernameTextBox"
        usernameTextBox.Size = New Size(125, 27)
        usernameTextBox.TabIndex = 2
        ' 
        ' passwordTextBox
        ' 
        passwordTextBox.Location = New Point(635, 312)
        passwordTextBox.Name = "passwordTextBox"
        passwordTextBox.Size = New Size(125, 27)
        passwordTextBox.TabIndex = 3
        ' 
        ' loginButton
        ' 
        loginButton.Location = New Point(573, 387)
        loginButton.Name = "loginButton"
        loginButton.Size = New Size(94, 29)
        loginButton.TabIndex = 4
        loginButton.Text = "Log In"
        loginButton.UseVisualStyleBackColor = True
        ' 
        ' LoginForm
        ' 
        AcceptButton = loginButton
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1502, 773)
        Controls.Add(loginButton)
        Controls.Add(passwordTextBox)
        Controls.Add(usernameTextBox)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "LoginForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login Form"
        WindowState = FormWindowState.Maximized
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents usernameTextBox As TextBox
    Friend WithEvents passwordTextBox As TextBox
    Friend WithEvents loginButton As Button

End Class
