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
        Panel1 = New Panel()
        labelInvoiceNo = New Label()
        Panel2 = New Panel()
        Label1 = New Label()
        FlowLayoutPanelItem = New FlowLayoutPanel()
        Panel4 = New Panel()
        LabelSubTotal = New Label()
        Label2 = New Label()
        Panel5 = New Panel()
        TextBoxDiscount = New TextBox()
        LabelDiscount = New Label()
        Panel6 = New Panel()
        LabelTotal = New Label()
        Panel7 = New Panel()
        Label3 = New Label()
        MenuStrip1 = New MenuStrip()
        SalesToolStripMenuItem = New ToolStripMenuItem()
        InventoryToolStripMenuItem = New ToolStripMenuItem()
        SupplierToolStripMenuItem = New ToolStripMenuItem()
        ReportToolStripMenuItem = New ToolStripMenuItem()
        LogOutToolStripMenuItem = New ToolStripMenuItem()
        Panel3 = New Panel()
        TableLayoutPanel2 = New TableLayoutPanel()
        FlowLayoutPanelSales = New FlowLayoutPanel()
        TableLayoutPanel3 = New TableLayoutPanel()
        ComboBoxCategory = New ComboBox()
        ButtonSearch = New Button()
        TableLayoutPanelTotal.SuspendLayout()
        Panel1.SuspendLayout()
        Panel4.SuspendLayout()
        Panel5.SuspendLayout()
        Panel6.SuspendLayout()
        MenuStrip1.SuspendLayout()
        Panel3.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
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
        TableLayoutPanelTotal.Controls.Add(Panel1, 0, 0)
        TableLayoutPanelTotal.Controls.Add(FlowLayoutPanelItem, 0, 1)
        TableLayoutPanelTotal.Controls.Add(Panel4, 0, 2)
        TableLayoutPanelTotal.Controls.Add(Panel5, 0, 3)
        TableLayoutPanelTotal.Controls.Add(Panel6, 0, 4)
        TableLayoutPanelTotal.Dock = DockStyle.Right
        TableLayoutPanelTotal.Location = New Point(715, 0)
        TableLayoutPanelTotal.Name = "TableLayoutPanelTotal"
        TableLayoutPanelTotal.RowCount = 5
        TableLayoutPanelTotal.RowStyles.Add(New RowStyle(SizeType.Percent, 8.952703F))
        TableLayoutPanelTotal.RowStyles.Add(New RowStyle(SizeType.Percent, 91.0472946F))
        TableLayoutPanelTotal.RowStyles.Add(New RowStyle(SizeType.Absolute, 65F))
        TableLayoutPanelTotal.RowStyles.Add(New RowStyle(SizeType.Absolute, 64F))
        TableLayoutPanelTotal.RowStyles.Add(New RowStyle(SizeType.Absolute, 65F))
        TableLayoutPanelTotal.Size = New Size(633, 693)
        TableLayoutPanelTotal.TabIndex = 4
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.AntiqueWhite
        Panel1.Controls.Add(labelInvoiceNo)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(3, 3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(627, 38)
        Panel1.TabIndex = 2
        ' 
        ' labelInvoiceNo
        ' 
        labelInvoiceNo.AutoSize = True
        labelInvoiceNo.Font = New Font("Segoe UI", 8F, FontStyle.Italic)
        labelInvoiceNo.ForeColor = SystemColors.ControlDarkDark
        labelInvoiceNo.Location = New Point(465, 27)
        labelInvoiceNo.Name = "labelInvoiceNo"
        labelInvoiceNo.Size = New Size(41, 19)
        labelInvoiceNo.TabIndex = 1
        labelInvoiceNo.Text = "#INV"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Snow
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 35)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(627, 3)
        Panel2.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 17F, FontStyle.Bold)
        Label1.Location = New Point(16, 16)
        Label1.Name = "Label1"
        Label1.Size = New Size(86, 40)
        Label1.TabIndex = 0
        Label1.Text = "Sales"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        Label1.UseMnemonic = False
        ' 
        ' FlowLayoutPanelItem
        ' 
        FlowLayoutPanelItem.Dock = DockStyle.Fill
        FlowLayoutPanelItem.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanelItem.Location = New Point(3, 47)
        FlowLayoutPanelItem.Name = "FlowLayoutPanelItem"
        FlowLayoutPanelItem.Size = New Size(627, 448)
        FlowLayoutPanelItem.TabIndex = 3
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(LabelSubTotal)
        Panel4.Controls.Add(Label2)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(3, 501)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(627, 59)
        Panel4.TabIndex = 4
        ' 
        ' LabelSubTotal
        ' 
        LabelSubTotal.AutoSize = True
        LabelSubTotal.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        LabelSubTotal.ForeColor = Color.Green
        LabelSubTotal.Location = New Point(503, 21)
        LabelSubTotal.Name = "LabelSubTotal"
        LabelSubTotal.Size = New Size(52, 23)
        LabelSubTotal.TabIndex = 4
        LabelSubTotal.Text = "RM 0"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F)
        Label2.ForeColor = SystemColors.ControlDarkDark
        Label2.Location = New Point(16, 21)
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
        Panel5.Location = New Point(3, 566)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(627, 58)
        Panel5.TabIndex = 5
        ' 
        ' TextBoxDiscount
        ' 
        TextBoxDiscount.BorderStyle = BorderStyle.FixedSingle
        TextBoxDiscount.Cursor = Cursors.IBeam
        TextBoxDiscount.Font = New Font("Segoe UI", 9F)
        TextBoxDiscount.ForeColor = SystemColors.ControlDarkDark
        TextBoxDiscount.Location = New Point(16, 19)
        TextBoxDiscount.Name = "TextBoxDiscount"
        TextBoxDiscount.Size = New Size(125, 27)
        TextBoxDiscount.TabIndex = 6
        TextBoxDiscount.Text = "Discount (%)"
        ' 
        ' LabelDiscount
        ' 
        LabelDiscount.AutoSize = True
        LabelDiscount.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        LabelDiscount.ForeColor = Color.Brown
        LabelDiscount.Location = New Point(491, 21)
        LabelDiscount.Name = "LabelDiscount"
        LabelDiscount.Size = New Size(64, 23)
        LabelDiscount.TabIndex = 5
        LabelDiscount.Text = "- RM 0"
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(LabelTotal)
        Panel6.Controls.Add(Panel7)
        Panel6.Controls.Add(Label3)
        Panel6.Dock = DockStyle.Fill
        Panel6.Location = New Point(3, 630)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(627, 60)
        Panel6.TabIndex = 6
        ' 
        ' LabelTotal
        ' 
        LabelTotal.AutoSize = True
        LabelTotal.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        LabelTotal.ForeColor = Color.Green
        LabelTotal.Location = New Point(503, 21)
        LabelTotal.Name = "LabelTotal"
        LabelTotal.Size = New Size(52, 23)
        LabelTotal.TabIndex = 5
        LabelTotal.Text = "RM 0"
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = Color.Snow
        Panel7.Dock = DockStyle.Top
        Panel7.Location = New Point(0, 0)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(627, 3)
        Panel7.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Label3.ForeColor = SystemColors.ControlDarkDark
        Label3.Location = New Point(16, 17)
        Label3.Name = "Label3"
        Label3.Size = New Size(104, 30)
        Label3.TabIndex = 4
        Label3.Text = "Discount"
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.BackColor = SystemColors.Control
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {SalesToolStripMenuItem, InventoryToolStripMenuItem, SupplierToolStripMenuItem, ReportToolStripMenuItem, LogOutToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1348, 28)
        MenuStrip1.TabIndex = 5
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
        ' Panel3
        ' 
        Panel3.Controls.Add(TableLayoutPanel2)
        Panel3.Controls.Add(TableLayoutPanelTotal)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(0, 28)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1348, 693)
        Panel3.TabIndex = 6
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(FlowLayoutPanelSales, 0, 1)
        TableLayoutPanel2.Controls.Add(TableLayoutPanel3, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(0, 0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 15F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 85F))
        TableLayoutPanel2.Size = New Size(715, 693)
        TableLayoutPanel2.TabIndex = 5
        ' 
        ' FlowLayoutPanelSales
        ' 
        FlowLayoutPanelSales.Dock = DockStyle.Fill
        FlowLayoutPanelSales.Location = New Point(3, 106)
        FlowLayoutPanelSales.Name = "FlowLayoutPanelSales"
        FlowLayoutPanelSales.Size = New Size(709, 584)
        FlowLayoutPanelSales.TabIndex = 1
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 4
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 80.9816F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 19.018404F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 101F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 47F))
        TableLayoutPanel3.Controls.Add(ComboBoxCategory, 1, 1)
        TableLayoutPanel3.Controls.Add(ButtonSearch, 2, 1)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(3, 3)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 2
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.Size = New Size(709, 97)
        TableLayoutPanel3.TabIndex = 2
        ' 
        ' ComboBoxCategory
        ' 
        ComboBoxCategory.Anchor = AnchorStyles.None
        ComboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxCategory.FormattingEnabled = True
        ComboBoxCategory.Items.AddRange(New Object() {"All", "Building Materials", "Electrical", "Hand Tools", "Paint & Adhesives", "Plumbing", "Power Tools", "Safety Equipment"})
        ComboBoxCategory.Location = New Point(457, 58)
        ComboBoxCategory.Name = "ComboBoxCategory"
        ComboBoxCategory.Size = New Size(100, 28)
        ComboBoxCategory.TabIndex = 0
        ' 
        ' ButtonSearch
        ' 
        ButtonSearch.Anchor = AnchorStyles.None
        ButtonSearch.Location = New Point(563, 58)
        ButtonSearch.Name = "ButtonSearch"
        ButtonSearch.Size = New Size(94, 29)
        ButtonSearch.TabIndex = 1
        ButtonSearch.Text = "Search"
        ButtonSearch.UseVisualStyleBackColor = True
        ' 
        ' SalesForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1348, 721)
        Controls.Add(Panel3)
        Controls.Add(MenuStrip1)
        Name = "SalesForm"
        StartPosition = FormStartPosition.CenterScreen
        WindowState = FormWindowState.Maximized
        TableLayoutPanelTotal.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
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
        TableLayoutPanel3.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents TableLayoutPanelTotal As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents labelInvoiceNo As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
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
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
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
End Class
