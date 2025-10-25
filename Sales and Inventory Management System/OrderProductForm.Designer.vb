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
        TitleLabel = New Label()
        ProductNameText = New Label()
        QuantityText = New Label()
        OrderQuantityTextBox = New TextBox()
        OrderButton = New Button()
        CancelButton = New Button()
        ProductIDText = New Label()
        ProductIDDisplay = New Label()
        UnitPriceText = New Label()
        TotalText = New Label()
        UnitPriceDisplay = New Label()
        TotalPriceDisplay = New Label()
        ProductNameDisplay = New Label()
        SuspendLayout()
        ' 
        ' TitleLabel
        ' 
        TitleLabel.AutoSize = True
        TitleLabel.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        TitleLabel.Location = New Point(229, 22)
        TitleLabel.Name = "TitleLabel"
        TitleLabel.Size = New Size(200, 37)
        TitleLabel.TabIndex = 0
        TitleLabel.Text = "Order Product"
        ' 
        ' ProductNameText
        ' 
        ProductNameText.AutoSize = True
        ProductNameText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        ProductNameText.Location = New Point(159, 89)
        ProductNameText.Name = "ProductNameText"
        ProductNameText.Size = New Size(135, 23)
        ProductNameText.TabIndex = 1
        ProductNameText.Text = "Product Name :"
        ' 
        ' QuantityText
        ' 
        QuantityText.AutoSize = True
        QuantityText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        QuantityText.Location = New Point(130, 197)
        QuantityText.Name = "QuantityText"
        QuantityText.Size = New Size(164, 23)
        QuantityText.TabIndex = 3
        QuantityText.Text = "Quantity to Order :"
        ' 
        ' OrderQuantityTextBox
        ' 
        OrderQuantityTextBox.BackColor = SystemColors.Info
        OrderQuantityTextBox.BorderStyle = BorderStyle.FixedSingle
        OrderQuantityTextBox.Location = New Point(310, 197)
        OrderQuantityTextBox.Name = "OrderQuantityTextBox"
        OrderQuantityTextBox.Size = New Size(125, 27)
        OrderQuantityTextBox.TabIndex = 4
        ' 
        ' OrderButton
        ' 
        OrderButton.FlatStyle = FlatStyle.Flat
        OrderButton.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        OrderButton.ForeColor = Color.Sienna
        OrderButton.Location = New Point(554, 342)
        OrderButton.Name = "OrderButton"
        OrderButton.Size = New Size(94, 29)
        OrderButton.TabIndex = 5
        OrderButton.Text = "Order"
        OrderButton.UseVisualStyleBackColor = True
        ' 
        ' CancelButton
        ' 
        CancelButton.FlatStyle = FlatStyle.Flat
        CancelButton.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        CancelButton.ForeColor = Color.Sienna
        CancelButton.Location = New Point(422, 342)
        CancelButton.Name = "CancelButton"
        CancelButton.Size = New Size(94, 29)
        CancelButton.TabIndex = 6
        CancelButton.Text = "Cancel"
        CancelButton.UseVisualStyleBackColor = True
        ' 
        ' ProductIDText
        ' 
        ProductIDText.AutoSize = True
        ProductIDText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        ProductIDText.Location = New Point(188, 145)
        ProductIDText.Name = "ProductIDText"
        ProductIDText.Size = New Size(106, 23)
        ProductIDText.TabIndex = 8
        ProductIDText.Text = "Product ID :"
        ' 
        ' ProductIDDisplay
        ' 
        ProductIDDisplay.Location = New Point(310, 149)
        ProductIDDisplay.Name = "ProductIDDisplay"
        ProductIDDisplay.Size = New Size(125, 27)
        ProductIDDisplay.TabIndex = 9
        ' 
        ' UnitPriceText
        ' 
        UnitPriceText.AutoSize = True
        UnitPriceText.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        UnitPriceText.Location = New Point(107, 258)
        UnitPriceText.Name = "UnitPriceText"
        UnitPriceText.Size = New Size(98, 23)
        UnitPriceText.TabIndex = 10
        UnitPriceText.Text = "Unit Price :"
        ' 
        ' TotalText
        ' 
        TotalText.AutoSize = True
        TotalText.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        TotalText.Location = New Point(355, 259)
        TotalText.Name = "TotalText"
        TotalText.Size = New Size(103, 23)
        TotalText.TabIndex = 11
        TotalText.Text = "Total Price :"
        ' 
        ' UnitPriceDisplay
        ' 
        UnitPriceDisplay.Location = New Point(213, 256)
        UnitPriceDisplay.Name = "UnitPriceDisplay"
        UnitPriceDisplay.Size = New Size(125, 27)
        UnitPriceDisplay.TabIndex = 12
        ' 
        ' TotalPriceDisplay
        ' 
        TotalPriceDisplay.Location = New Point(467, 257)
        TotalPriceDisplay.Name = "TotalPriceDisplay"
        TotalPriceDisplay.Size = New Size(125, 27)
        TotalPriceDisplay.TabIndex = 13
        ' 
        ' ProductNameDisplay
        ' 
        ProductNameDisplay.Location = New Point(310, 93)
        ProductNameDisplay.Name = "ProductNameDisplay"
        ProductNameDisplay.Size = New Size(300, 27)
        ProductNameDisplay.TabIndex = 14
        ' 
        ' OrderProductForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SeaShell
        ClientSize = New Size(689, 403)
        Controls.Add(ProductNameDisplay)
        Controls.Add(TotalPriceDisplay)
        Controls.Add(UnitPriceDisplay)
        Controls.Add(TotalText)
        Controls.Add(UnitPriceText)
        Controls.Add(ProductIDDisplay)
        Controls.Add(ProductIDText)
        Controls.Add(CancelButton)
        Controls.Add(OrderButton)
        Controls.Add(OrderQuantityTextBox)
        Controls.Add(QuantityText)
        Controls.Add(ProductNameText)
        Controls.Add(TitleLabel)
        Name = "OrderProductForm"
        StartPosition = FormStartPosition.CenterScreen
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TitleLabel As Label
    Friend WithEvents ProductNameText As Label
    Friend WithEvents QuantityText As Label
    Friend WithEvents OrderQuantityTextBox As TextBox
    Friend WithEvents OrderButton As Button
    Friend WithEvents CancelButton As Button
    Friend WithEvents ProductIDText As Label
    Friend WithEvents ProductIDDisplay As Label
    Friend WithEvents UnitPriceText As Label
    Friend WithEvents TotalText As Label
    Friend WithEvents UnitPriceDisplay As Label
    Friend WithEvents TotalPriceDisplay As Label
    Friend WithEvents ProductNameDisplay As Label
End Class
