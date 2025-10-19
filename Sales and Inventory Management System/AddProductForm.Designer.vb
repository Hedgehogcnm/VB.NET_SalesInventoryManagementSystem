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
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        ProductNameTextBox = New TextBox()
        ProductCategoryComboBox = New ComboBox()
        ProductStockTextBox = New TextBox()
        ProductMinStockTextBox = New TextBox()
        ProductCostPriceTextBox = New TextBox()
        ProductSellPriceTextBox = New TextBox()
        AddProductButton = New Button()
        SupplierIDComboBox = New ComboBox()
        CancelButton = New Button()
        ProductIDLabel = New Label()
        ProductIDTextBox = New TextBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(299, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(162, 35)
        Label1.TabIndex = 0
        Label1.Text = "Add Product"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label2.Location = New Point(97, 106)
        Label2.Name = "Label2"
        Label2.Size = New Size(101, 23)
        Label2.TabIndex = 1
        Label2.Text = "Product ID:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label3.Location = New Point(68, 229)
        Label3.Name = "Label3"
        Label3.Size = New Size(130, 23)
        Label3.TabIndex = 2
        Label3.Text = "Product Name:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label4.Location = New Point(92, 165)
        Label4.Name = "Label4"
        Label4.Size = New Size(106, 23)
        Label4.TabIndex = 3
        Label4.Text = "Supplier ID:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label5.Location = New Point(41, 295)
        Label5.Name = "Label5"
        Label5.Size = New Size(157, 23)
        Label5.TabIndex = 4
        Label5.Text = "Product Category:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label6.Location = New Point(480, 106)
        Label6.Name = "Label6"
        Label6.Size = New Size(129, 23)
        Label6.TabIndex = 5
        Label6.Text = "Product Stock:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label7.Location = New Point(397, 165)
        Label7.Name = "Label7"
        Label7.Size = New Size(212, 23)
        Label7.TabIndex = 6
        Label7.Text = "Product Minimum Stock:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label8.Location = New Point(447, 229)
        Label8.Name = "Label8"
        Label8.Size = New Size(162, 23)
        Label8.TabIndex = 7
        Label8.Text = "Product Cost Price:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label9.Location = New Point(453, 295)
        Label9.Name = "Label9"
        Label9.Size = New Size(156, 23)
        Label9.TabIndex = 8
        Label9.Text = "Product Sell Price:"
        ' 
        ' ProductNameTextBox
        ' 
        ProductNameTextBox.Location = New Point(204, 228)
        ProductNameTextBox.Name = "ProductNameTextBox"
        ProductNameTextBox.Size = New Size(151, 27)
        ProductNameTextBox.TabIndex = 9
        ' 
        ' ProductCategoryComboBox
        ' 
        ProductCategoryComboBox.FormattingEnabled = True
        ProductCategoryComboBox.Items.AddRange(New Object() {"Hand Tools", "Power Tools", "Plumbing", "Electrical", "Building Materials", "Paint & Adhesives", "Safety Equipment"})
        ProductCategoryComboBox.Location = New Point(204, 295)
        ProductCategoryComboBox.Name = "ProductCategoryComboBox"
        ProductCategoryComboBox.Size = New Size(151, 28)
        ProductCategoryComboBox.TabIndex = 11
        ' 
        ' ProductStockTextBox
        ' 
        ProductStockTextBox.Location = New Point(615, 105)
        ProductStockTextBox.Name = "ProductStockTextBox"
        ProductStockTextBox.Size = New Size(125, 27)
        ProductStockTextBox.TabIndex = 12
        ' 
        ' ProductMinStockTextBox
        ' 
        ProductMinStockTextBox.Location = New Point(615, 165)
        ProductMinStockTextBox.Name = "ProductMinStockTextBox"
        ProductMinStockTextBox.Size = New Size(125, 27)
        ProductMinStockTextBox.TabIndex = 13
        ' 
        ' ProductCostPriceTextBox
        ' 
        ProductCostPriceTextBox.Location = New Point(615, 229)
        ProductCostPriceTextBox.Name = "ProductCostPriceTextBox"
        ProductCostPriceTextBox.Size = New Size(125, 27)
        ProductCostPriceTextBox.TabIndex = 14
        ' 
        ' ProductSellPriceTextBox
        ' 
        ProductSellPriceTextBox.Location = New Point(615, 295)
        ProductSellPriceTextBox.Name = "ProductSellPriceTextBox"
        ProductSellPriceTextBox.Size = New Size(125, 27)
        ProductSellPriceTextBox.TabIndex = 15
        ' 
        ' AddProductButton
        ' 
        AddProductButton.Location = New Point(646, 373)
        AddProductButton.Name = "AddProductButton"
        AddProductButton.Size = New Size(94, 29)
        AddProductButton.TabIndex = 16
        AddProductButton.Text = "Add"
        AddProductButton.UseVisualStyleBackColor = True
        ' 
        ' SupplierIDComboBox
        ' 
        SupplierIDComboBox.FormattingEnabled = True
        SupplierIDComboBox.Location = New Point(204, 165)
        SupplierIDComboBox.Name = "SupplierIDComboBox"
        SupplierIDComboBox.Size = New Size(151, 28)
        SupplierIDComboBox.TabIndex = 18
        ' 
        ' CancelButton
        ' 
        CancelButton.Location = New Point(525, 373)
        CancelButton.Name = "CancelButton"
        CancelButton.Size = New Size(94, 29)
        CancelButton.TabIndex = 19
        CancelButton.Text = "Cancel"
        CancelButton.UseVisualStyleBackColor = True
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
        ProductIDTextBox.Location = New Point(204, 106)
        ProductIDTextBox.Name = "ProductIDTextBox"
        ProductIDTextBox.Size = New Size(151, 27)
        ProductIDTextBox.TabIndex = 21
        ' 
        ' AddProductForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(ProductIDTextBox)
        Controls.Add(ProductIDLabel)
        Controls.Add(CancelButton)
        Controls.Add(SupplierIDComboBox)
        Controls.Add(AddProductButton)
        Controls.Add(ProductSellPriceTextBox)
        Controls.Add(ProductCostPriceTextBox)
        Controls.Add(ProductMinStockTextBox)
        Controls.Add(ProductStockTextBox)
        Controls.Add(ProductCategoryComboBox)
        Controls.Add(ProductNameTextBox)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "AddProductForm"
        Text = "AddProductForm"
        WindowState = FormWindowState.Maximized
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
    Friend WithEvents Label9 As Label
    Friend WithEvents ProductNameTextBox As TextBox
    Friend WithEvents ProductCategoryComboBox As ComboBox
    Friend WithEvents ProductStockTextBox As TextBox
    Friend WithEvents ProductMinStockTextBox As TextBox
    Friend WithEvents ProductCostPriceTextBox As TextBox
    Friend WithEvents ProductSellPriceTextBox As TextBox
    Friend WithEvents AddProductButton As Button
    Friend WithEvents SupplierIDComboBox As ComboBox
    Friend WithEvents CancelButton As Button
    Friend WithEvents ProductIDLabel As Label
    Friend WithEvents ProductIDTextBox As TextBox
End Class
