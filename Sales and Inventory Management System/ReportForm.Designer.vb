<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReportForm
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
        AboutUsToolStripMenuItem = New ToolStripMenuItem()
        LogOutToolStripMenuItem = New ToolStripMenuItem()
        PanelMain = New Panel()
        ReportPanel = New Panel()
        PrintButton = New Button()
        FromDateTimePicker = New DateTimePicker()
        Label3 = New Label()
        Label2 = New Label()
        ToDateTimePicker = New DateTimePicker()
        Panel1 = New Panel()
        InventoryTrackingButton = New Button()
        SaleReportButton = New Button()
        InventoryReportButton = New Button()
        Panel8 = New Panel()
        LabelForm = New Label()
        MenuStrip1.SuspendLayout()
        PanelMain.SuspendLayout()
        Panel1.SuspendLayout()
        Panel8.SuspendLayout()
        SuspendLayout()
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
        ' PanelMain
        ' 
        PanelMain.BackColor = SystemColors.Control
        PanelMain.Controls.Add(ReportPanel)
        PanelMain.Controls.Add(PrintButton)
        PanelMain.Controls.Add(FromDateTimePicker)
        PanelMain.Controls.Add(Label3)
        PanelMain.Controls.Add(Label2)
        PanelMain.Controls.Add(ToDateTimePicker)
        PanelMain.Controls.Add(Panel1)
        PanelMain.Controls.Add(Panel8)
        PanelMain.Dock = DockStyle.Fill
        PanelMain.Location = New Point(68, 0)
        PanelMain.Name = "PanelMain"
        PanelMain.Size = New Size(1834, 1033)
        PanelMain.TabIndex = 6
        ' 
        ' ReportPanel
        ' 
        ReportPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ReportPanel.BackColor = SystemColors.ActiveBorder
        ReportPanel.Location = New Point(179, 120)
        ReportPanel.Name = "ReportPanel"
        ReportPanel.Size = New Size(1643, 876)
        ReportPanel.TabIndex = 11
        ' 
        ' PrintButton
        ' 
        PrintButton.Location = New Point(1687, 76)
        PrintButton.Name = "PrintButton"
        PrintButton.Size = New Size(94, 29)
        PrintButton.TabIndex = 7
        PrintButton.Text = "Print"
        PrintButton.UseVisualStyleBackColor = True
        ' 
        ' FromDateTimePicker
        ' 
        FromDateTimePicker.Location = New Point(272, 77)
        FromDateTimePicker.Name = "FromDateTimePicker"
        FromDateTimePicker.Size = New Size(260, 27)
        FromDateTimePicker.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(220, 80)
        Label3.Name = "Label3"
        Label3.Size = New Size(46, 20)
        Label3.TabIndex = 4
        Label3.Text = "From:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(570, 80)
        Label2.Name = "Label2"
        Label2.Size = New Size(28, 20)
        Label2.TabIndex = 3
        Label2.Text = "To:"
        ' 
        ' ToDateTimePicker
        ' 
        ToDateTimePicker.Location = New Point(614, 77)
        ToDateTimePicker.Name = "ToDateTimePicker"
        ToDateTimePicker.Size = New Size(262, 27)
        ToDateTimePicker.TabIndex = 2
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.AntiqueWhite
        Panel1.Controls.Add(InventoryTrackingButton)
        Panel1.Controls.Add(SaleReportButton)
        Panel1.Controls.Add(InventoryReportButton)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 60)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(169, 973)
        Panel1.TabIndex = 14
        ' 
        ' InventoryTrackingButton
        ' 
        InventoryTrackingButton.Location = New Point(17, 142)
        InventoryTrackingButton.Name = "InventoryTrackingButton"
        InventoryTrackingButton.Size = New Size(135, 54)
        InventoryTrackingButton.TabIndex = 14
        InventoryTrackingButton.Text = "Inventory Tracking Report"
        InventoryTrackingButton.UseVisualStyleBackColor = True
        ' 
        ' SaleReportButton
        ' 
        SaleReportButton.BackColor = SystemColors.Control
        SaleReportButton.ForeColor = Color.Black
        SaleReportButton.Location = New Point(17, 32)
        SaleReportButton.Name = "SaleReportButton"
        SaleReportButton.Size = New Size(135, 29)
        SaleReportButton.TabIndex = 12
        SaleReportButton.Text = "Sale Report"
        SaleReportButton.UseVisualStyleBackColor = False
        ' 
        ' InventoryReportButton
        ' 
        InventoryReportButton.BackColor = SystemColors.ControlLight
        InventoryReportButton.ForeColor = SystemColors.ControlText
        InventoryReportButton.Location = New Point(17, 87)
        InventoryReportButton.Name = "InventoryReportButton"
        InventoryReportButton.Size = New Size(138, 29)
        InventoryReportButton.TabIndex = 13
        InventoryReportButton.Text = "Inventory Report"
        InventoryReportButton.UseVisualStyleBackColor = False
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.SeaShell
        Panel8.Controls.Add(LabelForm)
        Panel8.Dock = DockStyle.Top
        Panel8.Location = New Point(0, 0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(1834, 60)
        Panel8.TabIndex = 0
        ' 
        ' LabelForm
        ' 
        LabelForm.AutoSize = True
        LabelForm.Font = New Font("Segoe UI", 17F, FontStyle.Bold)
        LabelForm.Location = New Point(15, 10)
        LabelForm.Name = "LabelForm"
        LabelForm.Size = New Size(111, 40)
        LabelForm.TabIndex = 1
        LabelForm.Text = "Report"
        LabelForm.TextAlign = ContentAlignment.MiddleLeft
        LabelForm.UseMnemonic = False
        ' 
        ' ReportForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1902, 1033)
        Controls.Add(PanelMain)
        Controls.Add(MenuStrip1)
        Name = "ReportForm"
        StartPosition = FormStartPosition.CenterScreen
        WindowState = FormWindowState.Maximized
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        PanelMain.ResumeLayout(False)
        PanelMain.PerformLayout()
        Panel1.ResumeLayout(False)
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
    Friend WithEvents ToDateTimePicker As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents FromDateTimePicker As DateTimePicker
    Friend WithEvents PrintButton As Button
    Friend WithEvents ReportPanel As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents InventoryTrackingButton As Button
    Friend WithEvents SaleReportButton As Button
    Friend WithEvents InventoryReportButton As Button
    Friend WithEvents AboutUsToolStripMenuItem As ToolStripMenuItem
End Class
