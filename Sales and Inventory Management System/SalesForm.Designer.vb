<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesForm
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
        TableLayoutPanelTotal = New TableLayoutPanel()
<<<<<<< HEAD
        PanelRight = New Panel()
        TextBoxCustomerName = New TextBox()
=======
        PanelRight = New Panel()
>>>>>>> 824231ecdea8c38e63a55407cec0a17a9d4d94c5
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
        Panel9 = New Panel()
        Panel9 = New Panel()
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
        LogOutToolStripMenuItem = New ToolStripMenuItem()
        Panel3 = New Panel()
        TableLayoutPanel2 = New TableLayoutPanel()
        FlowLayoutPanelSales = New FlowLayoutPanel()
        TableLayoutPanel1 = New TableLayoutPanel()
        ComboBoxCategory = New ComboBox()
        ButtonSearch = New Button()
        Panel8 = New Panel()
        LabelForm = New Label()
        TableLayoutPanelTotal.SuspendLayout()
        PanelRight.SuspendLayout()
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
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.ImageScalingSize = New Size(20, 20)
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(61, 4)
        ' 
        ' TableLayoutPanelTotal
        ' 
        TableLayoutPanelTotal.BackColor = Color.AntiqueWhite
        TableLayoutPanelTotal.ColumnCount = 1
        TableLayoutPanelTotal.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanelTotal.Controls.Add(PanelRight, 0, 0)
        TableLayoutPanelTotal.Controls.Add(PanelRight, 0, 0)
        TableLayoutPanelTotal.Controls.Add(FlowLayoutPanelItem, 0, 1)
        TableLayoutPanelTotal.Controls.Add(Panel4, 0, 2)
        TableLayoutPanelTotal.Controls.Add(Panel5, 0, 3)
        TableLayoutPanelTotal.Controls.Add(Panel6, 0, 4)
        TableLayoutPanelTotal.Controls.Add(ButtonCheckOut, 0, 5)
        TableLayoutPanelTotal.Dock = DockStyle.Right
        TableLayoutPanelTotal.Location = New Point(798, 60)
        TableLayoutPanelTotal.Name = "TableLayoutPanelTotal"
        TableLayoutPanelTotal.RowCount = 6
        TableLayoutPanelTotal.RowStyles.Add(New RowStyle(SizeType.Percent, 10.7368422F))
        TableLayoutPanelTotal.RowStyles.Add(New RowStyle(SizeType.Percent, 89.26316F))
        TableLayoutPanelTotal.RowStyles.Add(New RowStyle(SizeType.Absolute, 48F))
        TableLayoutPanelTotal.RowStyles.Add(New RowStyle(SizeType.Absolute, 56F))
        TableLayoutPanelTotal.RowStyles.Add(New RowStyle(SizeType.Absolute, 65F))
        TableLayoutPanelTotal.RowStyles.Add(New RowStyle(SizeType.Absolute, 60F))
        TableLayoutPanelTotal.Size = New Size(554, 713)
        TableLayoutPanelTotal.TabIndex = 4
        ' 
        ' PanelRight
        ' PanelRight
        ' 
