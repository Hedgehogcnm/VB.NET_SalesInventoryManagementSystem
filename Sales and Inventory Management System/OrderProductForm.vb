Imports MySql.Data.MySqlClient
Imports System.Drawing

Public Class OrderProductForm
    ' --- Properties to receive data from InventoryForm ---
    Public Property SelectedProductID As Integer
    Public Property SelectedProductName As String

    Private currentUnitPrice As Decimal = 0D
    Private currentSupplierID As Integer = 0

    Private Sub OrderProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' === Background ===
        Me.BackColor = Color.FromArgb(255, 247, 238) ' 柔和米橙色
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = New Font("Segoe UI", 10)
        Me.Text = "Order Product"

        ' === Title ===
        TitleLabel.ForeColor = Color.FromArgb(120, 80, 40)
        TitleLabel.TextAlign = ContentAlignment.MiddleCenter
        TitleLabel.Dock = DockStyle.None
        TitleLabel.AutoSize = False

        ' === Label Style ===
        For Each lbl As Label In {ProductNameText, ProductIDText, QuantityText, UnitPriceText, TotalText}
            lbl.ForeColor = Color.FromArgb(100, 70, 50)
            lbl.TextAlign = ContentAlignment.MiddleRight
        Next

        ' === Value Labels ===
        For Each lbl As Label In {ProductNameDisplay, ProductIDDisplay, UnitPriceDisplay, TotalPriceDisplay}
            lbl.ForeColor = Color.FromArgb(70, 50, 40)
            lbl.BackColor = Color.FromArgb(255, 245, 230)
            lbl.BorderStyle = BorderStyle.FixedSingle
            lbl.AutoSize = False
        Next

        ' === Quantity TextBox ===
        OrderQuantityTextBox.BorderStyle = BorderStyle.FixedSingle
        OrderQuantityTextBox.BackColor = Color.FromArgb(255, 245, 230)
        OrderQuantityTextBox.ForeColor = Color.FromArgb(50, 50, 50)

        ' === Order Button ===
        OrderButton.FlatStyle = FlatStyle.Flat
        OrderButton.FlatAppearance.BorderSize = 0
        OrderButton.BackColor = Color.FromArgb(255, 235, 215)
        OrderButton.ForeColor = Color.FromArgb(120, 80, 40)
        OrderButton.Font = New Font("Segoe UI Semibold", 9)
        OrderButton.Cursor = Cursors.Hand
        AddHandler OrderButton.MouseEnter, Sub() OrderButton.BackColor = Color.FromArgb(255, 225, 200)
        AddHandler OrderButton.MouseLeave, Sub() OrderButton.BackColor = Color.FromArgb(255, 235, 215)

        ' === Cancel Button ===
        CancelButton.FlatStyle = FlatStyle.Flat
        CancelButton.FlatAppearance.BorderSize = 0
        CancelButton.BackColor = Color.FromArgb(255, 235, 215)
        CancelButton.ForeColor = Color.FromArgb(120, 80, 40)
        CancelButton.Font = New Font("Segoe UI Semibold", 9)
        CancelButton.Cursor = Cursors.Hand
        AddHandler CancelButton.MouseEnter, Sub() CancelButton.BackColor = Color.FromArgb(255, 225, 200)
        AddHandler CancelButton.MouseLeave, Sub() CancelButton.BackColor = Color.FromArgb(255, 235, 215)

        ' === Load Data ===
        ProductNameDisplay.Text = SelectedProductName
        ProductIDDisplay.Text = SelectedProductID.ToString()

        If SelectedProductID > 0 Then
            LoadProductDetails(SelectedProductID)
        End If
    End Sub

    ' --- Load supplier ID & unit price ---
    Private Sub LoadProductDetails(productID As Integer)
        Try
            ConnectDB()

            Dim sql As String = "SELECT sup_id, p_costPrice FROM tb_products WHERE p_id = @pid"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@pid", productID)
                Using rdr As MySqlDataReader = cmd.ExecuteReader()
                    If rdr.Read() Then
                        currentSupplierID = Convert.ToInt32(rdr("sup_id"))
                        currentUnitPrice = Convert.ToDecimal(rdr("p_costPrice"))
                        UnitPriceDisplay.Text = "RM " & currentUnitPrice.ToString("N2")
                    Else
                        currentSupplierID = 0
                        currentUnitPrice = 0
                        UnitPriceDisplay.Text = "RM 0.00"
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("❌ Failed to load product details: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' --- Update total price when quantity changes ---
    Private Sub OrderQuantityTextBox_TextChanged(sender As Object, e As EventArgs) Handles OrderQuantityTextBox.TextChanged
        Dim qty As Integer
        If Integer.TryParse(OrderQuantityTextBox.Text, qty) AndAlso qty > 0 Then
            Dim total = qty * currentUnitPrice
            TotalPriceDisplay.Text = "RM " & total.ToString("N2")
        Else
            TotalPriceDisplay.Text = "RM 0.00"
        End If
    End Sub

    ' --- Place order ---
    Private Sub OrderButton_Click(sender As Object, e As EventArgs) Handles OrderButton.Click
        Dim quantity As Integer
        If Not Integer.TryParse(OrderQuantityTextBox.Text, quantity) OrElse quantity <= 0 Then
            MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim total As Decimal = quantity * currentUnitPrice
        Dim status As String = "ordered"
        Dim userID As Integer = 1 ' replace with logged-in user later

        Try
            ConnectDB()
            Dim sql As String = "INSERT INTO tb_orders (p_id, u_id, sup_id, o_qty, o_total, o_status)
                                 VALUES (@pid, @uid, @sid, @qty, @total, @status)"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@pid", SelectedProductID)
                cmd.Parameters.AddWithValue("@uid", userID)
                cmd.Parameters.AddWithValue("@sid", currentSupplierID)
                cmd.Parameters.AddWithValue("@qty", quantity)
                cmd.Parameters.AddWithValue("@total", total)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("✅ Order placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("❌ Failed to place order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.Close()
    End Sub
End Class
