<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SalesForm
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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        TableLayoutPanelTotal = New TableLayoutPanel()
        PanelRight = New Panel()
        TextBoxCustomerName = New TextBox()
        labelInvoiceNo = New Label()
        Panel2 = New Panel()
        FlowLayoutPanelItem = New FlowLayoutPanel()
        Panel4 = New Panel()
        Panel10 = New Panel()
        LabelSubTotal = New Label()
        Label2 = New Label()
        Panel5 = New Panel()
        TextBoxDiscount = New TextBox()
        LabelDiscount = New Label()
        Panel6 = New Panel()
        LabelTotal = New Label()
        Panel7 = New Panel()
        Label3 = New Label()
        ButtonCheckOut = New Button()
        MenuStrip1 = New MenuStrip()
        LogoToolStripMenuItem = New ToolStripMenuItem()
        SalesToolStripMenuItem = New ToolStripMenuItem()
        InventoryToolStripMenuItem = New ToolStripMenuItem()
        SupplierToolStripMenuItem = New ToolStripMenuItem()
        ReportToolStripMenuItem = New ToolStripMenuItem()
        AboutUsToolStripMenuItem = New ToolStripMenuItem()
        LogOutToolStripMenuItem = New ToolStripMenuItem()
        Panel3 = New Panel()
        TableLayoutPanel2 = New TableLayoutPanel()
        FlowLayoutPanelSales = New FlowLayoutPanel()
        TableLayoutPanel1 = New TableLayoutPanel()
        ButtonSearch = New Button()
        ComboBoxCategory = New ComboBox()
        Panel8 = New Panel()
        LabelForm = New Label()
        TableLayoutPanelTotal.SuspendLayout()
        PanelRight.SuspendLayout()
        Panel4.SuspendLayout()
        Panel5.SuspendLayout()
        Panel6.SuspendLayout()
        MenuStrip1.SuspendLayout()
        Panel3.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        Panel8.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanelTotal
        ' 
        TableLayoutPanelTotal.BackColor = Color.AntiqueWhite
        TableLayoutPanelTotal.ColumnCount = 1
        TableLayoutPanelTotal.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        TableLayoutPanelTotal.Controls.Add(PanelRight, 0, 0)
        TableLayoutPanelTotal.Controls.Add(FlowLayoutPanelItem, 0, 1)
        TableLayoutPanelTotal.Controls.Add(Panel4, 0, 2)
        TableLayoutPanelTotal.Controls.Add(Panel5, 0, 3)
        TableLayoutPanelTotal.Controls.Add(Panel6, 0, 4)
        TableLayoutPanelTotal.Controls.Add(ButtonCheckOut, 0, 5)
        TableLayoutPanelTotal.Dock = DockStyle.Right
        TableLayoutPanelTotal.Location = New Point(1280, 60)
        TableLayoutPanelTotal.Name = "TableLayoutPanelTotal"
        TableLayoutPanelTotal.RowCount = 6
        TableLayoutPanelTotal.RowStyles.Add(New RowStyle(SizeType.Absolute, 59.0F))
        TableLayoutPanelTotal.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        TableLayoutPanelTotal.RowStyles.Add(New RowStyle(SizeType.Absolute, 48.0F))
        TableLayoutPanelTotal.RowStyles.Add(New RowStyle(SizeType.Absolute, 56.0F))
        TableLayoutPanelTotal.RowStyles.Add(New RowStyle(SizeType.Absolute, 65.0F))
        TableLayoutPanelTotal.RowStyles.Add(New RowStyle(SizeType.Absolute, 60.0F))
        TableLayoutPanelTotal.Size = New Size(554, 973)
        TableLayoutPanelTotal.TabIndex = 4
        ' 
        ' PanelRight
        ' 
        PanelRight.BackColor = Color.AntiqueWhite
        PanelRight.Controls.Add(TextBoxCustomerName)
        PanelRight.Controls.Add(labelInvoiceNo)
        PanelRight.Controls.Add(Panel2)
        PanelRight.Dock = DockStyle.Fill
        PanelRight.Location = New Point(3, 3)
        PanelRight.Name = "PanelRight"
        PanelRight.Size = New Size(548, 53)
        PanelRight.TabIndex = 2
        ' 
        ' TextBoxCustomerName
        ' 
        TextBoxCustomerName.BackColor = Color.AntiqueWhite
        TextBoxCustomerName.BorderStyle = BorderStyle.None
        TextBoxCustomerName.Font = New Font("Segoe UI", 17.0F, FontStyle.Bold)
        TextBoxCustomerName.Location = New Point(22, 5)
        TextBoxCustomerName.Name = "TextBoxCustomerName"
        TextBoxCustomerName.PlaceholderText = "Customer Name"
        TextBoxCustomerName.Size = New Size(249, 38)
        TextBoxCustomerName.TabIndex = 3
        TextBoxCustomerName.TabStop = False
        ' 
        ' labelInvoiceNo
        ' 
        labelInvoiceNo.AutoSize = True
        labelInvoiceNo.Font = New Font("Segoe UI", 8.0F, FontStyle.Italic)
        labelInvoiceNo.ForeColor = SystemColors.ControlDarkDark
        labelInvoiceNo.Location = New Point(385, 17)
        labelInvoiceNo.Name = "labelInvoiceNo"
        labelInvoiceNo.Size = New Size(41, 19)
        labelInvoiceNo.TabIndex = 1
        labelInvoiceNo.Text = "#INV"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Snow
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 50)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(548, 3)
        Panel2.TabIndex = 2
        ' 
        ' 
        ' FlowLayoutPanelItem
        ' 
        FlowLayoutPanelItem.BackColor = Color.AntiqueWhite
        FlowLayoutPanelItem.Dock = DockStyle.Fill
        FlowLayoutPanelItem.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanelItem.Location = New Point(3, 62)
        FlowLayoutPanelItem.Name = "FlowLayoutPanelItem"
        FlowLayoutPanelItem.Size = New Size(548, 679)
        FlowLayoutPanelItem.TabIndex = 3
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(Panel10)
        Panel4.Controls.Add(LabelSubTotal)
        Panel4.Controls.Add(Label2)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(3, 747)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(548, 42)
        Panel4.TabIndex = 4
        ' 
        ' Panel10
        ' 
        Panel10.BackColor = Color.Snow
        Panel10.Dock = DockStyle.Top
        Panel10.Location = New Point(0, 0)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(548, 3)
        Panel10.TabIndex = 3
        ' 
        ' LabelSubTotal
        ' 
        LabelSubTotal.AutoSize = True
        LabelSubTotal.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        LabelSubTotal.ForeColor = Color.Green
        LabelSubTotal.Location = New Point(420, 16)
        LabelSubTotal.Name = "LabelSubTotal"
        LabelSubTotal.Size = New Size(77, 23)
        LabelSubTotal.TabIndex = 4
        LabelSubTotal.Text = "RM 0.00"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10.0F)
        Label2.ForeColor = SystemColors.ControlDarkDark
        Label2.Location = New Point(16, 16)
        Label2.Name = "Label2"
        Label2.Size = New Size(52, 23)
        Label2.TabIndex = 3
        Label2.Text = "Items"
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(TextBoxDiscount)
        Panel5.Controls.Add(LabelDiscount)
        Panel5.Dock = DockStyle.Fill
        Panel5.Location = New Point(3, 795)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(548, 50)
        Panel5.TabIndex = 5
        ' 
        ' TextBoxDiscount
        ' 
        TextBoxDiscount.BackColor = Color.Snow
        TextBoxDiscount.BorderStyle = BorderStyle.None
        TextBoxDiscount.Font = New Font("Segoe UI", 9.0F)
        TextBoxDiscount.ForeColor = SystemColors.ControlDarkDark
        TextBoxDiscount.Location = New Point(16, 11)
        TextBoxDiscount.Name = "TextBoxDiscount"
        TextBoxDiscount.PlaceholderText = "Discount (%)"
        TextBoxDiscount.Size = New Size(125, 20)
        TextBoxDiscount.TabIndex = 6
        TextBoxDiscount.TabStop = False
        ' 
        ' LabelDiscount
        ' 
        LabelDiscount.AutoSize = True
        LabelDiscount.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        LabelDiscount.ForeColor = Color.Brown
        LabelDiscount.Location = New Point(408, 13)
        LabelDiscount.Name = "LabelDiscount"
        LabelDiscount.Size = New Size(89, 23)
        LabelDiscount.TabIndex = 5
        LabelDiscount.Text = "- RM 0.00"
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(LabelTotal)
        Panel6.Controls.Add(Panel7)
        Panel6.Controls.Add(Label3)
        Panel6.Dock = DockStyle.Fill
        Panel6.Location = New Point(3, 851)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(548, 59)
        Panel6.TabIndex = 6
        ' 
        ' LabelTotal
        ' 
        LabelTotal.AutoSize = True
        LabelTotal.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        LabelTotal.ForeColor = Color.Green
        LabelTotal.Location = New Point(420, 21)
        LabelTotal.Name = "LabelTotal"
        LabelTotal.Size = New Size(77, 23)
        LabelTotal.TabIndex = 5
        LabelTotal.Text = "RM 0.00"
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = Color.Snow
        Panel7.Dock = DockStyle.Top
        Panel7.Location = New Point(0, 0)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(548, 3)
        Panel7.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        Label3.ForeColor = SystemColors.ControlDarkDark
        Label3.Location = New Point(16, 17)
        Label3.Name = "Label3"
        Label3.Size = New Size(64, 30)
        Label3.TabIndex = 4
        Label3.Text = "Total"
        ' 
        ' ButtonCheckOut
        ' 
        ButtonCheckOut.BackColor = Color.SeaShell
        ButtonCheckOut.Dock = DockStyle.Fill
        ButtonCheckOut.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        ButtonCheckOut.Location = New Point(3, 916)
        ButtonCheckOut.Name = "ButtonCheckOut"
        ButtonCheckOut.Size = New Size(548, 54)
        ButtonCheckOut.TabIndex = 7
        ButtonCheckOut.Text = "Check Out"
        ButtonCheckOut.UseVisualStyleBackColor = False
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.BackColor = Color.SeaShell
        MenuStrip1.BackgroundImageLayout = ImageLayout.None
        MenuStrip1.Dock = DockStyle.Left
        MenuStrip1.ImageScalingSize = New Size(40, 40)
        MenuStrip1.Items.AddRange(New ToolStripItem() {LogoToolStripMenuItem, SalesToolStripMenuItem, InventoryToolStripMenuItem, SupplierToolStripMenuItem, ReportToolStripMenuItem, AboutUsToolStripMenuItem, LogOutToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New Padding(0)
        MenuStrip1.RenderMode = ToolStripRenderMode.Professional
        MenuStrip1.Size = New Size(68, 1033)
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
        ReportToolStripMenuItem.Margin = New Padding(0, 0, 0, 448)
        ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        ReportToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        ReportToolStripMenuItem.Size = New Size(67, 80)
        ReportToolStripMenuItem.ToolTipText = "Report"
        ' 
        ' AboutUsToolStripMenuItem
        ' 
        AboutUsToolStripMenuItem.Image = My.Resources.Resources.info1
        AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem"
        AboutUsToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        AboutUsToolStripMenuItem.Size = New Size(67, 80)
        ' 
        ' LogOutToolStripMenuItem
        ' 
        LogOutToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        LogOutToolStripMenuItem.Image = My.Resources.Resources.logout
        LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        LogOutToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        LogOutToolStripMenuItem.Size = New Size(67, 80)
        LogOutToolStripMenuItem.ToolTipText = "Log Out"
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(TableLayoutPanel2)
        Panel3.Controls.Add(TableLayoutPanelTotal)
        Panel3.Controls.Add(Panel8)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(68, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1834, 1033)
        Panel3.TabIndex = 6
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel2.Controls.Add(FlowLayoutPanelSales, 0, 1)
        TableLayoutPanel2.Controls.Add(TableLayoutPanel1, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(0, 60)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 55.0F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel2.Size = New Size(1280, 973)
        TableLayoutPanel2.TabIndex = 5
        ' 
        ' FlowLayoutPanelSales
        ' 
        FlowLayoutPanelSales.BackColor = SystemColors.Control
        FlowLayoutPanelSales.Dock = DockStyle.Fill
        FlowLayoutPanelSales.Location = New Point(3, 58)
        FlowLayoutPanelSales.Name = "FlowLayoutPanelSales"
        FlowLayoutPanelSales.Size = New Size(1274, 912)
        FlowLayoutPanelSales.TabIndex = 1
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 4
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 810.0F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 69.38271F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30.6172848F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 58.0F))
        TableLayoutPanel1.Controls.Add(ButtonSearch, 2, 0)
        TableLayoutPanel1.Controls.Add(ComboBoxCategory, 1, 0)
        TableLayoutPanel1.Dock = DockStyle.Top
        TableLayoutPanel1.Location = New Point(3, 3)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20.0F))
        TableLayoutPanel1.Size = New Size(1274, 49)
        TableLayoutPanel1.TabIndex = 2
        ' 
        ' ButtonSearch
        ' 
        ButtonSearch.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ButtonSearch.Location = New Point(1094, 18)
        ButtonSearch.Name = "ButtonSearch"
        ButtonSearch.Size = New Size(93, 28)
        ButtonSearch.TabIndex = 1
        ButtonSearch.Text = "Search"
        ' 
        ' ComboBoxCategory
        ' 
        ComboBoxCategory.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ComboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxCategory.Items.AddRange(New Object() {"All", "Building Materials", "Electrical", "Hand Tools", "Paint & Adhesives", "Plumbing", "Power Tools", "Safety Equipment"})
        ComboBoxCategory.Location = New Point(870, 18)
        ComboBoxCategory.Name = "ComboBoxCategory"
        ComboBoxCategory.Size = New Size(218, 28)
        ComboBoxCategory.TabIndex = 0
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.SeaShell
        Panel8.Controls.Add(LabelForm)
        Panel8.Dock = DockStyle.Top
        Panel8.Location = New Point(0, 0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(1834, 60)
        Panel8.TabIndex = 6
        ' 
        ' LabelForm
        ' 
        LabelForm.AutoSize = True
        LabelForm.Font = New Font("Segoe UI", 17.0F, FontStyle.Bold)
        LabelForm.Location = New Point(15, 10)
        LabelForm.Name = "LabelForm"
        LabelForm.Size = New Size(86, 40)
        LabelForm.TabIndex = 0
        LabelForm.Text = "Sales"
        ' 
        ' SalesForm
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        ClientSize = New Size(1902, 1033)
        Controls.Add(Panel3)
        Controls.Add(MenuStrip1)
        Name = "SalesForm"
        StartPosition = FormStartPosition.CenterScreen
        WindowState = FormWindowState.Maximized
        TableLayoutPanelTotal.ResumeLayout(False)
        PanelRight.ResumeLayout(False)
        PanelRight.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        Panel3.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents TableLayoutPanelTotal As TableLayoutPanel
    Friend WithEvents PanelRight As Panel
    Friend WithEvents labelInvoiceNo As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupplierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel3 As Panel
    Friend WithEvents FlowLayoutPanelItem As FlowLayoutPanel
    Friend WithEvents ComboBoxCategory As ComboBox
    Friend WithEvents ButtonSearch As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents FlowLayoutPanelSales As FlowLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents LabelSubTotal As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents LabelDiscount As Label
    Friend WithEvents TextBoxDiscount As TextBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents LabelTotal As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents LabelForm As Label
    Friend WithEvents LogoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel10 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TextBoxCustomerName As TextBox
    Friend WithEvents ButtonCheckOut As Button
    Friend WithEvents AboutUsToolStripMenuItem As ToolStripMenuItem
End Class
