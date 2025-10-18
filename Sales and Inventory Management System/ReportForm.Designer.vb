<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportForm
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
        SalesToolStripMenuItem = New ToolStripMenuItem()
        InventoryToolStripMenuItem = New ToolStripMenuItem()
        SupplierToolStripMenuItem = New ToolStripMenuItem()
        ReportToolStripMenuItem = New ToolStripMenuItem()
        LogOutToolStripMenuItem = New ToolStripMenuItem()
        ToDateTimePicker = New DateTimePicker()
        Label2 = New Label()
        Label3 = New Label()
        FromDateTimePicker = New DateTimePicker()
        GenerateButton = New Button()
        PrintButton = New Button()
        ReportDataGridView = New DataGridView()
        ReportPanel = New Panel()
        SaleReportButton = New Button()
        InventoryReportButton = New Button()
        Panel1 = New Panel()
        InventoryTrackingButton = New Button()
        MenuStrip1.SuspendLayout()
        CType(ReportDataGridView, ComponentModel.ISupportInitialize).BeginInit()
        ReportPanel.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {SalesToolStripMenuItem, InventoryToolStripMenuItem, SupplierToolStripMenuItem, ReportToolStripMenuItem, LogOutToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1178, 28)
        MenuStrip1.TabIndex = 0
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
        ' ToDateTimePicker
        ' 
        ToDateTimePicker.Location = New Point(633, 57)
        ToDateTimePicker.Name = "ToDateTimePicker"
        ToDateTimePicker.Size = New Size(262, 27)
        ToDateTimePicker.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(589, 62)
        Label2.Name = "Label2"
        Label2.Size = New Size(28, 20)
        Label2.TabIndex = 3
        Label2.Text = "To:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(243, 59)
        Label3.Name = "Label3"
        Label3.Size = New Size(46, 20)
        Label3.TabIndex = 4
        Label3.Text = "From:"
        ' 
        ' FromDateTimePicker
        ' 
        FromDateTimePicker.Location = New Point(295, 57)
        FromDateTimePicker.Name = "FromDateTimePicker"
        FromDateTimePicker.Size = New Size(260, 27)
        FromDateTimePicker.TabIndex = 5
        ' 
        ' GenerateButton
        ' 
        GenerateButton.Location = New Point(610, 193)
        GenerateButton.Name = "GenerateButton"
        GenerateButton.Size = New Size(94, 29)
        GenerateButton.TabIndex = 6
        GenerateButton.Text = "Generate"
        GenerateButton.UseVisualStyleBackColor = True
        ' 
        ' PrintButton
        ' 
        PrintButton.Location = New Point(931, 55)
        PrintButton.Name = "PrintButton"
        PrintButton.Size = New Size(94, 29)
        PrintButton.TabIndex = 7
        PrintButton.Text = "Print"
        PrintButton.UseVisualStyleBackColor = True
        ' 
        ' ReportDataGridView
        ' 
        ReportDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        ReportDataGridView.Location = New Point(88, 115)
        ReportDataGridView.Name = "ReportDataGridView"
        ReportDataGridView.RowHeadersWidth = 51
        ReportDataGridView.Size = New Size(445, 215)
        ReportDataGridView.TabIndex = 8
        ' 
        ' ReportPanel
        ' 
        ReportPanel.Controls.Add(ReportDataGridView)
        ReportPanel.Controls.Add(GenerateButton)
        ReportPanel.Location = New Point(179, 105)
        ReportPanel.Name = "ReportPanel"
        ReportPanel.Size = New Size(995, 394)
        ReportPanel.TabIndex = 11
        ' 
        ' SaleReportButton
        ' 
        SaleReportButton.Location = New Point(17, 32)
        SaleReportButton.Name = "SaleReportButton"
        SaleReportButton.Size = New Size(135, 29)
        SaleReportButton.TabIndex = 12
        SaleReportButton.Text = "Sale Report"
        SaleReportButton.UseVisualStyleBackColor = True
        ' 
        ' InventoryReportButton
        ' 
        InventoryReportButton.Location = New Point(17, 87)
        InventoryReportButton.Name = "InventoryReportButton"
        InventoryReportButton.Size = New Size(135, 29)
        InventoryReportButton.TabIndex = 13
        InventoryReportButton.Text = "Inventory Report"
        InventoryReportButton.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ControlLight
        Panel1.Controls.Add(InventoryTrackingButton)
        Panel1.Controls.Add(SaleReportButton)
        Panel1.Controls.Add(InventoryReportButton)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 28)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(169, 487)
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
        ' ReportForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1178, 515)
        Controls.Add(Panel1)
        Controls.Add(ReportPanel)
        Controls.Add(PrintButton)
        Controls.Add(FromDateTimePicker)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(ToDateTimePicker)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "ReportForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ReportForm"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        CType(ReportDataGridView, ComponentModel.ISupportInitialize).EndInit()
        ReportPanel.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupplierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToDateTimePicker As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents FromDateTimePicker As DateTimePicker
    Friend WithEvents GenerateButton As Button
    Friend WithEvents PrintButton As Button
    Friend WithEvents ReportDataGridView As DataGridView
    Friend WithEvents ReportPanel As Panel
    Friend WithEvents SaleReportButton As Button
    Friend WithEvents InventoryReportButton As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents InventoryTrackingButton As Button
End Class
