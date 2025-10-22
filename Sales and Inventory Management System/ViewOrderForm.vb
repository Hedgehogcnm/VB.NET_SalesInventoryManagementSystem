Imports MySql.Data.MySqlClient
Imports System.IO

Public Class ViewOrderForm
    ' === SETUP ORDER HEADER ===
    Private Sub ViewOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupOrderHeader()
        LoadOrderData()

        ' Set AutoScroll to True for scrolling functionality
        OrderFlowLayoutPanel.AutoScroll = True
    End Sub

    Private Sub SetupOrderHeader()
        HeaderFlowLayoutPanel.Controls.Clear()

        ' Match the padding of OrderFlowLayoutPanel
        HeaderFlowLayoutPanel.Padding = New Padding(5)
        HeaderFlowLayoutPanel.Margin = New Padding(0)

        ' Define column widths (same as in LoadOrderData)
        Dim columnWidths As Integer() = {100, 100, 200, 70, 120, 70, 170, 50, 70}

        Dim headers As String() = {
        "Order ID", "Product ID", "Product Name",
        "User ID", "Supplier ID", "Quantity",
        "Total(RM)", "Status", "Action"
    }

        ' Start at same X position as rowPanel
        Dim xPos As Integer = 10

        For i As Integer = 0 To headers.Length - 1
            Dim lbl As New Label With {
            .Text = headers(i),
            .Font = New Font("Segoe UI", 9, FontStyle.Bold),
            .AutoSize = False,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Width = columnWidths(i),
            .Location = New Point(xPos, 10) ' Align Y with rowPanel content
        }
            HeaderFlowLayoutPanel.Controls.Add(lbl)
            xPos += columnWidths(i)
        Next
    End Sub


    ' === LOAD ORDER DATA ===
    Private Sub LoadOrderData()
        Try
            ConnectDB()

            ' SQL query to get order details with product names
            Dim sql As String = "
                SELECT o.o_id, o.p_id, p.p_name, o.u_id, o.sup_id, o.o_qty, o.o_total, o.o_status
                FROM tb_orders o
                JOIN tb_products p ON o.p_id = p.p_id"

            Dim cmd As New MySqlCommand(sql, conn)
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            conn.Close()

            ' Clear previous order data
            OrderFlowLayoutPanel.Controls.Clear()

            ' If no data found
            If dt.Rows.Count = 0 Then
                Dim noDataLbl As New Label With {
                    .Text = "No orders found.",
                    .Font = New Font("Segoe UI", 11, FontStyle.Italic),
                    .ForeColor = Color.Gray,
                    .AutoSize = True,
                    .Margin = New Padding(20)
                }
                OrderFlowLayoutPanel.Controls.Add(noDataLbl)
                Exit Sub
            End If



            ' Loop through each order and display it in a row
            ' --- Loop through each order and create a row ---
            For Each row As DataRow In dt.Rows
                Dim rowPanel As New Panel With {
    .Width = OrderFlowLayoutPanel.Width - 25,
    .Height = 50,
    .BackColor = Color.White,
    .Margin = New Padding(2),
    .Padding = New Padding(5) ' Match header padding
}
                Dim xPos As Integer = 10 ' Same as header starting X


                ' --- Define column widths (including Confirm column) ---
                Dim columnWidths As Integer() = {100, 100, 200, 100, 100, 100, 150, 80, 80}

                ' --- Add labels for order data ---
                Dim values As String() = {
                    row("o_id").ToString(),
                    row("p_id").ToString(),
                    row("p_name").ToString(),
                    row("u_id").ToString(),
                    row("sup_id").ToString(),
                    row("o_qty").ToString(),
                    FormatCurrency(row("o_total"), 2)
                }

                For i As Integer = 0 To values.Length - 1
                    Dim lbl As New Label With {
                        .Text = values(i),
                        .Width = columnWidths(i),
                        .Height = 30,
                        .TextAlign = ContentAlignment.MiddleCenter,
                        .Location = New Point(xPos, 10)
                    }
                    rowPanel.Controls.Add(lbl)
                    xPos += columnWidths(i)
                Next

                ' --- Status ComboBox ---
                Dim status As New ComboBox With {
                    .Width = columnWidths(7),
                    .Height = 30,
                    .Location = New Point(xPos, 10),
                    .DropDownStyle = ComboBoxStyle.DropDownList
                }
                status.Items.AddRange(New String() {"ordered", "received", "cancelled"})
                status.SelectedItem = row("o_status").ToString()
                rowPanel.Controls.Add(status)
                xPos += columnWidths(7)

                ' --- Confirm Button in dedicated column ---
                Dim confirmButton As New Button With {
                    .Text = "Confirm",
                    .Width = columnWidths(8),
                    .Height = 30,
                    .Location = New Point(xPos, 10),
                    .BackColor = Color.LightSkyBlue,
                    .FlatStyle = FlatStyle.Flat
                }

                ' Event handler to update status
                AddHandler confirmButton.Click, Sub(sender, e)
                                                    Dim selectedStatus As String = status.SelectedItem.ToString()
                                                    Dim productName As String = row("p_name").ToString()
                                                    Dim productID As String = row("p_id").ToString()

                                                    Dim confirmResult As DialogResult = MessageBox.Show(
                                                        $"Confirm change order status for '{productName}' (Product ID: {productID}) to '{selectedStatus}'?",
                                                        "Confirm Status Change",
                                                        MessageBoxButtons.OKCancel,
                                                        MessageBoxIcon.Question
                                                    )

                                                    If confirmResult = DialogResult.OK Then
                                                        UpdateOrderStatus(row("o_id").ToString(), selectedStatus)
                                                        MessageBox.Show("Status changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                                        ' --- Refresh InventoryForm Product List ---
                                                        For Each frm As Form In Application.OpenForms
                                                            If TypeOf frm Is InventoryForm Then
                                                                DirectCast(frm, InventoryForm).RefreshProductListFromOtherForm()
                                                                Exit For
                                                            End If
                                                        Next
                                                    End If
                                                End Sub



                rowPanel.Controls.Add(confirmButton)

                ' --- Add the row to FlowLayoutPanel ---
                OrderFlowLayoutPanel.Controls.Add(rowPanel)
            Next


        Catch ex As Exception
            MessageBox.Show("❌ Error loading orders: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' === UPDATE ORDER STATUS ===
    Private Sub UpdateOrderStatus(orderID As String, newStatus As String)
        Try
            ConnectDB()

            ' SQL query to update the order status
            Dim sql As String = "UPDATE tb_orders SET o_status = @newStatus WHERE o_id = @orderID"
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@newStatus", newStatus)
            cmd.Parameters.AddWithValue("@orderID", orderID)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("❌ Error updating order status: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.Close()
    End Sub

End Class
