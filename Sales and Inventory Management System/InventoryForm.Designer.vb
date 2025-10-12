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
        MenuStrip1 = New MenuStrip()
        SalesToolStripMenuItem = New ToolStripMenuItem()
        InventoryToolStripMenuItem = New ToolStripMenuItem()
        SupplierToolStripMenuItem = New ToolStripMenuItem()
        ReportToolStripMenuItem = New ToolStripMenuItem()
        LogOutToolStripMenuItem = New ToolStripMenuItem()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        Label1 = New Label()
        ProductListDataGridView = New DataGridView()
        SearchProductButton = New Button()
        ProductSearchTextBox = New TextBox()
        OrderProductButton = New Button()
        AddProductButton = New Button()
        EditProductButton = New Button()
        DeleteProductButton = New Button()
        MenuStrip1.SuspendLayout()
        CType(ProductListDataGridView, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {SalesToolStripMenuItem, InventoryToolStripMenuItem, SupplierToolStripMenuItem, ReportToolStripMenuItem, LogOutToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1175, 28)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' SalesToolStripMenuItem
        ' 
        SalesToolStripMenuItem.Name = "SalesToolStripMenuItem"
        SalesToolStripMenuItem.Size = New Size(57, 24)
        SalesToolStripMenuItem.Text = "Sales"
        ' 
        ' InventoryToolStripMenuItem
        ' 
        InventoryToolStripMenuItem.Name = "InventoryToolStripMenuItem"
        InventoryToolStripMenuItem.Size = New Size(84, 24)
        InventoryToolStripMenuItem.Text = "Inventory"
        ' 
        ' SupplierToolStripMenuItem
        ' 
        SupplierToolStripMenuItem.Name = "SupplierToolStripMenuItem"
        SupplierToolStripMenuItem.Size = New Size(78, 24)
        SupplierToolStripMenuItem.Text = "Supplier"
        ' 
        ' ReportToolStripMenuItem
        ' 
        ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        ReportToolStripMenuItem.Size = New Size(68, 24)
        ReportToolStripMenuItem.Text = "Report"
        ' 
        ' LogOutToolStripMenuItem
        ' 
        LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        LogOutToolStripMenuItem.Size = New Size(76, 24)
        LogOutToolStripMenuItem.Text = "Log Out"
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
        ClientSize = New Size(1175, 525)
        Controls.Add(DeleteProductButton)
        Controls.Add(EditProductButton)
        Controls.Add(AddProductButton)
        Controls.Add(OrderProductButton)
        Controls.Add(ProductSearchTextBox)
        Controls.Add(SearchProductButton)
        Controls.Add(ProductListDataGridView)
        Controls.Add(Label1)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "InventoryForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "InventoryForm"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        CType(ProductListDataGridView, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupplierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As ToolStripMenuItem
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
