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
        ViewOrderButton = New Button()
        Label4 = New Label()
        ProductIDLabel = New Label()
        Label5 = New Label()
        Label6 = New Label()
        UnitPriceLabel = New Label()
        TotalPriceLabel = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        Label1.Location = New Point(402, 24)
        Label1.Name = "Label1"
        Label1.Size = New Size(182, 35)
        Label1.TabIndex = 0
        Label1.Text = "Order Product"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label2.Location = New Point(317, 86)
        Label2.Name = "Label2"
        Label2.Size = New Size(135, 23)
        Label2.TabIndex = 1
        Label2.Text = "Product Name: "
        ' 
        ' ProductNameComboBox
        ' 
        ProductNameComboBox.FormattingEnabled = True
        ProductNameComboBox.Location = New Point(458, 85)
        ProductNameComboBox.Name = "ProductNameComboBox"
        ProductNameComboBox.Size = New Size(210, 28)
        ProductNameComboBox.TabIndex = 2
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label3.Location = New Point(344, 193)
        Label3.Name = "Label3"
        Label3.Size = New Size(165, 23)
        Label3.TabIndex = 3
        Label3.Text = "Quantity to Order: "
        ' 
        ' OrderQuantityTextBox
        ' 
        OrderQuantityTextBox.Location = New Point(515, 193)
        OrderQuantityTextBox.Name = "OrderQuantityTextBox"
        OrderQuantityTextBox.Size = New Size(125, 27)
        OrderQuantityTextBox.TabIndex = 4
        ' 
        ' OrderButton
        ' 
        OrderButton.Location = New Point(865, 398)
        OrderButton.Name = "OrderButton"
        OrderButton.Size = New Size(94, 29)
        OrderButton.TabIndex = 5
        OrderButton.Text = "Order"
        OrderButton.UseVisualStyleBackColor = True
        ' 
        ' CancelButton
        ' 
        CancelButton.Location = New Point(733, 398)
        CancelButton.Name = "CancelButton"
        CancelButton.Size = New Size(94, 29)
        CancelButton.TabIndex = 6
        CancelButton.Text = "Cancel"
        CancelButton.UseVisualStyleBackColor = True
        ' 
        ' ViewOrderButton
        ' 
        ViewOrderButton.Location = New Point(28, 44)
        ViewOrderButton.Name = "ViewOrderButton"
        ViewOrderButton.Size = New Size(94, 29)
        ViewOrderButton.TabIndex = 7
        ViewOrderButton.Text = "View Order List"
        ViewOrderButton.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label4.Location = New Point(344, 142)
        Label4.Name = "Label4"
        Label4.Size = New Size(106, 23)
        Label4.TabIndex = 8
        Label4.Text = "Product ID: "
        ' 
        ' ProductIDLabel
        ' 
        ProductIDLabel.AutoSize = True
        ProductIDLabel.Location = New Point(458, 145)
        ProductIDLabel.Name = "ProductIDLabel"
        ProductIDLabel.Size = New Size(0, 20)
        ProductIDLabel.TabIndex = 9
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label5.Location = New Point(304, 298)
        Label5.Name = "Label5"
        Label5.Size = New Size(98, 23)
        Label5.TabIndex = 10
        Label5.Text = "Unit Price: "
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label6.Location = New Point(565, 298)
        Label6.Name = "Label6"
        Label6.Size = New Size(103, 23)
        Label6.TabIndex = 11
        Label6.Text = "Total Price: "
        ' 
        ' UnitPriceLabel
        ' 
        UnitPriceLabel.AutoSize = True
        UnitPriceLabel.Location = New Point(402, 300)
        UnitPriceLabel.Name = "UnitPriceLabel"
        UnitPriceLabel.Size = New Size(0, 20)
        UnitPriceLabel.TabIndex = 12
        ' 
        ' TotalPriceLabel
        ' 
        TotalPriceLabel.AutoSize = True
        TotalPriceLabel.Location = New Point(674, 300)
        TotalPriceLabel.Name = "TotalPriceLabel"
        TotalPriceLabel.Size = New Size(0, 20)
        TotalPriceLabel.TabIndex = 13
        ' 
        ' OrderProductForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1014, 454)
        Controls.Add(TotalPriceLabel)
        Controls.Add(UnitPriceLabel)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(ProductIDLabel)
        Controls.Add(Label4)
        Controls.Add(ViewOrderButton)
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
    Friend WithEvents ViewOrderButton As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents ProductIDLabel As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents UnitPriceLabel As Label
    Friend WithEvents TotalPriceLabel As Label
End Class
