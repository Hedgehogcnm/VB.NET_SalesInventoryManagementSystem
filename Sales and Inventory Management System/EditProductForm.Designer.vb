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
        ProductCategoryComboBox = New ComboBox()
        EditProductNameTextBox = New TextBox()
        Label9 = New Label()
        ProductIDLabel = New Label()
        SupplierIDLabel = New Label()
        EditProductStockTextBox = New TextBox()
        EditProductMinStockTextBox = New TextBox()
        EditProductCostPriceTextBox = New TextBox()
        EditProductSellPriceTextBox = New TextBox()
        CancelButton = New Button()
        Label10 = New Label()
        ProductPictureBox = New PictureBox()
        ChangeImageButton = New Button()
        CType(ProductPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        Label1.Location = New Point(523, 36)
        Label1.Name = "Label1"
        Label1.Size = New Size(159, 35)
        Label1.TabIndex = 0
        Label1.Text = "Edit Product"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label2.Location = New Point(108, 147)
        Label2.Name = "Label2"
        Label2.Size = New Size(106, 23)
        Label2.TabIndex = 1
        Label2.Text = "Product ID: "
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label3.Location = New Point(108, 272)
        Label3.Name = "Label3"
        Label3.Size = New Size(140, 23)
        Label3.TabIndex = 2
        Label3.Text = "Product Name： "
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label4.Location = New Point(108, 334)
        Label4.Name = "Label4"
        Label4.Size = New Size(162, 23)
        Label4.TabIndex = 3
        Label4.Text = "Product Category: "
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label5.Location = New Point(551, 147)
        Label5.Name = "Label5"
        Label5.Size = New Size(134, 23)
        Label5.TabIndex = 4
        Label5.Text = "Product Stock: "
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label6.Location = New Point(468, 204)
        Label6.Name = "Label6"
        Label6.Size = New Size(217, 23)
        Label6.TabIndex = 5
        Label6.Text = "Product Minimum Stock: "
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label7.Location = New Point(518, 271)
        Label7.Name = "Label7"
        Label7.Size = New Size(167, 23)
        Label7.TabIndex = 6
        Label7.Text = "Product Cost Price: "
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label8.Location = New Point(524, 334)
        Label8.Name = "Label8"
        Label8.Size = New Size(161, 23)
        Label8.TabIndex = 7
        Label8.Text = "Product Sell Price: "
        ' 
        ' SaveButton
        ' 
        SaveButton.Location = New Point(1034, 465)
        SaveButton.Name = "SaveButton"
        SaveButton.Size = New Size(94, 29)
        SaveButton.TabIndex = 8
        SaveButton.Text = "Save"
        SaveButton.UseVisualStyleBackColor = True
        ' 
        ' ProductCategoryComboBox
        ' 
        ProductCategoryComboBox.FormattingEnabled = True
        ProductCategoryComboBox.Items.AddRange(New Object() {"Hand Tools", "Power Tools", "Plumbing", "Electrical", "Building Materials", "Paint & Adhesives", "Safety Equipment"})
        ProductCategoryComboBox.Location = New Point(276, 333)
        ProductCategoryComboBox.Name = "ProductCategoryComboBox"
        ProductCategoryComboBox.Size = New Size(151, 28)
        ProductCategoryComboBox.TabIndex = 9
        ' 
        ' EditProductNameTextBox
        ' 
        EditProductNameTextBox.Location = New Point(254, 271)
        EditProductNameTextBox.Name = "EditProductNameTextBox"
        EditProductNameTextBox.Size = New Size(224, 27)
        EditProductNameTextBox.TabIndex = 10
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label9.Location = New Point(108, 204)
        Label9.Name = "Label9"
        Label9.Size = New Size(122, 23)
        Label9.TabIndex = 11
        Label9.Text = "Suppplier ID: "
        ' 
        ' ProductIDLabel
        ' 
        ProductIDLabel.AutoSize = True
        ProductIDLabel.Location = New Point(220, 149)
        ProductIDLabel.Name = "ProductIDLabel"
        ProductIDLabel.Size = New Size(0, 20)
        ProductIDLabel.TabIndex = 12
        ' 
        ' SupplierIDLabel
        ' 
        SupplierIDLabel.AutoSize = True
        SupplierIDLabel.Location = New Point(236, 207)
        SupplierIDLabel.Name = "SupplierIDLabel"
        SupplierIDLabel.Size = New Size(0, 20)
        SupplierIDLabel.TabIndex = 13
        ' 
        ' EditProductStockTextBox
        ' 
        EditProductStockTextBox.Location = New Point(691, 145)
        EditProductStockTextBox.Name = "EditProductStockTextBox"
        EditProductStockTextBox.Size = New Size(125, 27)
        EditProductStockTextBox.TabIndex = 14
        ' 
        ' EditProductMinStockTextBox
        ' 
        EditProductMinStockTextBox.Location = New Point(691, 204)
        EditProductMinStockTextBox.Name = "EditProductMinStockTextBox"
        EditProductMinStockTextBox.Size = New Size(125, 27)
        EditProductMinStockTextBox.TabIndex = 15
        ' 
        ' EditProductCostPriceTextBox
        ' 
        EditProductCostPriceTextBox.Location = New Point(691, 272)
        EditProductCostPriceTextBox.Name = "EditProductCostPriceTextBox"
        EditProductCostPriceTextBox.Size = New Size(125, 27)
        EditProductCostPriceTextBox.TabIndex = 16
        ' 
        ' EditProductSellPriceTextBox
        ' 
        EditProductSellPriceTextBox.Location = New Point(691, 331)
        EditProductSellPriceTextBox.Name = "EditProductSellPriceTextBox"
        EditProductSellPriceTextBox.Size = New Size(125, 27)
        EditProductSellPriceTextBox.TabIndex = 17
        ' 
        ' CancelButton
        ' 
        CancelButton.Location = New Point(900, 465)
        CancelButton.Name = "CancelButton"
        CancelButton.Size = New Size(94, 29)
        CancelButton.TabIndex = 18
        CancelButton.Text = "Cancel"
        CancelButton.UseVisualStyleBackColor = True
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label10.Location = New Point(947, 145)
        Label10.Name = "Label10"
        Label10.Size = New Size(138, 23)
        Label10.TabIndex = 19
        Label10.Text = "Product Image: "
        ' 
        ' ProductPictureBox
        ' 
        ProductPictureBox.Location = New Point(909, 171)
        ProductPictureBox.Name = "ProductPictureBox"
        ProductPictureBox.Size = New Size(205, 172)
        ProductPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        ProductPictureBox.TabIndex = 20
        ProductPictureBox.TabStop = False
        ' 
        ' ChangeImageButton
        ' 
        ChangeImageButton.Location = New Point(924, 358)
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
        ClientSize = New Size(1198, 526)
        Controls.Add(ChangeImageButton)
        Controls.Add(ProductPictureBox)
        Controls.Add(Label10)
        Controls.Add(CancelButton)
        Controls.Add(EditProductSellPriceTextBox)
        Controls.Add(EditProductCostPriceTextBox)
        Controls.Add(EditProductMinStockTextBox)
        Controls.Add(EditProductStockTextBox)
        Controls.Add(SupplierIDLabel)
        Controls.Add(ProductIDLabel)
        Controls.Add(Label9)
        Controls.Add(EditProductNameTextBox)
        Controls.Add(ProductCategoryComboBox)
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
        StartPosition = FormStartPosition.CenterScreen
        CType(ProductPictureBox, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ProductCategoryComboBox As ComboBox
    Friend WithEvents EditProductNameTextBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ProductIDLabel As Label
    Friend WithEvents SupplierIDLabel As Label
    Friend WithEvents EditProductStockTextBox As TextBox
    Friend WithEvents EditProductMinStockTextBox As TextBox
    Friend WithEvents EditProductCostPriceTextBox As TextBox
    Friend WithEvents EditProductSellPriceTextBox As TextBox
    Friend WithEvents CancelButton As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents ProductPictureBox As PictureBox
    Friend WithEvents ChangeImageButton As Button
End Class
