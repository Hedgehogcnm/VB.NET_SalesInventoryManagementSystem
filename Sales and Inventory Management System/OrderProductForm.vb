Imports MySql.Data.MySqlClient

Public Class OrderProductForm

    ' --- Properties to receive data from InventoryForm ---
    Public Property SelectedProductID As Integer
    Public Property SelectedProductName As String

    Private currentUnitPrice As Decimal = 0D
    Private currentSupplierID As Integer = 0

    Private Sub OrderProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Show product name immediately
        ProductNameLabel.Text = SelectedProductName
        ProductIDLabel.Text = SelectedProductID.ToString()

        ' Load product details like supplier & cost
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
                        UnitPriceLabel.Text = "RM " & currentUnitPrice.ToString("N2")
                    Else
                        currentSupplierID = 0
                        currentUnitPrice = 0
                        UnitPriceLabel.Text = "RM 0.00"
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
            TotalPriceLabel.Text = "RM " & total.ToString("N2")
        Else
            TotalPriceLabel.Text = "RM 0.00"
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
