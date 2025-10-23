<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewOrderForm
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
        Label1 = New Label()
        HeaderFlowLayoutPanel = New FlowLayoutPanel()
        OrderFlowLayoutPanel = New FlowLayoutPanel()
        SaveButton = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        Label1.Location = New Point(562, 18)
        Label1.Name = "Label1"
        Label1.Size = New Size(176, 35)
        Label1.TabIndex = 0
        Label1.Text = "Order History"
        ' 
        ' HeaderFlowLayoutPanel
        ' 
        HeaderFlowLayoutPanel.BackColor = Color.Bisque
        HeaderFlowLayoutPanel.Location = New Point(76, 81)
        HeaderFlowLayoutPanel.Name = "HeaderFlowLayoutPanel"
        HeaderFlowLayoutPanel.Size = New Size(1177, 41)
        HeaderFlowLayoutPanel.TabIndex = 1
        ' 
        ' OrderFlowLayoutPanel
        ' 
        OrderFlowLayoutPanel.Location = New Point(76, 128)
        OrderFlowLayoutPanel.Name = "OrderFlowLayoutPanel"
        OrderFlowLayoutPanel.Size = New Size(1203, 375)
        OrderFlowLayoutPanel.TabIndex = 2
        ' 
        ' SaveButton
        ' 
        SaveButton.Location = New Point(1159, 530)
        SaveButton.Name = "SaveButton"
        SaveButton.Size = New Size(94, 29)
        SaveButton.TabIndex = 3
        SaveButton.Text = "Save"
        SaveButton.UseVisualStyleBackColor = True
        ' 
        ' ViewOrderForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SeaShell
        ClientSize = New Size(1323, 621)
        Controls.Add(SaveButton)
        Controls.Add(OrderFlowLayoutPanel)
        Controls.Add(HeaderFlowLayoutPanel)
        Controls.Add(Label1)
        Name = "ViewOrderForm"
        StartPosition = FormStartPosition.CenterScreen
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents HeaderFlowLayoutPanel As FlowLayoutPanel
    Friend WithEvents OrderFlowLayoutPanel As FlowLayoutPanel
    Friend WithEvents SaveButton As Button
End Class
