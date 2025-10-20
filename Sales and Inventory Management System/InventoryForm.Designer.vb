<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryForm
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
        components = New ComponentModel.Container()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        Label1 = New Label()
        ProductListDataGridView = New DataGridView()
        SearchProductButton = New Button()
        ProductSearchTextBox = New TextBox()
        OrderProductButton = New Button()
        AddProductButton = New Button()
        EditProductButton = New Button()
        DeleteProductButton = New Button()
        CType(ProductListDataGridView, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.ImageScalingSize = New Size(20, 20)
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(61, 4)
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(236, 38)
        Label1.Name = "Label1"
        Label1.Size = New Size(104, 20)
        Label1.TabIndex = 1
        Label1.Text = "inventory teng"
        ' 
        ' ProductListDataGridView
        ' 
        ProductListDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        ProductListDataGridView.Location = New Point(148, 97)
        ProductListDataGridView.Name = "ProductListDataGridView"
        ProductListDataGridView.RowHeadersWidth = 51
        ProductListDataGridView.Size = New Size(776, 416)
        ProductListDataGridView.TabIndex = 3
        ' 
        ' SearchProductButton
        ' 
        SearchProductButton.Location = New Point(830, 54)
        SearchProductButton.Name = "SearchProductButton"
        SearchProductButton.Size = New Size(94, 29)
        SearchProductButton.TabIndex = 4
        SearchProductButton.Text = "Search"
        SearchProductButton.UseVisualStyleBackColor = True
        ' 
        ' ProductSearchTextBox
        ' 
        ProductSearchTextBox.Location = New Point(630, 55)
        ProductSearchTextBox.Name = "ProductSearchTextBox"
        ProductSearchTextBox.Size = New Size(180, 27)
        ProductSearchTextBox.TabIndex = 5
        ' 
        ' OrderProductButton
        ' 
        OrderProductButton.Location = New Point(27, 97)
        OrderProductButton.Name = "OrderProductButton"
        OrderProductButton.Size = New Size(94, 50)
        OrderProductButton.TabIndex = 6
        OrderProductButton.Text = "Order Product"
        OrderProductButton.UseVisualStyleBackColor = True
        ' 
        ' AddProductButton
        ' 
        AddProductButton.Location = New Point(27, 179)
        AddProductButton.Name = "AddProductButton"
        AddProductButton.Size = New Size(94, 48)
        AddProductButton.TabIndex = 7
        AddProductButton.Text = "Add Product"
        AddProductButton.UseVisualStyleBackColor = True
        ' 
        ' EditProductButton
        ' 
        EditProductButton.Location = New Point(27, 257)
        EditProductButton.Name = "EditProductButton"
        EditProductButton.Size = New Size(94, 50)
        EditProductButton.TabIndex = 8
        EditProductButton.Text = "Edit Product"
        EditProductButton.UseVisualStyleBackColor = True
        ' 
        ' DeleteProductButton
        ' 
        DeleteProductButton.Location = New Point(27, 338)
        DeleteProductButton.Name = "DeleteProductButton"
        DeleteProductButton.Size = New Size(94, 65)
        DeleteProductButton.TabIndex = 9
        DeleteProductButton.Text = "Delete Product"
        DeleteProductButton.UseVisualStyleBackColor = True
        ' 
        ' InventoryForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1502, 773)
        Controls.Add(DeleteProductButton)
        Controls.Add(EditProductButton)
        Controls.Add(AddProductButton)
        Controls.Add(OrderProductButton)
        Controls.Add(ProductSearchTextBox)
        Controls.Add(SearchProductButton)
        Controls.Add(ProductListDataGridView)
        Controls.Add(Label1)
        Name = "InventoryForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "InventoryForm"
        WindowState = FormWindowState.Maximized
        CType(ProductListDataGridView, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Label1 As Label
    Friend WithEvents ProductListDataGridView As DataGridView
    Friend WithEvents SearchProductButton As Button
    Friend WithEvents ProductSearchTextBox As TextBox
    Friend WithEvents OrderProductButton As Button
    Friend WithEvents AddProductButton As Button
    Friend WithEvents EditProductButton As Button
    Friend WithEvents DeleteProductButton As Button
End Class
