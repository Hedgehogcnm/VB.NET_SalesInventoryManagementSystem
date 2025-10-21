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

        ' Define the widths for each column (Adjust widths as necessary)
        Dim columnWidths As Integer() = {100, 100, 200, 100, 100, 100, 150, 100}

        Dim headers As String() = {
            "Order ID", "Product ID", "Product Name",
            "User ID", "Supplier ID", "Quantity",
            "Total(RM)", "Status"
        }

        Dim x As Integer = 10
        For i As Integer = 0 To headers.Length - 1
            Dim lbl As New Label With {
                .Text = headers(i),
                .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                .AutoSize = False,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Width = columnWidths(i),
                .Location = New Point(x, 8)
            }
            HeaderFlowLayoutPanel.Controls.Add(lbl)
            x += columnWidths(i) ' Adjust based on column widths
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

            ' Define the same column widths for content as headers
            Dim columnWidths As Integer() = {100, 100, 200, 100, 100, 100, 150, 100}

            ' Loop through each order and display it in a row
            For Each row As DataRow In dt.Rows
                Dim rowPanel As New Panel With {
                    .Width = OrderFlowLayoutPanel.Width - 25,
                    .Height = 100, ' Increased height to accommodate the content properly
                    .BackColor = Color.White,
                    .Margin = New Padding(2)
                }

                ' Dynamic position for each content item
                Dim xPos As Integer = 10

                ' Order ID
                Dim orderID As Label = New Label With {
                    .Text = row("o_id").ToString(),
                    .Width = columnWidths(0),
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Location = New Point(xPos, 25)
                }
                rowPanel.Controls.Add(orderID)
                xPos += columnWidths(0) ' Move to the next column

                ' Product ID
                Dim productID As Label = New Label With {
                    .Text = row("p_id").ToString(),
                    .Width = columnWidths(1),
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Location = New Point(xPos, 25)
                }
                rowPanel.Controls.Add(productID)
                xPos += columnWidths(1)

                ' Product Name
                Dim productName As Label = New Label With {
                    .Text = row("p_name").ToString(),
                    .Width = columnWidths(2),
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Location = New Point(xPos, 25)
                }
                rowPanel.Controls.Add(productName)
                xPos += columnWidths(2)

                ' User ID
                Dim userID As Label = New Label With {
                    .Text = row("u_id").ToString(),
                    .Width = columnWidths(3),
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Location = New Point(xPos, 25)
                }
                rowPanel.Controls.Add(userID)
                xPos += columnWidths(3)

                ' Supplier ID
                Dim supplierID As Label = New Label With {
                    .Text = row("sup_id").ToString(),
                    .Width = columnWidths(4),
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Location = New Point(xPos, 25)
                }
                rowPanel.Controls.Add(supplierID)
                xPos += columnWidths(4)

                ' Quantity
                Dim quantity As Label = New Label With {
                    .Text = row("o_qty").ToString(),
                    .Width = columnWidths(5),
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Location = New Point(xPos, 25)
                }
                rowPanel.Controls.Add(quantity)
                xPos += columnWidths(5)

                ' Total (RM)
                Dim total As Label = New Label With {
                    .Text = FormatCurrency(row("o_total"), 2),
                    .Width = columnWidths(6),
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Location = New Point(xPos, 25)
                }
                rowPanel.Controls.Add(total)
                xPos += columnWidths(6)

                ' Status (ComboBox)
                Dim status As New ComboBox With {
                    .Width = columnWidths(7) - 50,  ' Adjust width to ensure enough space
                    .Height = 30,                   ' Set the height to fit the options properly
                    .Location = New Point(xPos, 25),
                    .DropDownStyle = ComboBoxStyle.DropDownList
                }

                ' Add items to the ComboBox
                status.Items.AddRange(New String() {"ordered", "received", "cancelled"})

                ' Set the selected item based on the current status
                status.SelectedItem = row("o_status").ToString()

                ' Add event handler to update status on change
                AddHandler status.SelectedIndexChanged, Sub(sender, e)
                                                            ' Logic to update status can go here
                                                        End Sub

                ' Add the ComboBox to the panel
                rowPanel.Controls.Add(status)
                xPos += columnWidths(7) - 50 ' Move xPos to the right for the confirm button

                ' Add a gap before the Confirm button
                xPos += 10  ' This will add a 10px gap between the ComboBox and the button


                ' Confirm Button next to the ComboBox
                Dim confirmButton As New Button With {
                    .Text = "Confirm",
                    .Width = 75,
                    .Location = New Point(xPos, 25),
                    .BackColor = Color.LightSkyBlue,
                    .FlatStyle = FlatStyle.Flat
                }

                ' Add event handler for the Confirm button
                AddHandler confirmButton.Click, Sub(sender, e)
                                                    Dim selectedStatus As String = status.SelectedItem.ToString()

                                                    ' Show confirmation message box
                                                    Dim confirmResult As DialogResult = MessageBox.Show(
                                                        $"Are you sure you want to change the status to '{selectedStatus}'?",
                                                        "Confirm Status Change",
                                                        MessageBoxButtons.OKCancel,
                                                        MessageBoxIcon.Question
                                                    )

                                                    ' If user clicks OK
                                                    If confirmResult = DialogResult.OK Then
                                                        ' Update the order status in the database
                                                        UpdateOrderStatus(row("o_id").ToString(), selectedStatus)

                                                        ' Show success message
                                                        MessageBox.Show("Status changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                    End If
                                                End Sub

                ' Add the Confirm Button to the row panel
                rowPanel.Controls.Add(confirmButton)

                ' Add the row panel to the FlowLayoutPanel
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
End Class
