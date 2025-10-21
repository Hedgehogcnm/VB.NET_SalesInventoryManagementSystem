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
        DataGridViewSupplier = New DataGridView()
        AddPictureBox = New PictureBox()
        Label2 = New Label()
        Panel8 = New Panel()
        LabelForm = New Label()
        MenuStrip1.SuspendLayout()
        PanelMain.SuspendLayout()
        CType(DataGridViewSupplier, ComponentModel.ISupportInitialize).BeginInit()
        CType(AddPictureBox, ComponentModel.ISupportInitialize).BeginInit()
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
        LogOutToolStripMenuItem.Image = My.Resources.Resources.logout
        LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        LogOutToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        LogOutToolStripMenuItem.Size = New Size(67, 80)
        LogOutToolStripMenuItem.ToolTipText = "Log Out"
        ' 
        ' PanelMain
        ' 
        PanelMain.Controls.Add(DataGridViewSupplier)
        PanelMain.Controls.Add(AddPictureBox)
        PanelMain.Controls.Add(Label2)
        PanelMain.Controls.Add(Panel8)
        PanelMain.Dock = DockStyle.Fill
        PanelMain.Location = New Point(68, 0)
        PanelMain.Name = "PanelMain"
        PanelMain.Size = New Size(1434, 773)
        PanelMain.TabIndex = 6
        ' 
        ' DataGridViewSupplier
        ' 
        DataGridViewSupplier.AllowUserToAddRows = False
        DataGridViewSupplier.AllowUserToDeleteRows = False
        DataGridViewSupplier.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridViewSupplier.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewSupplier.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewSupplier.Location = New Point(35, 147)
        DataGridViewSupplier.Name = "DataGridViewSupplier"
        DataGridViewSupplier.RowHeadersWidth = 51
        DataGridViewSupplier.Size = New Size(1274, 578)
        DataGridViewSupplier.TabIndex = 2
        ' 
        ' AddPictureBox
        ' 
        AddPictureBox.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        AddPictureBox.BackColor = SystemColors.Control
        AddPictureBox.BackgroundImageLayout = ImageLayout.Zoom
        AddPictureBox.Image = My.Resources.Resources.AddIconBlue
        AddPictureBox.Location = New Point(1262, 92)
        AddPictureBox.Name = "AddPictureBox"
        AddPictureBox.Size = New Size(47, 46)
        AddPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        AddPictureBox.TabIndex = 7
        AddPictureBox.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 15.0F, FontStyle.Bold)
        Label2.Location = New Point(318, 95)
        Label2.Name = "Label2"
        Label2.Size = New Size(162, 35)
        Label2.TabIndex = 6
        Label2.Text = "Supplier List"
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.SeaShell
        Panel8.Controls.Add(LabelForm)
        Panel8.Dock = DockStyle.Top
        Panel8.Location = New Point(0, 0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(1434, 60)
        Panel8.TabIndex = 0
        ' 
        ' LabelForm
        ' 
        LabelForm.AutoSize = True
        LabelForm.Font = New Font("Segoe UI", 17.0F, FontStyle.Bold)
        LabelForm.Location = New Point(15, 10)
        LabelForm.Name = "LabelForm"
        LabelForm.Size = New Size(131, 40)
        LabelForm.TabIndex = 1
        LabelForm.Text = "Supplier"
        LabelForm.TextAlign = ContentAlignment.MiddleLeft
        LabelForm.UseMnemonic = False
        ' 
        ' SupplierForm
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
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
        PanelMain.PerformLayout()
        CType(DataGridViewSupplier, ComponentModel.ISupportInitialize).EndInit()
        CType(AddPictureBox, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DataGridViewSupplier As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents AddPictureBox As PictureBox
End Class