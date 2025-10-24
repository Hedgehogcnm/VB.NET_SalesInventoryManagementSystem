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
        TitleLabel = New Label()
        ProductIDText = New Label()
        ProductNameText = New Label()
        CategoryText = New Label()
        StockText = New Label()
        MinStockText = New Label()
        CostText = New Label()
        SellText = New Label()
        SaveButton = New Button()
        ProductCategoryComboBox = New ComboBox()
        EditProductNameTextBox = New TextBox()
        SupplierIDText = New Label()
        ProductIDLabel = New Label()
        SupplierIDLabel = New Label()
        EditProductStockTextBox = New TextBox()
        EditProductMinStockTextBox = New TextBox()
        EditProductCostPriceTextBox = New TextBox()
        EditProductSellPriceTextBox = New TextBox()
        CancelButton = New Button()
        ImageText = New Label()
        ProductPictureBox = New PictureBox()
        ChangeImageButton = New Button()
        CType(ProductPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TitleLabel
        ' 
        TitleLabel.AutoSize = True
        TitleLabel.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        TitleLabel.ForeColor = Color.Sienna
        TitleLabel.Location = New Point(523, 36)
        TitleLabel.Name = "TitleLabel"
        TitleLabel.Size = New Size(176, 37)
        TitleLabel.TabIndex = 0
        TitleLabel.Text = "Edit Product"
        ' 
        ' ProductIDText
        ' 
        ProductIDText.AutoSize = True
        ProductIDText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        ProductIDText.Location = New Point(90, 122)
        ProductIDText.Name = "ProductIDText"
        ProductIDText.Size = New Size(106, 23)
        ProductIDText.TabIndex = 1
        ProductIDText.Text = "Product ID: "
        ' 
        ' ProductNameText
        ' 
        ProductNameText.AutoSize = True
        ProductNameText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        ProductNameText.Location = New Point(90, 247)
        ProductNameText.Name = "ProductNameText"
        ProductNameText.Size = New Size(148, 23)
        ProductNameText.TabIndex = 2
        ProductNameText.Text = "Product Name： "
        ' 
        ' CategoryText
        ' 
        CategoryText.AutoSize = True
        CategoryText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        CategoryText.Location = New Point(90, 309)
        CategoryText.Name = "CategoryText"
        CategoryText.Size = New Size(162, 23)
        CategoryText.TabIndex = 3
        CategoryText.Text = "Product Category: "
        ' 
        ' StockText
        ' 
        StockText.AutoSize = True
        StockText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        StockText.Location = New Point(533, 122)
        StockText.Name = "StockText"
        StockText.Size = New Size(134, 23)
        StockText.TabIndex = 4
        StockText.Text = "Product Stock: "
        ' 
        ' MinStockText
        ' 
        MinStockText.AutoSize = True
        MinStockText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        MinStockText.Location = New Point(450, 179)
        MinStockText.Name = "MinStockText"
        MinStockText.Size = New Size(217, 23)
        MinStockText.TabIndex = 5
        MinStockText.Text = "Product Minimum Stock: "
        ' 
        ' CostText
        ' 
        CostText.AutoSize = True
        CostText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        CostText.Location = New Point(500, 246)
        CostText.Name = "CostText"
        CostText.Size = New Size(167, 23)
        CostText.TabIndex = 6
        CostText.Text = "Product Cost Price: "
        ' 
        ' SellText
        ' 
        SellText.AutoSize = True
        SellText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        SellText.Location = New Point(506, 309)
        SellText.Name = "SellText"
        SellText.Size = New Size(161, 23)
        SellText.TabIndex = 7
        SellText.Text = "Product Sell Price: "
        ' 
        ' SaveButton
        ' 
        SaveButton.FlatStyle = FlatStyle.Flat
        SaveButton.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        SaveButton.ForeColor = Color.Sienna
        SaveButton.Location = New Point(627, 431)
        SaveButton.Name = "SaveButton"
        SaveButton.Size = New Size(94, 29)
        SaveButton.TabIndex = 8
        SaveButton.Text = "Save"
        SaveButton.UseVisualStyleBackColor = True
        ' 
        ' ProductCategoryComboBox
        ' 
        ProductCategoryComboBox.BackColor = SystemColors.Info
        ProductCategoryComboBox.FormattingEnabled = True
        ProductCategoryComboBox.Items.AddRange(New Object() {"Hand Tools", "Power Tools", "Plumbing", "Electrical", "Building Materials", "Paint & Adhesives", "Safety Equipment"})
        ProductCategoryComboBox.Location = New Point(258, 308)
        ProductCategoryComboBox.Name = "ProductCategoryComboBox"
        ProductCategoryComboBox.Size = New Size(151, 28)
        ProductCategoryComboBox.TabIndex = 9
        ' 
        ' EditProductNameTextBox
        ' 
        EditProductNameTextBox.BackColor = SystemColors.Info
        EditProductNameTextBox.BorderStyle = BorderStyle.FixedSingle
        EditProductNameTextBox.Location = New Point(236, 246)
        EditProductNameTextBox.Name = "EditProductNameTextBox"
        EditProductNameTextBox.Size = New Size(224, 27)
        EditProductNameTextBox.TabIndex = 10
        ' 
        ' SupplierIDText
        ' 
        SupplierIDText.AutoSize = True
        SupplierIDText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        SupplierIDText.Location = New Point(90, 179)
        SupplierIDText.Name = "SupplierIDText"
        SupplierIDText.Size = New Size(122, 23)
        SupplierIDText.TabIndex = 11
        SupplierIDText.Text = "Suppplier ID: "
        ' 
        ' ProductIDLabel
        ' 
        ProductIDLabel.AutoSize = True
        ProductIDLabel.Location = New Point(202, 124)
        ProductIDLabel.Name = "ProductIDLabel"
        ProductIDLabel.Size = New Size(0, 20)
        ProductIDLabel.TabIndex = 12
        ' 
        ' SupplierIDLabel
        ' 
        SupplierIDLabel.AutoSize = True
        SupplierIDLabel.Location = New Point(218, 182)
        SupplierIDLabel.Name = "SupplierIDLabel"
        SupplierIDLabel.Size = New Size(0, 20)
        SupplierIDLabel.TabIndex = 13
        ' 
        ' EditProductStockTextBox
        ' 
        EditProductStockTextBox.BackColor = SystemColors.Info
        EditProductStockTextBox.BorderStyle = BorderStyle.FixedSingle
        EditProductStockTextBox.Location = New Point(673, 120)
        EditProductStockTextBox.Name = "EditProductStockTextBox"
        EditProductStockTextBox.Size = New Size(125, 27)
        EditProductStockTextBox.TabIndex = 14
        ' 
        ' EditProductMinStockTextBox
        ' 
        EditProductMinStockTextBox.BackColor = SystemColors.Info
        EditProductMinStockTextBox.BorderStyle = BorderStyle.FixedSingle
        EditProductMinStockTextBox.Location = New Point(673, 179)
        EditProductMinStockTextBox.Name = "EditProductMinStockTextBox"
        EditProductMinStockTextBox.Size = New Size(125, 27)
        EditProductMinStockTextBox.TabIndex = 15
        ' 
        ' EditProductCostPriceTextBox
        ' 
        EditProductCostPriceTextBox.BackColor = SystemColors.Info
        EditProductCostPriceTextBox.BorderStyle = BorderStyle.FixedSingle
        EditProductCostPriceTextBox.Location = New Point(673, 247)
        EditProductCostPriceTextBox.Name = "EditProductCostPriceTextBox"
        EditProductCostPriceTextBox.Size = New Size(125, 27)
        EditProductCostPriceTextBox.TabIndex = 16
        ' 
        ' EditProductSellPriceTextBox
        ' 
        EditProductSellPriceTextBox.BackColor = SystemColors.Info
        EditProductSellPriceTextBox.BorderStyle = BorderStyle.FixedSingle
        EditProductSellPriceTextBox.Location = New Point(673, 306)
        EditProductSellPriceTextBox.Name = "EditProductSellPriceTextBox"
        EditProductSellPriceTextBox.Size = New Size(125, 27)
        EditProductSellPriceTextBox.TabIndex = 17
        ' 
        ' CancelButton
        ' 
        CancelButton.BackColor = Color.SeaShell
        CancelButton.FlatStyle = FlatStyle.Flat
        CancelButton.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        CancelButton.ForeColor = Color.Sienna
        CancelButton.Location = New Point(493, 431)
        CancelButton.Name = "CancelButton"
        CancelButton.Size = New Size(94, 29)
        CancelButton.TabIndex = 18
        CancelButton.Text = "Cancel"
        CancelButton.UseVisualStyleBackColor = False
        ' 
        ' ImageText
        ' 
        ImageText.AutoSize = True
        ImageText.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        ImageText.Location = New Point(929, 120)
        ImageText.Name = "ImageText"
        ImageText.Size = New Size(138, 23)
        ImageText.TabIndex = 19
        ImageText.Text = "Product Image: "
        ' 
        ' ProductPictureBox
        ' 
        ProductPictureBox.Location = New Point(891, 146)
        ProductPictureBox.Name = "ProductPictureBox"
        ProductPictureBox.Size = New Size(205, 172)
        ProductPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        ProductPictureBox.TabIndex = 20
        ProductPictureBox.TabStop = False
        ' 
        ' ChangeImageButton
        ' 
        ChangeImageButton.FlatStyle = FlatStyle.Flat
        ChangeImageButton.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ChangeImageButton.ForeColor = Color.Sienna
        ChangeImageButton.Location = New Point(906, 333)
        ChangeImageButton.Name = "ChangeImageButton"
        ChangeImageButton.Size = New Size(181, 37)
        ChangeImageButton.TabIndex = 21
        ChangeImageButton.Text = "Change Product Image"
        ChangeImageButton.UseVisualStyleBackColor = True
        ' 
        ' EditProductForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SeaShell
        ClientSize = New Size(1198, 526)
        Controls.Add(ChangeImageButton)
        Controls.Add(ProductPictureBox)
        Controls.Add(ImageText)
        Controls.Add(CancelButton)
        Controls.Add(EditProductSellPriceTextBox)
        Controls.Add(EditProductCostPriceTextBox)
        Controls.Add(EditProductMinStockTextBox)
        Controls.Add(EditProductStockTextBox)
        Controls.Add(SupplierIDLabel)
        Controls.Add(ProductIDLabel)
        Controls.Add(SupplierIDText)
        Controls.Add(EditProductNameTextBox)
        Controls.Add(ProductCategoryComboBox)
        Controls.Add(SaveButton)
        Controls.Add(SellText)
        Controls.Add(CostText)
        Controls.Add(MinStockText)
        Controls.Add(StockText)
        Controls.Add(CategoryText)
        Controls.Add(ProductNameText)
        Controls.Add(ProductIDText)
        Controls.Add(TitleLabel)
        Name = "EditProductForm"
        StartPosition = FormStartPosition.CenterScreen
        CType(ProductPictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TitleLabel As Label
    Friend WithEvents ProductIDText As Label
    Friend WithEvents ProductNameText As Label
    Friend WithEvents CategoryText As Label
    Friend WithEvents StockText As Label
    Friend WithEvents MinStockText As Label
    Friend WithEvents CostText As Label
    Friend WithEvents SellText As Label
    Friend WithEvents SaveButton As Button
    Friend WithEvents ProductCategoryComboBox As ComboBox
    Friend WithEvents EditProductNameTextBox As TextBox
    Friend WithEvents SupplierIDText As Label
    Friend WithEvents ProductIDLabel As Label
    Friend WithEvents SupplierIDLabel As Label
    Friend WithEvents EditProductStockTextBox As TextBox
    Friend WithEvents EditProductMinStockTextBox As TextBox
    Friend WithEvents EditProductCostPriceTextBox As TextBox
    Friend WithEvents EditProductSellPriceTextBox As TextBox
    Friend WithEvents CancelButton As Button
    Friend WithEvents ImageText As Label
    Friend WithEvents ProductPictureBox As PictureBox
    Friend WithEvents ChangeImageButton As Button
End Class
