Imports MySql.Data.MySqlClient
Imports System.IO

Public Class ViewOrderForm

    ' === Holds edited statuses before saving ===
    Private orderStatusChanges As New Dictionary(Of Integer, String)

    ' === FORM LOAD ===
    Private Sub ViewOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupOrderHeader()
        LoadOrderData()
        OrderFlowLayoutPanel.AutoScroll = True
    End Sub

    ' === SETUP HEADER ===
    Private Sub SetupOrderHeader()
        HeaderFlowLayoutPanel.Controls.Clear()
        HeaderFlowLayoutPanel.Padding = New Padding(5)
        HeaderFlowLayoutPanel.Margin = New Padding(0)

        ' Updated column widths (removed Action column)
        Dim columnWidths As Integer() = {100, 100, 190, 90, 100, 90, 150, 90}
        Dim headers As String() = {
            "Order ID", "Product ID", "Product Name",
            "User ID", "Supplier ID", "Quantity",
            "Total (RM)", "Status"
        }

        Dim xPos As Integer = 10
        For i As Integer = 0 To headers.Length - 1
            Dim lbl As New Label With {
                .Text = headers(i),
                .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                .AutoSize = False,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Width = columnWidths(i),
                .Location = New Point(xPos, 10)
            }
            HeaderFlowLayoutPanel.Controls.Add(lbl)
            xPos += columnWidths(i)
        Next
    End Sub

    ' === LOAD ORDER DATA ===
    Private Sub LoadOrderData()
        Try
            ConnectDB()

            Dim sql As String = "
                SELECT o.o_id, o.p_id, p.p_name, o.u_id, o.sup_id, o.o_qty, o.o_total, o.o_status
                FROM tb_orders o
                JOIN tb_products p ON o.p_id = p.p_id"

            Dim cmd As New MySqlCommand(sql, conn)
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            conn.Close()

            OrderFlowLayoutPanel.Controls.Clear()
            orderStatusChanges.Clear()

            ' No data case
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

            ' Build rows
            For Each row As DataRow In dt.Rows
                Dim rowPanel As New Panel With {
                    .Width = OrderFlowLayoutPanel.Width - 25,
                    .Height = 50,
                    .BackColor = Color.White,
                    .Margin = New Padding(2),
                    .Padding = New Padding(5)
                }

                Dim xPos As Integer = 10
                Dim columnWidths As Integer() = {100, 100, 200, 100, 100, 100, 150, 100}

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

                Dim orderID As Integer = Convert.ToInt32(row("o_id"))

                ' Track changes
                AddHandler status.SelectedIndexChanged, Sub()
                                                            orderStatusChanges(orderID) = status.SelectedItem.ToString()
                                                        End Sub

                rowPanel.Controls.Add(status)
                OrderFlowLayoutPanel.Controls.Add(rowPanel)
            Next

        Catch ex As Exception
            MessageBox.Show("❌ Error loading orders: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' === SAVE BUTTON CLICK ===
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        If orderStatusChanges.Count = 0 Then
            MessageBox.Show("No changes detected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Try
            ConnectDB()
            Dim transaction As MySqlTransaction = conn.BeginTransaction()

            Try
                For Each pair In orderStatusChanges
                    Dim sql As String = "UPDATE tb_orders SET o_status = @status WHERE o_id = @id"
                    Dim cmd As New MySqlCommand(sql, conn, transaction)
                    cmd.Parameters.AddWithValue("@status", pair.Value)
                    cmd.Parameters.AddWithValue("@id", pair.Key)
                    cmd.ExecuteNonQuery()
                Next

                transaction.Commit()
                MessageBox.Show("✅ Order statuses updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                orderStatusChanges.Clear()
                LoadOrderData()

                ' Refresh InventoryForm if open
                For Each frm As Form In Application.OpenForms
                    If TypeOf frm Is InventoryForm Then
                        DirectCast(frm, InventoryForm).RefreshProductListFromOtherForm()
                        Exit For
                    End If
                Next

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("❌ Failed to update order statuses: " & ex.Message)
            End Try

        Catch ex As Exception
            MessageBox.Show("❌ Connection error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

End Class
