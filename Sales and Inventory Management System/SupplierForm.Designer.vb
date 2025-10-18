<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SupplierForm
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
        SalesToolStripMenuItem = New ToolStripMenuItem()
        InventoryToolStripMenuItem = New ToolStripMenuItem()
        SupplierToolStripMenuItem = New ToolStripMenuItem()
        ReportToolStripMenuItem = New ToolStripMenuItem()
        LogOutToolStripMenuItem = New ToolStripMenuItem()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        MenuStrip1 = New MenuStrip()
        DataGridViewSupplier = New DataGridView()
        Label2 = New Label()
        AddPictureBox = New PictureBox()
        MenuStrip1.SuspendLayout()
        CType(DataGridViewSupplier, ComponentModel.ISupportInitialize).BeginInit()
        CType(AddPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
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
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {SalesToolStripMenuItem, InventoryToolStripMenuItem, SupplierToolStripMenuItem, ReportToolStripMenuItem, LogOutToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1348, 28)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' DataGridViewSupplier
        ' 
        DataGridViewSupplier.AllowUserToAddRows = False
        DataGridViewSupplier.AllowUserToDeleteRows = False
        DataGridViewSupplier.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridViewSupplier.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewSupplier.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewSupplier.Location = New Point(36, 99)
        DataGridViewSupplier.Name = "DataGridViewSupplier"
        DataGridViewSupplier.RowHeadersWidth = 51
        DataGridViewSupplier.Size = New Size(1274, 578)
        DataGridViewSupplier.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        Label2.Location = New Point(319, 47)
        Label2.Name = "Label2"
        Label2.Size = New Size(162, 35)
        Label2.TabIndex = 6
        Label2.Text = "Supplier List"
        ' 
        ' AddPictureBox
        ' 
        AddPictureBox.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        AddPictureBox.BackColor = SystemColors.Control
        AddPictureBox.BackgroundImageLayout = ImageLayout.Zoom
        AddPictureBox.Image = My.Resources.Resources.AddIconBlue
        AddPictureBox.Location = New Point(1263, 44)
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
        ClientSize = New Size(1348, 721)
        Controls.Add(AddPictureBox)
        Controls.Add(Label2)
        Controls.Add(DataGridViewSupplier)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "SupplierForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "SupplierForm"
        WindowState = FormWindowState.Maximized
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        CType(DataGridViewSupplier, ComponentModel.ISupportInitialize).EndInit()
        CType(AddPictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents SalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupplierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As ToolStripMenuItem

    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DataGridViewSupplier As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents AddPictureBox As PictureBox

End Class
