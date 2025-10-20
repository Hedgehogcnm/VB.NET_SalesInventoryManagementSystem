Imports MySql.Data.MySqlClient

Public Class OrderProductForm

    Private currentUnitPrice As Decimal = 0D
    Private currentSupplierID As Integer = 0

    Private Sub OrderProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProductNames()
    End Sub

    ' --- Load product names into ComboBox ---
    Private Sub LoadProductNames()
        Try
            ConnectDB()

            Dim sql As String = "SELECT p_id, p_name FROM tb_products ORDER BY p_name ASC"
            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            da.Fill(dt)

            ProductNameComboBox.DataSource = dt
            ProductNameComboBox.DisplayMember = "p_name"
            ProductNameComboBox.ValueMember = "p_id"
            ProductNameComboBox.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("❌ Failed to load product names: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' --- When a product is selected ---
    Private Sub ProductNameComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProductNameComboBox.SelectedIndexChanged
        Try
            If ProductNameComboBox.SelectedIndex <> -1 Then
                Dim selectedID As Integer = Convert.ToInt32(ProductNameComboBox.SelectedValue)
                ProductIDLabel.Text = selectedID.ToString()

                ' 🔍 Get supplier ID and unit price
                LoadProductDetails(selectedID)
            Else
                ProductIDLabel.Text = ""
                UnitPriceLabel.Text = "RM 0.00"
                TotalPriceLabel.Text = "RM 0.00"
                currentUnitPrice = 0
                currentSupplierID = 0
            End If
        Catch
            ' ignore when datasource changes
        End Try
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

            ' Update total price immediately if quantity already entered
            UpdateTotalPrice()

        Catch ex As Exception
            MessageBox.Show("❌ Failed to load product details: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' --- Recalculate total when quantity changes ---
    Private Sub OrderQuantityTextBox_TextChanged(sender As Object, e As EventArgs) Handles OrderQuantityTextBox.TextChanged
        UpdateTotalPrice()
    End Sub

    Private Sub UpdateTotalPrice()
        Dim qty As Integer
        If Integer.TryParse(OrderQuantityTextBox.Text, qty) AndAlso qty > 0 Then
            Dim total = qty * currentUnitPrice
            TotalPriceLabel.Text = "RM " & total.ToString("N2")
        Else
            TotalPriceLabel.Text = "RM 0.00"
        End If
    End Sub

    ' --- ORDER BUTTON CLICK ---
    Private Sub OrderButton_Click(sender As Object, e As EventArgs) Handles OrderButton.Click
        ' ✅ Validate product selection
        If ProductNameComboBox.SelectedIndex = -1 Then
            MessageBox.Show("Please select a product before ordering.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' ✅ Validate quantity
        Dim quantity As Integer
        If Not Integer.TryParse(OrderQuantityTextBox.Text, quantity) OrElse quantity <= 0 Then
            MessageBox.Show("Please enter a valid product quantity (greater than 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim productID As Integer = Convert.ToInt32(ProductNameComboBox.SelectedValue)
        Dim userID As Integer = 1 ' 🔧 example fixed user ID
        Dim total As Decimal = quantity * currentUnitPrice
        Dim status As String = "ordered"

        Try
            ConnectDB()

            Dim insertQuery As String = "INSERT INTO tb_orders (p_id, u_id, sup_id, o_qty, o_total, o_status)
                                         VALUES (@pid, @uid, @sid, @qty, @total, @status)"
            Using cmd As New MySqlCommand(insertQuery, conn)
                cmd.Parameters.AddWithValue("@pid", productID)
                cmd.Parameters.AddWithValue("@uid", userID)
                cmd.Parameters.AddWithValue("@sid", currentSupplierID)
                cmd.Parameters.AddWithValue("@qty", quantity)
                cmd.Parameters.AddWithValue("@total", total)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("✅ Order placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear fields
            ProductNameComboBox.SelectedIndex = -1
            OrderQuantityTextBox.Clear()
            ProductIDLabel.Text = ""
            UnitPriceLabel.Text = "RM 0.00"
            TotalPriceLabel.Text = "RM 0.00"

        Catch ex As Exception
            MessageBox.Show("❌ Failed to place order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.Close()
        InventoryForm.Show()
    End Sub

    Private Sub ViewOrderButton_Click(sender As Object, e As EventArgs) Handles ViewOrderButton.Click
        Me.Hide()
        Dim viewForm As New ViewOrderForm()
        viewForm.ShowDialog()
        Me.Show()
    End Sub

End Class
