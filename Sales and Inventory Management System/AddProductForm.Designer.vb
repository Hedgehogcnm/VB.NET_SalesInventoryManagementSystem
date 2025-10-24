<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddProductForm
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
        ProductIDText = New Label()
        ProductNameText = New Label()
        SupplierIDText = New Label()
        ProductCategoryText = New Label()
        ProductMinStockText = New Label()
        ProductCostPriceText = New Label()
        ProductSellPriceText = New Label()
        ProductNameTextBox = New TextBox()
        ProductCategoryComboBox = New ComboBox()
        ProductMinStockTextBox = New TextBox()
        ProductCostPriceTextBox = New TextBox()
        ProductSellPriceTextBox = New TextBox()
        AddProductButton = New Button()
        SupplierIDComboBox = New ComboBox()
        CancelButton = New Button()
        ProductIDLabel = New Label()
        ProductIDTextBox = New TextBox()
        ProductImageText = New Label()
        ProductImagePictureBox = New PictureBox()
        ProductImageButton = New Button()
        CType(ProductImagePictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TitleLabel
        ' 
        TitleLabel.AutoSize = True
        TitleLabel.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        TitleLabel.Location = New Point(468, 23)
        TitleLabel.Name = "TitleLabel"
        TitleLabel.Size = New Size(179, 37)
        TitleLabel.TabIndex = 0
        TitleLabel.Text = "Add Product"
        ' 
        ' ProductIDText
        ' 
        ProductIDText.AutoSize = True
        ProductIDText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        ProductIDText.Location = New Point(97, 106)
        ProductIDText.Name = "ProductIDText"
        ProductIDText.Size = New Size(101, 23)
        ProductIDText.TabIndex = 1
        ProductIDText.Text = "Product ID:"
        ' 
        ' ProductNameText
        ' 
        ProductNameText.AutoSize = True
        ProductNameText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        ProductNameText.Location = New Point(68, 229)
        ProductNameText.Name = "ProductNameText"
        ProductNameText.Size = New Size(130, 23)
        ProductNameText.TabIndex = 2
        ProductNameText.Text = "Product Name:"
        ' 
        ' SupplierIDText
        ' 
        SupplierIDText.AutoSize = True
        SupplierIDText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        SupplierIDText.Location = New Point(92, 165)
        SupplierIDText.Name = "SupplierIDText"
        SupplierIDText.Size = New Size(106, 23)
        SupplierIDText.TabIndex = 3
        SupplierIDText.Text = "Supplier ID:"
        ' 
        ' ProductCategoryText
        ' 
        ProductCategoryText.AutoSize = True
        ProductCategoryText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        ProductCategoryText.Location = New Point(41, 295)
        ProductCategoryText.Name = "ProductCategoryText"
        ProductCategoryText.Size = New Size(157, 23)
        ProductCategoryText.TabIndex = 4
        ProductCategoryText.Text = "Product Category:"
        ' 
        ' ProductMinStockText
        ' 
        ProductMinStockText.AutoSize = True
        ProductMinStockText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        ProductMinStockText.Location = New Point(397, 108)
        ProductMinStockText.Name = "ProductMinStockText"
        ProductMinStockText.Size = New Size(212, 23)
        ProductMinStockText.TabIndex = 6
        ProductMinStockText.Text = "Product Minimum Stock:"
        ' 
        ' ProductCostPriceText
        ' 
        ProductCostPriceText.AutoSize = True
        ProductCostPriceText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        ProductCostPriceText.Location = New Point(447, 166)
        ProductCostPriceText.Name = "ProductCostPriceText"
        ProductCostPriceText.Size = New Size(162, 23)
        ProductCostPriceText.TabIndex = 7
        ProductCostPriceText.Text = "Product Cost Price:"
        ' 
        ' ProductSellPriceText
        ' 
        ProductSellPriceText.AutoSize = True
        ProductSellPriceText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        ProductSellPriceText.Location = New Point(453, 228)
        ProductSellPriceText.Name = "ProductSellPriceText"
        ProductSellPriceText.Size = New Size(156, 23)
        ProductSellPriceText.TabIndex = 8
        ProductSellPriceText.Text = "Product Sell Price:"
        ' 
        ' ProductNameTextBox
        ' 
        ProductNameTextBox.BackColor = SystemColors.Info
        ProductNameTextBox.BorderStyle = BorderStyle.FixedSingle
        ProductNameTextBox.Location = New Point(204, 228)
        ProductNameTextBox.Name = "ProductNameTextBox"
        ProductNameTextBox.Size = New Size(151, 27)
        ProductNameTextBox.TabIndex = 9
        ' 
        ' ProductCategoryComboBox
        ' 
        ProductCategoryComboBox.BackColor = SystemColors.Info
        ProductCategoryComboBox.FormattingEnabled = True
        ProductCategoryComboBox.Items.AddRange(New Object() {"Hand Tools", "Power Tools", "Plumbing", "Electrical", "Building Materials", "Paint & Adhesives", "Safety Equipment"})
        ProductCategoryComboBox.Location = New Point(204, 295)
        ProductCategoryComboBox.Name = "ProductCategoryComboBox"
        ProductCategoryComboBox.Size = New Size(151, 28)
        ProductCategoryComboBox.TabIndex = 11
        ' 
        ' ProductMinStockTextBox
        ' 
        ProductMinStockTextBox.BackColor = SystemColors.Info
        ProductMinStockTextBox.BorderStyle = BorderStyle.FixedSingle
        ProductMinStockTextBox.Location = New Point(615, 108)
        ProductMinStockTextBox.Name = "ProductMinStockTextBox"
        ProductMinStockTextBox.Size = New Size(125, 27)
        ProductMinStockTextBox.TabIndex = 13
        ' 
        ' ProductCostPriceTextBox
        ' 
        ProductCostPriceTextBox.BackColor = SystemColors.Info
        ProductCostPriceTextBox.BorderStyle = BorderStyle.FixedSingle
        ProductCostPriceTextBox.Location = New Point(615, 166)
        ProductCostPriceTextBox.Name = "ProductCostPriceTextBox"
        ProductCostPriceTextBox.Size = New Size(125, 27)
        ProductCostPriceTextBox.TabIndex = 14
        ' 
        ' ProductSellPriceTextBox
        ' 
        ProductSellPriceTextBox.BackColor = SystemColors.Info
        ProductSellPriceTextBox.BorderStyle = BorderStyle.FixedSingle
        ProductSellPriceTextBox.Location = New Point(615, 228)
        ProductSellPriceTextBox.Name = "ProductSellPriceTextBox"
        ProductSellPriceTextBox.Size = New Size(125, 27)
        ProductSellPriceTextBox.TabIndex = 15
        ' 
        ' AddProductButton
        ' 
        AddProductButton.BackColor = Color.SeaShell
        AddProductButton.Cursor = Cursors.No
        AddProductButton.FlatStyle = FlatStyle.Flat
        AddProductButton.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        AddProductButton.ForeColor = Color.Sienna
        AddProductButton.Location = New Point(577, 371)
        AddProductButton.Name = "AddProductButton"
        AddProductButton.Size = New Size(94, 29)
        AddProductButton.TabIndex = 16
        AddProductButton.Text = "Add"
        AddProductButton.UseVisualStyleBackColor = False
        ' 
        ' SupplierIDComboBox
        ' 
        SupplierIDComboBox.BackColor = SystemColors.Info
        SupplierIDComboBox.FormattingEnabled = True
        SupplierIDComboBox.Location = New Point(204, 165)
        SupplierIDComboBox.Name = "SupplierIDComboBox"
        SupplierIDComboBox.Size = New Size(151, 28)
        SupplierIDComboBox.TabIndex = 18
        ' 
        ' CancelButton
        ' 
        CancelButton.BackColor = Color.SeaShell
        CancelButton.FlatStyle = FlatStyle.Flat
        CancelButton.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        CancelButton.ForeColor = Color.Sienna
        CancelButton.Location = New Point(456, 371)
        CancelButton.Name = "CancelButton"
        CancelButton.Size = New Size(94, 29)
        CancelButton.TabIndex = 19
        CancelButton.Text = "Cancel"
        CancelButton.UseVisualStyleBackColor = False
        ' 
        ' ProductIDLabel
        ' 
        ProductIDLabel.AutoSize = True
        ProductIDLabel.Location = New Point(214, 108)
        ProductIDLabel.Name = "ProductIDLabel"
        ProductIDLabel.Size = New Size(0, 20)
        ProductIDLabel.TabIndex = 20
        ' 
        ' ProductIDTextBox
        ' 
        ProductIDTextBox.BackColor = SystemColors.Info
        ProductIDTextBox.BorderStyle = BorderStyle.FixedSingle
        ProductIDTextBox.Location = New Point(204, 106)
        ProductIDTextBox.Name = "ProductIDTextBox"
        ProductIDTextBox.Size = New Size(151, 27)
        ProductIDTextBox.TabIndex = 21
        ' 
        ' ProductImageText
        ' 
        ProductImageText.AutoSize = True
        ProductImageText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        ProductImageText.Location = New Point(893, 108)
        ProductImageText.Name = "ProductImageText"
        ProductImageText.Size = New Size(138, 23)
        ProductImageText.TabIndex = 22
        ProductImageText.Text = "Product Image: "
        ' 
        ' ProductImagePictureBox
        ' 
        ProductImagePictureBox.BackColor = Color.White
        ProductImagePictureBox.BorderStyle = BorderStyle.FixedSingle
        ProductImagePictureBox.Location = New Point(856, 134)
        ProductImagePictureBox.Name = "ProductImagePictureBox"
        ProductImagePictureBox.Size = New Size(207, 175)
        ProductImagePictureBox.SizeMode = PictureBoxSizeMode.Zoom
        ProductImagePictureBox.TabIndex = 23
        ProductImagePictureBox.TabStop = False
        ' 
        ' ProductImageButton
        ' 
        ProductImageButton.BackColor = Color.SeaShell
        ProductImageButton.FlatStyle = FlatStyle.Flat
        ProductImageButton.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ProductImageButton.ForeColor = Color.Sienna
        ProductImageButton.Location = New Point(903, 315)
        ProductImageButton.Name = "ProductImageButton"
        ProductImageButton.Size = New Size(118, 30)
        ProductImageButton.TabIndex = 24
        ProductImageButton.Text = "Upload Image"
        ProductImageButton.UseVisualStyleBackColor = False
        ' 
        ' AddProductForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SeaShell
        ClientSize = New Size(1123, 450)
        Controls.Add(ProductImageButton)
        Controls.Add(ProductImagePictureBox)
        Controls.Add(ProductImageText)
        Controls.Add(ProductIDTextBox)
        Controls.Add(ProductIDLabel)
        Controls.Add(CancelButton)
        Controls.Add(SupplierIDComboBox)
        Controls.Add(AddProductButton)
        Controls.Add(ProductSellPriceTextBox)
        Controls.Add(ProductCostPriceTextBox)
        Controls.Add(ProductMinStockTextBox)
        Controls.Add(ProductCategoryComboBox)
        Controls.Add(ProductNameTextBox)
        Controls.Add(ProductSellPriceText)
        Controls.Add(ProductCostPriceText)
        Controls.Add(ProductMinStockText)
        Controls.Add(ProductCategoryText)
        Controls.Add(SupplierIDText)
        Controls.Add(ProductNameText)
        Controls.Add(ProductIDText)
        Controls.Add(TitleLabel)
        Name = "AddProductForm"
        StartPosition = FormStartPosition.CenterScreen
        CType(ProductImagePictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TitleLabel As Label
    Friend WithEvents ProductIDText As Label
    Friend WithEvents ProductNameText As Label
    Friend WithEvents SupplierIDText As Label
    Friend WithEvents ProductCategoryText As Label
    Friend WithEvents ProductMinStockText As Label
    Friend WithEvents ProductCostPriceText As Label
    Friend WithEvents ProductSellPriceText As Label
    Friend WithEvents ProductNameTextBox As TextBox
    Friend WithEvents ProductCategoryComboBox As ComboBox
    Friend WithEvents ProductMinStockTextBox As TextBox
    Friend WithEvents ProductCostPriceTextBox As TextBox
    Friend WithEvents ProductSellPriceTextBox As TextBox
    Friend WithEvents AddProductButton As Button
    Friend WithEvents SupplierIDComboBox As ComboBox
    Friend WithEvents CancelButton As Button
    Friend WithEvents ProductIDLabel As Label
    Friend WithEvents ProductIDTextBox As TextBox
    Friend WithEvents ProductImageText As Label
    Friend WithEvents ProductImagePictureBox As PictureBox
    Friend WithEvents ProductImageButton As Button
End Class
