Imports MySql.Data.MySqlClient
Imports System.Drawing

Public Class ViewOrderForm
    Private Sub ViewOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Enable scrolling for OrderFlowLayoutPanel
        OrderFlowLayoutPanel.AutoScroll = True
        OrderFlowLayoutPanel.WrapContents = False
        OrderFlowLayoutPanel.FlowDirection = FlowDirection.TopDown

        CreateHeaderRow()
        LoadOrders()
    End Sub

    ' --- Create header row (table-like) ---
    Private Sub CreateHeaderRow()
        OrderFlowLayoutPanel.Controls.Clear()

        Dim headerPanel As New Panel()
        headerPanel.Width = 900
        headerPanel.Height = 35
        headerPanel.BackColor = Color.FromArgb(230, 230, 230)
        headerPanel.Padding = New Padding(5, 8, 5, 5)

        Dim headers As String() = {"Order ID", "User ID", "Product ID", "Product Name", "Supplier ID", "Order Quantity", "Total (RM)", "Status"}
        Dim widths As Integer() = {80, 80, 90, 180, 100, 120, 100, 130}

        Dim x As Integer = 10
        For i As Integer = 0 To headers.Length - 1
            Dim lbl As New Label()
            lbl.Text = headers(i)
            lbl.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
            lbl.AutoSize = False
            lbl.TextAlign = ContentAlignment.MiddleLeft
            lbl.Width = widths(i)
            lbl.Location = New Point(x, 5)
            headerPanel.Controls.Add(lbl)
            x += widths(i)
        Next

        OrderFlowLayoutPanel.Controls.Add(headerPanel)
    End Sub

    ' --- Load all orders ---
    Private Sub LoadOrders()
        Try
            ConnectDB()

            Dim sql As String =
                "SELECT o.o_id, o.p_id, o.u_id, o.sup_id, o.o_qty, o.o_total, o.o_status, 
                        p.p_name, s.sup_name
                 FROM tb_orders o
                 LEFT JOIN tb_products p ON o.p_id = p.p_id
                 LEFT JOIN tb_suppliers s ON o.sup_id = s.sup_id;"

            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            da.Fill(dt)

            For Each row As DataRow In dt.Rows
                Dim rowPanel As Panel = CreateOrderRow(row)
                OrderFlowLayoutPanel.Controls.Add(rowPanel)
            Next

        Catch ex As Exception
            MessageBox.Show("❌ Failed to load orders: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' --- Create 1 horizontal row for each order ---
    Private Function CreateOrderRow(row As DataRow) As Panel
        Dim rowPanel As New Panel()
        rowPanel.Width = 900
        rowPanel.Height = 40
        rowPanel.BackColor = Color.White
        rowPanel.BorderStyle = BorderStyle.FixedSingle
        rowPanel.Padding = New Padding(5)

        Dim values As String() = {
            row("o_id").ToString(),
            row("u_id").ToString(),
            row("p_id").ToString(),
            If(IsDBNull(row("p_name")), "-", row("p_name").ToString()),
            row("sup_id").ToString(),
            row("o_qty").ToString(),
            row("o_total").ToString()
        }

        Dim widths As Integer() = {80, 80, 90, 180, 100, 120, 100}
        Dim x As Integer = 10

        ' --- Add value labels ---
        For i As Integer = 0 To values.Length - 1
            Dim lbl As New Label()
            lbl.Text = values(i)
            lbl.Font = New Font("Segoe UI", 9)
            lbl.AutoSize = False
            lbl.TextAlign = ContentAlignment.MiddleLeft
            lbl.Width = widths(i)
            lbl.Height = 25
            lbl.Location = New Point(x, 8)
            rowPanel.Controls.Add(lbl)
            x += widths(i)
        Next

        ' --- Status ComboBox ---
        Dim cmbStatus As New ComboBox()
        cmbStatus.Items.AddRange(New Object() {"ordered", "received", "cancelled"})
        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStatus.Font = New Font("Segoe UI", 9)
        cmbStatus.Width = 100
        cmbStatus.Location = New Point(x, 7)
        cmbStatus.Tag = row("o_id")
        cmbStatus.SelectedItem = If(IsDBNull(row("o_status")), "ordered", row("o_status").ToString())
        rowPanel.Controls.Add(cmbStatus)
        x += 110

        ' --- Confirm Button ---
        Dim btnConfirm As New Button()
        btnConfirm.Text = "Confirm"
        btnConfirm.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        btnConfirm.BackColor = Color.FromArgb(0, 123, 255)
        btnConfirm.ForeColor = Color.White
        btnConfirm.FlatStyle = FlatStyle.Flat
        btnConfirm.FlatAppearance.BorderSize = 0
        btnConfirm.Size = New Size(80, 25)
        btnConfirm.Location = New Point(x, 7)
        AddHandler btnConfirm.Click, Sub(sender, e) UpdateOrderStatus(cmbStatus)
        rowPanel.Controls.Add(btnConfirm)

        Return rowPanel
    End Function

    ' --- Update order status ---
    Private Sub UpdateOrderStatus(cmb As ComboBox)
        Dim orderID As Integer = CInt(cmb.Tag)
        Dim newStatus As String = cmb.SelectedItem.ToString()

        Try
            ConnectDB()
            Dim sql As String = "UPDATE tb_orders SET o_status = @status WHERE o_id = @id"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@status", newStatus)
                cmd.Parameters.AddWithValue("@id", orderID)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show($"✅ Order #{orderID} status updated to '{newStatus}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Refresh inventory if open
            For Each f As Form In Application.OpenForms
                If TypeOf f Is InventoryForm Then
                    Dim invForm As InventoryForm = CType(f, InventoryForm)
                    invForm.RefreshProductListFromOtherForm()
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("❌ Failed to update status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' --- Close form ---
    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.Close()
    End Sub
End Class
