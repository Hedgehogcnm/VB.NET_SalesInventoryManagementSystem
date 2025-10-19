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
        ProductNameComboBox = New ComboBox()
        Label3 = New Label()
        OrderQuantityTextBox = New TextBox()
        OrderButton = New Button()
        CancelButton = New Button()
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
        Label2.Location = New Point(317, 134)
        Label2.Name = "Label2"
        Label2.Size = New Size(135, 23)
        Label2.TabIndex = 1
        Label2.Text = "Product Name: "
        ' 
        ' ProductNameComboBox
        ' 
        ProductNameComboBox.FormattingEnabled = True
        ProductNameComboBox.Location = New Point(458, 133)
        ProductNameComboBox.Name = "ProductNameComboBox"
        ProductNameComboBox.Size = New Size(210, 28)
        ProductNameComboBox.TabIndex = 2
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label3.Location = New Point(344, 191)
        Label3.Name = "Label3"
        Label3.Size = New Size(165, 23)
        Label3.TabIndex = 3
        Label3.Text = "Quantity to Order: "
        ' 
        ' OrderQuantityTextBox
        ' 
        OrderQuantityTextBox.Location = New Point(515, 190)
        OrderQuantityTextBox.Name = "OrderQuantityTextBox"
        OrderQuantityTextBox.Size = New Size(125, 27)
        OrderQuantityTextBox.TabIndex = 4
        ' 
        ' OrderButton
        ' 
        OrderButton.Location = New Point(515, 378)
        OrderButton.Name = "OrderButton"
        OrderButton.Size = New Size(94, 29)
        OrderButton.TabIndex = 5
        OrderButton.Text = "Order"
        OrderButton.UseVisualStyleBackColor = True
        ' 
        ' CancelButton
        ' 
        CancelButton.Location = New Point(383, 378)
        CancelButton.Name = "CancelButton"
        CancelButton.Size = New Size(94, 29)
        CancelButton.TabIndex = 6
        CancelButton.Text = "Cancel"
        CancelButton.UseVisualStyleBackColor = True
        ' 
        ' OrderProductForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1014, 454)
        Controls.Add(CancelButton)
        Controls.Add(OrderButton)
        Controls.Add(OrderQuantityTextBox)
        Controls.Add(Label3)
        Controls.Add(ProductNameComboBox)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "OrderProductForm"
        Text = "OrderProductForm"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ProductNameComboBox As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents OrderQuantityTextBox As TextBox
    Friend WithEvents OrderButton As Button
    Friend WithEvents CancelButton As Button
End Class
