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
        OrderDataGridView = New DataGridView()
        Label1 = New Label()
        CType(OrderDataGridView, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' OrderDataGridView
        ' 
        OrderDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        OrderDataGridView.Location = New Point(144, 71)
        OrderDataGridView.Name = "OrderDataGridView"
        OrderDataGridView.RowHeadersWidth = 51
        OrderDataGridView.Size = New Size(738, 332)
        OrderDataGridView.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        Label1.Location = New Point(438, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(131, 35)
        Label1.TabIndex = 1
        Label1.Text = "Order List"
        ' 
        ' ViewOrderForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1065, 450)
        Controls.Add(Label1)
        Controls.Add(OrderDataGridView)
        Name = "ViewOrderForm"
        Text = "ViewOrder"
        CType(OrderDataGridView, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents OrderDataGridView As DataGridView
    Friend WithEvents Label1 As Label
End Class
