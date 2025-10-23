<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SupplierForm
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
        SupplierFlowLayoutPanel = New FlowLayoutPanel()
        Panel8 = New Panel()
        LabelForm = New Label()
        AddPictureBox = New PictureBox()
        MenuStrip1.SuspendLayout()
        PanelMain.SuspendLayout()
        Panel8.SuspendLayout()
        CType(AddPictureBox, ComponentModel.ISupportInitialize).BeginInit()
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
        LogoToolStripMenuItem.Size = New Size(149, 62)
        ' 
        ' SalesToolStripMenuItem
        ' 
        SalesToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        SalesToolStripMenuItem.Image = My.Resources.Resources.Sales1
        SalesToolStripMenuItem.Name = "SalesToolStripMenuItem"
        SalesToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        SalesToolStripMenuItem.Size = New Size(149, 80)
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
        LogOutToolStripMenuItem.Image = My.Resources.Resources.logout
        LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        LogOutToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        LogOutToolStripMenuItem.Size = New Size(149, 80)
        LogOutToolStripMenuItem.ToolTipText = "Log Out"
        ' 
        ' PanelMain
        ' 
        PanelMain.Controls.Add(SupplierFlowLayoutPanel)
        PanelMain.Controls.Add(Panel8)
        PanelMain.Dock = DockStyle.Fill
        PanelMain.Location = New Point(68, 0)
        PanelMain.Name = "PanelMain"
        PanelMain.Size = New Size(1434, 773)
        PanelMain.TabIndex = 6
        ' 
        ' SupplierFlowLayoutPanel
        ' 
        SupplierFlowLayoutPanel.Dock = DockStyle.Fill
        SupplierFlowLayoutPanel.Location = New Point(0, 60)
        SupplierFlowLayoutPanel.Name = "SupplierFlowLayoutPanel"
        SupplierFlowLayoutPanel.Size = New Size(1434, 713)
        SupplierFlowLayoutPanel.TabIndex = 8
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.SeaShell
        Panel8.Controls.Add(LabelForm)
        Panel8.Controls.Add(AddPictureBox)
        Panel8.Dock = DockStyle.Top
        Panel8.Location = New Point(0, 0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(1434, 60)
        Panel8.TabIndex = 0
        ' 
        ' LabelForm
        ' 
        LabelForm.AutoSize = True
        LabelForm.Font = New Font("Segoe UI", 17F, FontStyle.Bold)
        LabelForm.Location = New Point(15, 10)
        LabelForm.Name = "LabelForm"
        LabelForm.Size = New Size(131, 40)
        LabelForm.TabIndex = 1
        LabelForm.Text = "Supplier"
        LabelForm.TextAlign = ContentAlignment.MiddleLeft
        LabelForm.UseMnemonic = False
        ' 
        ' AddPictureBox
        ' 
        AddPictureBox.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        AddPictureBox.BackColor = Color.SeaShell
        AddPictureBox.BackgroundImageLayout = ImageLayout.Zoom
        AddPictureBox.Image = My.Resources.Resources.AddIconBlue
        AddPictureBox.Location = New Point(1306, 8)
        AddPictureBox.Name = "AddPictureBox"
        AddPictureBox.Size = New Size(47, 46)
        AddPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        AddPictureBox.TabIndex = 7
        AddPictureBox.TabStop = False
        ' 
        ' SupplierForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1502, 773)
        Controls.Add(PanelMain)
        Controls.Add(MenuStrip1)
        Name = "SupplierForm"
        StartPosition = FormStartPosition.CenterScreen
        WindowState = FormWindowState.Maximized
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        PanelMain.ResumeLayout(False)
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        CType(AddPictureBox, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents AddPictureBox As PictureBox
    Friend WithEvents SupplierFlowLayoutPanel As FlowLayoutPanel
End Class