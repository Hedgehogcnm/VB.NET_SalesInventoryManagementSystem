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
        ConfirmButton = New Button()
        CancelButton = New Button()
        CType(OrderDataGridView, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' OrderDataGridView
        ' 
        OrderDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        OrderDataGridView.Location = New Point(119, 70)
        OrderDataGridView.Name = "OrderDataGridView"
        OrderDataGridView.RowHeadersWidth = 51
        OrderDataGridView.Size = New Size(769, 332)
        OrderDataGridView.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        Label1.Location = New Point(438, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(176, 35)
        Label1.TabIndex = 1
        Label1.Text = "Order History"
        ' 
        ' ConfirmButton
        ' 
        ConfirmButton.Location = New Point(794, 444)
        ConfirmButton.Name = "ConfirmButton"
        ConfirmButton.Size = New Size(94, 29)
        ConfirmButton.TabIndex = 2
        ConfirmButton.Text = "Confirm"
        ConfirmButton.UseVisualStyleBackColor = True
        ' 
        ' CancelButton
        ' 
        CancelButton.Location = New Point(654, 444)
        CancelButton.Name = "CancelButton"
        CancelButton.Size = New Size(94, 29)
        CancelButton.TabIndex = 3
        CancelButton.Text = "Cancel"
        CancelButton.UseVisualStyleBackColor = True
        ' 
        ' ViewOrderForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1062, 503)
        Controls.Add(CancelButton)
        Controls.Add(ConfirmButton)
        Controls.Add(Label1)
        Controls.Add(OrderDataGridView)
        Name = "ViewOrderForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ViewOrder"
        CType(OrderDataGridView, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents OrderDataGridView As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents ConfirmButton As Button
    Friend WithEvents CancelButton As Button
End Class
