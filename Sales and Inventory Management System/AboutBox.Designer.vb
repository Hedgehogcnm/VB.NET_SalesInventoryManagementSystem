<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutBox
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

    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents LabelProductName As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents LabelCompanyName As System.Windows.Forms.Label
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutBox))
        TableLayoutPanel = New TableLayoutPanel()
        LogoPictureBox = New PictureBox()
        LabelProductName = New Label()
        LabelVersion = New Label()
        LabelCopyright = New Label()
        LabelCompanyName = New Label()
        TextBoxDescription = New TextBox()
        OKButton = New Button()
        TableLayoutPanel.SuspendLayout()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TableLayoutPanel
        ' 
        TableLayoutPanel.ColumnCount = 2
        TableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 45.35519F))
        TableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 54.6448059F))
        TableLayoutPanel.Controls.Add(LogoPictureBox, 0, 0)
        TableLayoutPanel.Controls.Add(LabelProductName, 1, 0)
        TableLayoutPanel.Controls.Add(LabelVersion, 1, 1)
        TableLayoutPanel.Controls.Add(LabelCopyright, 1, 2)
        TableLayoutPanel.Controls.Add(LabelCompanyName, 1, 3)
        TableLayoutPanel.Controls.Add(TextBoxDescription, 1, 4)
        TableLayoutPanel.Controls.Add(OKButton, 1, 5)
        TableLayoutPanel.Dock = DockStyle.Fill
        TableLayoutPanel.Location = New Point(12, 14)
        TableLayoutPanel.Margin = New Padding(4, 5, 4, 5)
        TableLayoutPanel.Name = "TableLayoutPanel"
        TableLayoutPanel.RowCount = 6
        TableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        TableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        TableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        TableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        TableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        TableLayoutPanel.Size = New Size(975, 442)
        TableLayoutPanel.TabIndex = 0
        ' 
        ' LogoPictureBox
        ' 
        LogoPictureBox.Dock = DockStyle.Fill
        LogoPictureBox.Image = My.Resources.Resources.logo__500_
        LogoPictureBox.Location = New Point(4, 5)
        LogoPictureBox.Margin = New Padding(4, 5, 4, 5)
        LogoPictureBox.Name = "LogoPictureBox"
        TableLayoutPanel.SetRowSpan(LogoPictureBox, 6)
        LogoPictureBox.Size = New Size(434, 432)
        LogoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage
        LogoPictureBox.TabIndex = 0
        LogoPictureBox.TabStop = False
        ' 
        ' LabelProductName
        ' 
        LabelProductName.Dock = DockStyle.Fill
        LabelProductName.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LabelProductName.Location = New Point(450, 0)
        LabelProductName.Margin = New Padding(8, 0, 4, 0)
        LabelProductName.MaximumSize = New Size(0, 26)
        LabelProductName.Name = "LabelProductName"
        LabelProductName.Size = New Size(521, 26)
        LabelProductName.TabIndex = 0
        LabelProductName.Text = "GearTrack: Sales and Inventory Management System"
        LabelProductName.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabelVersion
        ' 
        LabelVersion.Dock = DockStyle.Fill
        LabelVersion.Location = New Point(450, 44)
        LabelVersion.Margin = New Padding(8, 0, 4, 0)
        LabelVersion.MaximumSize = New Size(0, 26)
        LabelVersion.Name = "LabelVersion"
        LabelVersion.Size = New Size(521, 26)
        LabelVersion.TabIndex = 0
        LabelVersion.Text = "Version 1.0.0"
        LabelVersion.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabelCopyright
        ' 
        LabelCopyright.Dock = DockStyle.Fill
        LabelCopyright.Location = New Point(450, 88)
        LabelCopyright.Margin = New Padding(8, 0, 4, 0)
        LabelCopyright.MaximumSize = New Size(0, 26)
        LabelCopyright.Name = "LabelCopyright"
        LabelCopyright.Size = New Size(521, 26)
        LabelCopyright.TabIndex = 0
        LabelCopyright.Text = "Copyright © 2025 DDWD2653 S43G2"
        LabelCopyright.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabelCompanyName
        ' 
        LabelCompanyName.Dock = DockStyle.Fill
        LabelCompanyName.Location = New Point(450, 132)
        LabelCompanyName.Margin = New Padding(8, 0, 4, 0)
        LabelCompanyName.MaximumSize = New Size(0, 26)
        LabelCompanyName.Name = "LabelCompanyName"
        LabelCompanyName.Size = New Size(521, 26)
        LabelCompanyName.TabIndex = 0
        LabelCompanyName.Text = "GEARTRACK SDN. BHD."
        LabelCompanyName.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TextBoxDescription
        ' 
        TextBoxDescription.Dock = DockStyle.Fill
        TextBoxDescription.Location = New Point(450, 181)
        TextBoxDescription.Margin = New Padding(8, 5, 4, 5)
        TextBoxDescription.Multiline = True
        TextBoxDescription.Name = "TextBoxDescription"
        TextBoxDescription.ReadOnly = True
        TextBoxDescription.ScrollBars = ScrollBars.Both
        TextBoxDescription.Size = New Size(521, 211)
        TextBoxDescription.TabIndex = 0
        TextBoxDescription.TabStop = False
        TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text")
        ' 
        ' OKButton
        ' 
        OKButton.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        OKButton.DialogResult = DialogResult.Cancel
        OKButton.Location = New Point(871, 404)
        OKButton.Margin = New Padding(4, 5, 4, 5)
        OKButton.Name = "OKButton"
        OKButton.Size = New Size(100, 33)
        OKButton.TabIndex = 0
        OKButton.Text = "&OK"
        ' 
        ' AboutBox
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = OKButton
        ClientSize = New Size(999, 470)
        Controls.Add(TableLayoutPanel)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(4, 5, 4, 5)
        MaximizeBox = False
        MinimizeBox = False
        Name = "AboutBox"
        Padding = New Padding(12, 14, 12, 14)
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "About Us"
        TableLayoutPanel.ResumeLayout(False)
        TableLayoutPanel.PerformLayout()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

End Class
