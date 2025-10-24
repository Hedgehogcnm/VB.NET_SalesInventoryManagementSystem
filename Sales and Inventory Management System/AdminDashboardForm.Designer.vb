<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminDashboardForm
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
        MenuStrip1 = New MenuStrip()
        LogoToolStripMenuItem = New ToolStripMenuItem()
        AboutUsToolStripMenuItem = New ToolStripMenuItem()
        LogOutToolStripMenuItem = New ToolStripMenuItem()
        Panel8 = New Panel()
        LabelForm = New Label()
        AdminTableLayoutPanel = New TableLayoutPanel()
        ChartPanel = New Panel()
        UserPanel = New Panel()
        ProductPanel = New FlowLayoutPanel()
        SupplierPanel = New FlowLayoutPanel()
        TableLayoutPanel2 = New TableLayoutPanel()
        MenuStrip1.SuspendLayout()
        Panel8.SuspendLayout()
        AdminTableLayoutPanel.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.BackColor = Color.SeaShell
        MenuStrip1.BackgroundImageLayout = ImageLayout.None
        MenuStrip1.Dock = DockStyle.Left
        MenuStrip1.ImageScalingSize = New Size(40, 40)
        MenuStrip1.Items.AddRange(New ToolStripItem() {LogoToolStripMenuItem, AboutUsToolStripMenuItem, LogOutToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New Padding(0)
        MenuStrip1.RenderMode = ToolStripRenderMode.Professional
        MenuStrip1.Size = New Size(68, 1033)
        MenuStrip1.TabIndex = 7
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
        ' AboutUsToolStripMenuItem
        ' 
        AboutUsToolStripMenuItem.Image = My.Resources.Resources.info1
        AboutUsToolStripMenuItem.Margin = New Padding(0, 700, 0, 0)
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
        ' Panel8
        ' 
        Panel8.BackColor = Color.SeaShell
        Panel8.Controls.Add(LabelForm)
        Panel8.Dock = DockStyle.Top
        Panel8.Location = New Point(68, 0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(1834, 60)
        Panel8.TabIndex = 8
        ' 
        ' LabelForm
        ' 
        LabelForm.AutoSize = True
        LabelForm.Font = New Font("Segoe UI", 17.0F, FontStyle.Bold)
        LabelForm.Location = New Point(15, 10)
        LabelForm.Name = "LabelForm"
        LabelForm.Size = New Size(265, 40)
        LabelForm.TabIndex = 0
        LabelForm.Text = "Admin Dashboard"
        ' 
        ' AdminTableLayoutPanel
        ' 
        AdminTableLayoutPanel.ColumnCount = 2
        AdminTableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 31.243185F))
        AdminTableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 68.75681F))
        AdminTableLayoutPanel.Controls.Add(ChartPanel, 1, 1)
        AdminTableLayoutPanel.Controls.Add(UserPanel, 0, 0)
        AdminTableLayoutPanel.Controls.Add(ProductPanel, 1, 0)
        AdminTableLayoutPanel.Controls.Add(SupplierPanel, 0, 1)
        AdminTableLayoutPanel.Dock = DockStyle.Fill
        AdminTableLayoutPanel.Location = New Point(3, 3)
        AdminTableLayoutPanel.Name = "AdminTableLayoutPanel"
        AdminTableLayoutPanel.RowCount = 2
        AdminTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 34.22405F))
        AdminTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 65.77595F))
        AdminTableLayoutPanel.Size = New Size(1828, 967)
        AdminTableLayoutPanel.TabIndex = 9
        ' 
        ' ChartPanel
        ' 
        ChartPanel.BackColor = Color.AntiqueWhite
        ChartPanel.Dock = DockStyle.Fill
        ChartPanel.Location = New Point(574, 333)
        ChartPanel.Name = "ChartPanel"
        ChartPanel.Padding = New Padding(10)
        ChartPanel.Size = New Size(1251, 631)
        ChartPanel.TabIndex = 0
        ' 
        ' UserPanel
        ' 
        UserPanel.BackColor = Color.AntiqueWhite
        UserPanel.Dock = DockStyle.Fill
        UserPanel.Location = New Point(3, 3)
        UserPanel.Name = "UserPanel"
        UserPanel.Size = New Size(565, 324)
        UserPanel.TabIndex = 2
        ' 
        ' ProductPanel
        ' 
        ProductPanel.AutoScroll = True
        ProductPanel.BackColor = Color.AntiqueWhite
        ProductPanel.Dock = DockStyle.Fill
        ProductPanel.Location = New Point(574, 3)
        ProductPanel.Name = "ProductPanel"
        ProductPanel.Size = New Size(1251, 324)
        ProductPanel.TabIndex = 4
        ' 
        ' SupplierPanel
        ' 
        SupplierPanel.BackColor = Color.AntiqueWhite
        SupplierPanel.Dock = DockStyle.Fill
        SupplierPanel.FlowDirection = FlowDirection.TopDown
        SupplierPanel.Location = New Point(3, 333)
        SupplierPanel.Name = "SupplierPanel"
        SupplierPanel.Size = New Size(565, 631)
        SupplierPanel.TabIndex = 5
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel2.Controls.Add(AdminTableLayoutPanel, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(68, 60)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20.0F))
        TableLayoutPanel2.Size = New Size(1834, 973)
        TableLayoutPanel2.TabIndex = 9
        ' 
        ' AdminDashboardForm
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1902, 1033)
        Controls.Add(TableLayoutPanel2)
        Controls.Add(Panel8)
        Controls.Add(MenuStrip1)
        Name = "AdminDashboardForm"
        WindowState = FormWindowState.Maximized
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        AdminTableLayoutPanel.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents LogoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutUsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel8 As Panel
    Friend WithEvents LabelForm As Label
    Friend WithEvents AdminTableLayoutPanel As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents ChartPanel As Panel
    Friend WithEvents UserPanel As Panel
    Friend WithEvents ProductPanel As FlowLayoutPanel
    Friend WithEvents SupplierPanel As FlowLayoutPanel
End Class
