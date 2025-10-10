<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditProductForm
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
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        SaveButton = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        Label1.Location = New Point(383, 50)
        Label1.Name = "Label1"
        Label1.Size = New Size(159, 35)
        Label1.TabIndex = 0
        Label1.Text = "Edit Product"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label2.Location = New Point(144, 144)
        Label2.Name = "Label2"
        Label2.Size = New Size(106, 23)
        Label2.TabIndex = 1
        Label2.Text = "Product ID: "
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label3.Location = New Point(144, 210)
        Label3.Name = "Label3"
        Label3.Size = New Size(140, 23)
        Label3.TabIndex = 2
        Label3.Text = "Product Name： "
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label4.Location = New Point(144, 272)
        Label4.Name = "Label4"
        Label4.Size = New Size(162, 23)
        Label4.TabIndex = 3
        Label4.Text = "Product Category: "
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label5.Location = New Point(613, 144)
        Label5.Name = "Label5"
        Label5.Size = New Size(134, 23)
        Label5.TabIndex = 4
        Label5.Text = "Product Stock: "
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label6.Location = New Point(530, 210)
        Label6.Name = "Label6"
        Label6.Size = New Size(217, 23)
        Label6.TabIndex = 5
        Label6.Text = "Product Minimum Stock: "
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label7.Location = New Point(580, 272)
        Label7.Name = "Label7"
        Label7.Size = New Size(167, 23)
        Label7.TabIndex = 6
        Label7.Text = "Product Cost Price: "
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label8.Location = New Point(586, 327)
        Label8.Name = "Label8"
        Label8.Size = New Size(161, 23)
        Label8.TabIndex = 7
        Label8.Text = "Product Sell Price: "
        ' 
        ' SaveButton
        ' 
        SaveButton.Location = New Point(776, 434)
        SaveButton.Name = "SaveButton"
        SaveButton.Size = New Size(94, 29)
        SaveButton.TabIndex = 8
        SaveButton.Text = "Save"
        SaveButton.UseVisualStyleBackColor = True
        ' 
        ' EditProductForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(943, 480)
        Controls.Add(SaveButton)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "EditProductForm"
        Text = "EditProductForm"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents SaveButton As Button
End Class
