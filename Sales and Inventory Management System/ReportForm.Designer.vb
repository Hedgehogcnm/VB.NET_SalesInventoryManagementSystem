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
        Label1 = New Label()
        ToDateTimePicker = New DateTimePicker()
        Label2 = New Label()
        Label3 = New Label()
        FromDateTimePicker = New DateTimePicker()
        GenerateButton = New Button()
        PrintButton = New Button()
        ReportDataGridView = New DataGridView()
        PageSetupButton = New Button()
        PrintPreviewButton = New Button()
        MenuStrip1.SuspendLayout()
        CType(ReportDataGridView, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {SalesToolStripMenuItem, InventoryToolStripMenuItem, SupplierToolStripMenuItem, ReportToolStripMenuItem, LogOutToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(800, 28)
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
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(691, 421)
        Label1.Name = "Label1"
        Label1.Size = New Size(82, 20)
        Label1.TabIndex = 1
        Label1.Text = "Report en7"
        ' 
        ' ToDateTimePicker
        ' 
        ToDateTimePicker.Location = New Point(445, 61)
        ToDateTimePicker.Name = "ToDateTimePicker"
        ToDateTimePicker.Size = New Size(250, 27)
        ToDateTimePicker.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(401, 66)
        Label2.Name = "Label2"
        Label2.Size = New Size(28, 20)
        Label2.TabIndex = 3
        Label2.Text = "To:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(55, 63)
        Label3.Name = "Label3"
        Label3.Size = New Size(46, 20)
        Label3.TabIndex = 4
        Label3.Text = "From:"
        ' 
        ' FromDateTimePicker
        ' 
        FromDateTimePicker.Location = New Point(117, 61)
        FromDateTimePicker.Name = "FromDateTimePicker"
        FromDateTimePicker.Size = New Size(250, 27)
        FromDateTimePicker.TabIndex = 5
        ' 
        ' GenerateButton
        ' 
        GenerateButton.Location = New Point(159, 125)
        GenerateButton.Name = "GenerateButton"
        GenerateButton.Size = New Size(94, 29)
        GenerateButton.TabIndex = 6
        GenerateButton.Text = "Generate"
        GenerateButton.UseVisualStyleBackColor = True
        ' 
        ' PrintButton
        ' 
        PrintButton.Location = New Point(548, 125)
        PrintButton.Name = "PrintButton"
        PrintButton.Size = New Size(94, 29)
        PrintButton.TabIndex = 7
        PrintButton.Text = "Print"
        PrintButton.UseVisualStyleBackColor = True
        ' 
        ' ReportDataGridView
        ' 
        ReportDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        ReportDataGridView.Location = New Point(54, 184)
        ReportDataGridView.Name = "ReportDataGridView"
        ReportDataGridView.RowHeadersWidth = 51
        ReportDataGridView.Size = New Size(684, 232)
        ReportDataGridView.TabIndex = 8
        ' 
        ' PageSetupButton
        ' 
        PageSetupButton.Location = New Point(277, 125)
        PageSetupButton.Name = "PageSetupButton"
        PageSetupButton.Size = New Size(94, 29)
        PageSetupButton.TabIndex = 9
        PageSetupButton.Text = "Page Setup"
        PageSetupButton.UseVisualStyleBackColor = True
        ' 
        ' PrintPreviewButton
        ' 
        PrintPreviewButton.Location = New Point(408, 125)
        PrintPreviewButton.Name = "PrintPreviewButton"
        PrintPreviewButton.Size = New Size(111, 29)
        PrintPreviewButton.TabIndex = 10
        PrintPreviewButton.Text = "Page Review"
        PrintPreviewButton.UseVisualStyleBackColor = True
        ' 
        ' ReportForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(PrintPreviewButton)
        Controls.Add(PageSetupButton)
        Controls.Add(ReportDataGridView)
        Controls.Add(PrintButton)
        Controls.Add(GenerateButton)
        Controls.Add(FromDateTimePicker)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(ToDateTimePicker)
        Controls.Add(Label1)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "ReportForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ReportForm"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        CType(ReportDataGridView, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupplierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents ToDateTimePicker As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents FromDateTimePicker As DateTimePicker
    Friend WithEvents GenerateButton As Button
    Friend WithEvents PrintButton As Button
    Friend WithEvents ReportDataGridView As DataGridView
    Friend WithEvents PageSetupButton As Button
    Friend WithEvents PrintPreviewButton As Button
End Class
