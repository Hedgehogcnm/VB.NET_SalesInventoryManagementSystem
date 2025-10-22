<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InventoryForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        MenuStrip1 = New MenuStrip()
        LogoToolStripMenuItem = New ToolStripMenuItem()
        SalesToolStripMenuItem = New ToolStripMenuItem()
        InventoryToolStripMenuItem = New ToolStripMenuItem()
        SupplierToolStripMenuItem = New ToolStripMenuItem()
        ReportToolStripMenuItem = New ToolStripMenuItem()
        LogOutToolStripMenuItem = New ToolStripMenuItem()
        PanelMain = New Panel()
        HeaderPanel = New Panel()
        ViewOrderButton = New Button()
        ProductListFlowLayoutPanel = New FlowLayoutPanel()
        SearchProductButton = New Button()
        ProductSearchTextBox = New TextBox()
        AddProductButton = New Button()
        Panel8 = New Panel()
        LabelForm = New Label()
        MenuStrip1.SuspendLayout()
        PanelMain.SuspendLayout()
        Panel8.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.BackColor = Color.SeaShell
        MenuStrip1.BackgroundImageLayout = ImageLayout.None
        MenuStrip1.Dock = DockStyle.Left
        MenuStrip1.ImageScalingSize = New Size(40, 40)
        MenuStrip1.Items.AddRange(New ToolStripItem() {LogoToolStripMenuItem, SalesToolStripMenuItem, InventoryToolStripMenuItem, SupplierToolStripMenuItem, ReportToolStripMenuItem, LogOutToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New Padding(0)
        MenuStrip1.RenderMode = ToolStripRenderMode.Professional
        MenuStrip1.Size = New Size(68, 773)
        MenuStrip1.TabIndex = 5
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' LogoToolStripMenuItem
        ' 
        LogoToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        LogoToolStripMenuItem.Image = My.Resources.Resources.logo_75_
        LogoToolStripMenuItem.ImageTransparentColor = Color.White
        LogoToolStripMenuItem.Name = "LogoToolStripMenuItem"
        LogoToolStripMenuItem.Padding = New Padding(12, 0, 12, 18)
        LogoToolStripMenuItem.Size = New Size(67, 62)
        ' 
        ' SalesToolStripMenuItem
        ' 
        SalesToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        SalesToolStripMenuItem.Font = New Font("Segoe UI", 9F)
        SalesToolStripMenuItem.Image = My.Resources.Resources.Sales1
        SalesToolStripMenuItem.Name = "SalesToolStripMenuItem"
        SalesToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        SalesToolStripMenuItem.Size = New Size(67, 80)
        SalesToolStripMenuItem.ToolTipText = "Sales"
        ' 
        ' InventoryToolStripMenuItem
        ' 
        InventoryToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        InventoryToolStripMenuItem.Image = My.Resources.Resources.inventory
        InventoryToolStripMenuItem.Name = "InventoryToolStripMenuItem"
        InventoryToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        InventoryToolStripMenuItem.Size = New Size(67, 80)
        InventoryToolStripMenuItem.ToolTipText = "Inventory"
        ' 
        ' SupplierToolStripMenuItem
        ' 
        SupplierToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        SupplierToolStripMenuItem.Image = My.Resources.Resources.supplier
        SupplierToolStripMenuItem.Name = "SupplierToolStripMenuItem"
        SupplierToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        SupplierToolStripMenuItem.Size = New Size(67, 80)
        SupplierToolStripMenuItem.ToolTipText = "Supplier"
        ' 
        ' ReportToolStripMenuItem
        ' 
        ReportToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        ReportToolStripMenuItem.Image = My.Resources.Resources.report
        ReportToolStripMenuItem.Margin = New Padding(0, 0, 0, 529)
        ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        ReportToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        ReportToolStripMenuItem.Size = New Size(67, 80)
        ReportToolStripMenuItem.ToolTipText = "Report"
        ' 
        ' LogOutToolStripMenuItem
        ' 
        LogOutToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        LogOutToolStripMenuItem.Font = New Font("Segoe UI", 9F)
        LogOutToolStripMenuItem.Image = My.Resources.Resources.logout
        LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        LogOutToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        LogOutToolStripMenuItem.Size = New Size(67, 80)
        LogOutToolStripMenuItem.ToolTipText = "Log Out"
        ' 
        ' PanelMain
        ' 
        PanelMain.Controls.Add(HeaderPanel)
        PanelMain.Controls.Add(ViewOrderButton)
        PanelMain.Controls.Add(ProductListFlowLayoutPanel)
        PanelMain.Controls.Add(SearchProductButton)
        PanelMain.Controls.Add(ProductSearchTextBox)
        PanelMain.Controls.Add(AddProductButton)
        PanelMain.Controls.Add(Panel8)
        PanelMain.Dock = DockStyle.Fill
        PanelMain.Location = New Point(68, 0)
        PanelMain.Name = "PanelMain"
        PanelMain.Size = New Size(1686, 773)
        PanelMain.TabIndex = 6
        ' 
        ' HeaderPanel
        ' 
        HeaderPanel.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        HeaderPanel.Location = New Point(3, 136)
        HeaderPanel.Name = "HeaderPanel"
        HeaderPanel.Size = New Size(1629, 48)
        HeaderPanel.TabIndex = 12
        ' 
        ' ViewOrderButton
        ' 
        ViewOrderButton.Location = New Point(147, 81)
        ViewOrderButton.Name = "ViewOrderButton"
        ViewOrderButton.Size = New Size(105, 49)
        ViewOrderButton.TabIndex = 11
        ViewOrderButton.Text = "View Order"
        ViewOrderButton.UseVisualStyleBackColor = True
        ' 
        ' ProductListFlowLayoutPanel
        ' 
        ProductListFlowLayoutPanel.Location = New Point(3, 190)
        ProductListFlowLayoutPanel.Name = "ProductListFlowLayoutPanel"
        ProductListFlowLayoutPanel.Size = New Size(1655, 840)
        ProductListFlowLayoutPanel.TabIndex = 10
        ' 
        ' SearchProductButton
        ' 
        SearchProductButton.Location = New Point(1538, 91)
        SearchProductButton.Name = "SearchProductButton"
        SearchProductButton.Size = New Size(94, 29)
        SearchProductButton.TabIndex = 4
        SearchProductButton.Text = "Search"
        SearchProductButton.UseVisualStyleBackColor = True
        ' 
        ' ProductSearchTextBox
        ' 
        ProductSearchTextBox.Location = New Point(1242, 92)
        ProductSearchTextBox.Name = "ProductSearchTextBox"
        ProductSearchTextBox.Size = New Size(276, 27)
        ProductSearchTextBox.TabIndex = 5
        ' 
        ' AddProductButton
        ' 
        AddProductButton.Location = New Point(15, 81)
        AddProductButton.Name = "AddProductButton"
        AddProductButton.Size = New Size(111, 48)
        AddProductButton.TabIndex = 7
        AddProductButton.Text = "Add Product"
        AddProductButton.UseVisualStyleBackColor = True
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.SeaShell
        Panel8.Controls.Add(LabelForm)
        Panel8.Dock = DockStyle.Top
        Panel8.Location = New Point(0, 0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(1686, 60)
        Panel8.TabIndex = 0
        ' 
        ' LabelForm
        ' 
        LabelForm.AutoSize = True
        LabelForm.Font = New Font("Segoe UI", 17F, FontStyle.Bold)
        LabelForm.Location = New Point(15, 10)
        LabelForm.Name = "LabelForm"
        LabelForm.Size = New Size(152, 40)
        LabelForm.TabIndex = 1
        LabelForm.Text = "Inventory"
        LabelForm.TextAlign = ContentAlignment.MiddleLeft
        LabelForm.UseMnemonic = False
        ' 
        ' InventoryForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1754, 773)
        Controls.Add(PanelMain)
        Controls.Add(MenuStrip1)
        Name = "InventoryForm"
        StartPosition = FormStartPosition.CenterScreen
        WindowState = FormWindowState.Maximized
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        PanelMain.ResumeLayout(False)
        PanelMain.PerformLayout()
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents LogoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupplierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PanelMain As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents LabelForm As Label
    Friend WithEvents SearchProductButton As Button
    Friend WithEvents ProductSearchTextBox As TextBox
    Friend WithEvents AddProductButton As Button
    Friend WithEvents ProductListFlowLayoutPanel As FlowLayoutPanel
    Friend WithEvents ViewOrderButton As Button
    Friend WithEvents HeaderPanel As Panel
End Class
