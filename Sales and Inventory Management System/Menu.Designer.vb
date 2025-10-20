<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu))
        Panel8 = New Panel()
        Label4 = New Label()
        MenuStrip1 = New MenuStrip()
        LogoToolStripMenuItem = New ToolStripMenuItem()
        SalesToolStripMenuItem = New ToolStripMenuItem()
        InventoryToolStripMenuItem = New ToolStripMenuItem()
        SupplierToolStripMenuItem = New ToolStripMenuItem()
        ReportToolStripMenuItem = New ToolStripMenuItem()
        LogOutToolStripMenuItem = New ToolStripMenuItem()
        Panel8.SuspendLayout()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.SeaShell
        Panel8.Controls.Add(Label4)
        Panel8.Dock = DockStyle.Top
        Panel8.Location = New Point(68, 0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(1452, 60)
        Panel8.TabIndex = 8
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 17F, FontStyle.Bold)
        Label4.Location = New Point(15, 10)
        Label4.Name = "Label4"
        Label4.Size = New Size(86, 40)
        Label4.TabIndex = 1
        Label4.Text = "Sales"
        Label4.TextAlign = ContentAlignment.MiddleLeft
        Label4.UseMnemonic = False
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
        MenuStrip1.Size = New Size(68, 820)
        MenuStrip1.TabIndex = 7
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' LogoToolStripMenuItem
        ' 
        LogoToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        LogoToolStripMenuItem.Image = CType(resources.GetObject("LogoToolStripMenuItem.Image"), Image)
        LogoToolStripMenuItem.ImageTransparentColor = Color.White
        LogoToolStripMenuItem.Name = "LogoToolStripMenuItem"
        LogoToolStripMenuItem.Padding = New Padding(12, 0, 12, 18)
        LogoToolStripMenuItem.Size = New Size(67, 62)
        ' 
        ' SalesToolStripMenuItem
        ' 
        SalesToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        SalesToolStripMenuItem.Font = New Font("Segoe UI", 9F)
        SalesToolStripMenuItem.Image = CType(resources.GetObject("SalesToolStripMenuItem.Image"), Image)
        SalesToolStripMenuItem.Name = "SalesToolStripMenuItem"
        SalesToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        SalesToolStripMenuItem.Size = New Size(67, 80)
        SalesToolStripMenuItem.Tag = ""
        SalesToolStripMenuItem.ToolTipText = "Sales"
        ' 
        ' InventoryToolStripMenuItem
        ' 
        InventoryToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        InventoryToolStripMenuItem.Image = CType(resources.GetObject("InventoryToolStripMenuItem.Image"), Image)
        InventoryToolStripMenuItem.Name = "InventoryToolStripMenuItem"
        InventoryToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        InventoryToolStripMenuItem.Size = New Size(67, 80)
        InventoryToolStripMenuItem.ToolTipText = "Inventory"
        ' 
        ' SupplierToolStripMenuItem
        ' 
        SupplierToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        SupplierToolStripMenuItem.Image = CType(resources.GetObject("SupplierToolStripMenuItem.Image"), Image)
        SupplierToolStripMenuItem.Name = "SupplierToolStripMenuItem"
        SupplierToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        SupplierToolStripMenuItem.Size = New Size(67, 80)
        SupplierToolStripMenuItem.ToolTipText = "Supplier"
        ' 
        ' ReportToolStripMenuItem
        ' 
        ReportToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        ReportToolStripMenuItem.Image = CType(resources.GetObject("ReportToolStripMenuItem.Image"), Image)
        ReportToolStripMenuItem.Margin = New Padding(0, 0, 0, 529)
        ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        ReportToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        ReportToolStripMenuItem.Size = New Size(67, 80)
        ReportToolStripMenuItem.ToolTipText = "Report"
        ' 
        ' LogOutToolStripMenuItem
        ' 
        LogOutToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Image
        LogOutToolStripMenuItem.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LogOutToolStripMenuItem.Image = CType(resources.GetObject("LogOutToolStripMenuItem.Image"), Image)
        LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        LogOutToolStripMenuItem.Padding = New Padding(12, 18, 12, 18)
        LogOutToolStripMenuItem.Size = New Size(67, 80)
        LogOutToolStripMenuItem.ToolTipText = "Log Out"
        ' 
        ' Menu
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel8)
        Controls.Add(MenuStrip1)
        Name = "Menu"
        Size = New Size(1520, 820)
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents LogoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupplierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As ToolStripMenuItem

End Class