<<<<<<< HEAD
        Panel1.BackColor = Color.AntiqueWhite
        Panel1.Controls.Add(TextBoxCustomerName)
        Panel1.Controls.Add(labelInvoiceNo)
        Panel1.Controls.Add(Panel2)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(3, 3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(548, 45)
        Panel1.TabIndex = 2
=======
        PanelRight.BackColor = Color.AntiqueWhite
        PanelRight.Controls.Add(labelInvoiceNo)
        PanelRight.Controls.Add(Panel2)
        PanelRight.Controls.Add(Label1)
        PanelRight.Dock = DockStyle.Fill
        PanelRight.Location = New Point(3, 3)
        PanelRight.Name = "PanelRight"
        PanelRight.Size = New Size(548, 36)
        PanelRight.TabIndex = 2
>>>>>>> 824231ecdea8c38e63a55407cec0a17a9d4d94c5
        ' 
        ' TextBoxCustomerName
        ' 
        TextBoxCustomerName.BackColor = Color.AntiqueWhite
        TextBoxCustomerName.BorderStyle = BorderStyle.None
        TextBoxCustomerName.Font = New Font("Segoe UI", 17F, FontStyle.Bold)
        TextBoxCustomerName.Location = New Point(22, 17)
        TextBoxCustomerName.Name = "TextBoxCustomerName"
        TextBoxCustomerName.Size = New Size(215, 38)
        TextBoxCustomerName.TabIndex = 3
        TextBoxCustomerName.Text = "Customer Name"
        ' 
        ' labelInvoiceNo
        ' 
        labelInvoiceNo.AutoSize = True
        labelInvoiceNo.Font = New Font("Segoe UI", 8F, FontStyle.Italic)
        labelInvoiceNo.ForeColor = SystemColors.ControlDarkDark
        labelInvoiceNo.Location = New Point(385, 28)
        labelInvoiceNo.Name = "labelInvoiceNo"
        labelInvoiceNo.Size = New Size(41, 19)
        labelInvoiceNo.TabIndex = 1
        labelInvoiceNo.Text = "#INV"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Snow
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 42)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(548, 3)
        Panel2.TabIndex = 2
        ' 
        ' FlowLayoutPanelItem
        ' 
        FlowLayoutPanelItem.Dock = DockStyle.Fill
        FlowLayoutPanelItem.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanelItem.Location = New Point(3, 54)
        FlowLayoutPanelItem.Name = "FlowLayoutPanelItem"
        FlowLayoutPanelItem.Size = New Size(548, 426)
        FlowLayoutPanelItem.TabIndex = 3
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(Panel10)
        Panel4.Controls.Add(LabelSubTotal)
        Panel4.Controls.Add(Label2)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(3, 486)
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
        LabelSubTotal.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
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
        Label2.Font = New Font("Segoe UI", 10F)
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
        Panel5.Location = New Point(3, 534)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(548, 50)
        Panel5.TabIndex = 5
        ' 
        ' TextBoxDiscount
        ' 
        TextBoxDiscount.BackColor = Color.Snow
        TextBoxDiscount.BorderStyle = BorderStyle.None
        TextBoxDiscount.Cursor = Cursors.IBeam
        TextBoxDiscount.Font = New Font("Segoe UI", 9F)
        TextBoxDiscount.ForeColor = SystemColors.ControlDarkDark
        TextBoxDiscount.Location = New Point(16, 11)
        TextBoxDiscount.Name = "TextBoxDiscount"
        TextBoxDiscount.Size = New Size(125, 20)
        TextBoxDiscount.TabIndex = 6
        TextBoxDiscount.Text = "Discount (%)"
        ' 
        ' LabelDiscount
        ' 
        LabelDiscount.AutoSize = True
        LabelDiscount.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
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
        Panel6.Location = New Point(3, 590)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(548, 59)
        Panel6.TabIndex = 6
        ' 
        ' Panel9
        ' 
        Panel9.BackColor = Color.Snow
        Panel9.Dock = DockStyle.Bottom
        Panel9.Location = New Point(0, 56)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(548, 3)
        Panel9.TabIndex = 6
        ' 
        ' Panel9
        ' 
        Panel9.BackColor = Color.Snow
        Panel9.Dock = DockStyle.Bottom
        Panel9.Location = New Point(0, 56)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(548, 3)
        Panel9.TabIndex = 6
        ' 
        ' LabelTotal
        ' 
        LabelTotal.AutoSize = True
        LabelTotal.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
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
        Label3.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Label3.ForeColor = SystemColors.ControlDarkDark
        Label3.Location = New Point(16, 17)
        Label3.Name = "Label3"
        Label3.Size = New Size(64, 30)
        Label3.TabIndex = 4
        Label3.Text = "Total"
        ' 
        ' ButtonCheckOut
        ' 
        ButtonCheckOut.Dock = DockStyle.Fill
        ButtonCheckOut.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        ButtonCheckOut.Location = New Point(3, 655)
        ButtonCheckOut.Name = "ButtonCheckOut"
        ButtonCheckOut.Size = New Size(548, 55)
        ButtonCheckOut.TabIndex = 7
        ButtonCheckOut.Text = "Check Out"
        ButtonCheckOut.UseVisualStyleBackColor = True
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
        MenuStrip1.Size = New Size(150, 773)
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
        LogoToolStripMenuItem.Size = New Size(149, 62)
        ' 
        ' SalesToolStripMenuItem
        ' 
        SalesToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        SalesToolStripMenuItem.Font = New Font("Segoe UI", 9F)
        SalesToolStripMenuItem.Image = My.Resources.Resources.Sales1
        SalesToolStripMenuItem.Name = "SalesToolStripMenuItem"
        SalesToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        SalesToolStripMenuItem.Size = New Size(149, 80)
        SalesToolStripMenuItem.Tag = ""
        SalesToolStripMenuItem.ToolTipText = "Sales"
        ' 
        ' InventoryToolStripMenuItem
        ' 
        InventoryToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        InventoryToolStripMenuItem.Image = My.Resources.Resources.inventory
        InventoryToolStripMenuItem.Name = "InventoryToolStripMenuItem"
        InventoryToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        InventoryToolStripMenuItem.Size = New Size(149, 80)
        InventoryToolStripMenuItem.ToolTipText = "Inventory"
        ' 
        ' SupplierToolStripMenuItem
        ' 
        SupplierToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        SupplierToolStripMenuItem.Image = My.Resources.Resources.supplier
        SupplierToolStripMenuItem.Name = "SupplierToolStripMenuItem"
        SupplierToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        SupplierToolStripMenuItem.Size = New Size(149, 80)
        SupplierToolStripMenuItem.ToolTipText = "Supplier"
        ' 
        ' ReportToolStripMenuItem
        ' 
        ReportToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        ReportToolStripMenuItem.Image = My.Resources.Resources.report
        ReportToolStripMenuItem.Margin = New Padding(0, 0, 0, 529)
        ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        ReportToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        ReportToolStripMenuItem.Size = New Size(149, 80)
        ReportToolStripMenuItem.ToolTipText = "Report"
        ' 
        ' LogOutToolStripMenuItem
        ' 
        LogOutToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        LogOutToolStripMenuItem.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LogOutToolStripMenuItem.Image = My.Resources.Resources.logout
        LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        LogOutToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        LogOutToolStripMenuItem.Size = New Size(149, 80)
        LogOutToolStripMenuItem.ToolTipText = "Log Out"
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(TableLayoutPanel2)
        Panel3.Controls.Add(TableLayoutPanelTotal)
        Panel3.Controls.Add(Panel8)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(150, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1352, 773)
        Panel3.TabIndex = 6
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(FlowLayoutPanelSales, 0, 1)
        TableLayoutPanel2.Controls.Add(TableLayoutPanel1, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(0, 60)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 8.623298F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 91.3767F))
        TableLayoutPanel2.Size = New Size(798, 713)
        TableLayoutPanel2.TabIndex = 5
        ' 
        ' FlowLayoutPanelSales
        ' 
        FlowLayoutPanelSales.BackColor = SystemColors.Control
        FlowLayoutPanelSales.Dock = DockStyle.Fill
        FlowLayoutPanelSales.Location = New Point(3, 64)
        FlowLayoutPanelSales.Name = "FlowLayoutPanelSales"
        FlowLayoutPanelSales.Size = New Size(792, 646)
        FlowLayoutPanelSales.TabIndex = 1
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 4
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 77.5539551F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 22.446043F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 123F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 55F))
        TableLayoutPanel1.Controls.Add(ComboBoxCategory, 1, 1)
        TableLayoutPanel1.Controls.Add(ButtonSearch, 2, 1)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(3, 3)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 38.18182F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 61.81818F))
        TableLayoutPanel1.Size = New Size(792, 55)
        TableLayoutPanel1.TabIndex = 2
        ' 
        ' ComboBoxCategory
        ' 
        ComboBoxCategory.Anchor = AnchorStyles.None
        ComboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxCategory.FormattingEnabled = True
        ComboBoxCategory.Items.AddRange(New Object() {"All", "Building Materials", "Electrical", "Hand Tools", "Paint & Adhesives", "Plumbing", "Power Tools", "Safety Equipment"})
        ComboBoxCategory.Location = New Point(479, 24)
        ComboBoxCategory.Name = "ComboBoxCategory"
        ComboBoxCategory.Size = New Size(131, 28)
        ComboBoxCategory.TabIndex = 0
        ' 
        ' ButtonSearch
        ' 
        ButtonSearch.Anchor = AnchorStyles.None
        ButtonSearch.Location = New Point(617, 24)
        ButtonSearch.Name = "ButtonSearch"
        ButtonSearch.Size = New Size(115, 28)
        ButtonSearch.TabIndex = 1
        ButtonSearch.Text = "Search"
        ButtonSearch.UseVisualStyleBackColor = True
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.SeaShell
        Panel8.Controls.Add(LabelForm)
        Panel8.Dock = DockStyle.Top
        Panel8.Location = New Point(0, 0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(1352, 60)
        Panel8.TabIndex = 6
        ' 
        ' LabelForm
        ' 
        LabelForm.AutoSize = True
        LabelForm.Font = New Font("Segoe UI", 17F, FontStyle.Bold)
        LabelForm.Location = New Point(15, 10)
        LabelForm.Name = "LabelForm"
        LabelForm.Size = New Size(86, 40)
        LabelForm.TabIndex = 1
        LabelForm.Text = "Sales"
        LabelForm.TextAlign = ContentAlignment.MiddleLeft
        LabelForm.UseMnemonic = False
        ' 
        ' SalesForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        ClientSize = New Size(1502, 773)
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
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
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
End Class
