<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderProductForm
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
        SupplierComboBox = New ComboBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        Label1.Location = New Point(401, 44)
        Label1.Name = "Label1"
        Label1.Size = New Size(182, 35)
        Label1.TabIndex = 0
        Label1.Text = "Order Product"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label2.Location = New Point(329, 121)
        Label2.Name = "Label2"
        Label2.Size = New Size(114, 23)
        Label2.TabIndex = 1
        Label2.Text = "Order From: "
        ' 
        ' SupplierComboBox
        ' 
        SupplierComboBox.FormattingEnabled = True
        SupplierComboBox.Location = New Point(449, 120)
        SupplierComboBox.Name = "SupplierComboBox"
        SupplierComboBox.Size = New Size(203, 28)
        SupplierComboBox.TabIndex = 2
        ' 
        ' OrderProductForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1014, 454)
        Controls.Add(SupplierComboBox)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "OrderProductForm"
        Text = "OrderProductForm"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents SupplierComboBox As ComboBox
End Class
