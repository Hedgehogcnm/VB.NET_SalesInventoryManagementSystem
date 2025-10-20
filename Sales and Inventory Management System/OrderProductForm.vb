Imports MySql.Data.MySqlClient

Public Class OrderProductForm

    Private Sub OrderProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProductNames() ' Load product names when form starts
    End Sub

    ' --- Load product names into ComboBox ---
    Private Sub LoadProductNames()
        Try
            ConnectDB()

            ' Get both p_id and p_name so we can later retrieve ID
            Dim sql As String = "SELECT p_id, p_name FROM tb_products ORDER BY p_name ASC"
            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            da.Fill(dt)

            ProductNameComboBox.DataSource = dt
            ProductNameComboBox.DisplayMember = "p_name" ' What the user sees
            ProductNameComboBox.ValueMember = "p_id"     ' The actual ID value
            ProductNameComboBox.SelectedIndex = -1       ' No selection at start

        Catch ex As Exception
            MessageBox.Show("❌ Failed to load product names: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' --- When user selects a product, show its Product ID ---
    Private Sub ProductNameComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProductNameComboBox.SelectedIndexChanged
        Try
            If ProductNameComboBox.SelectedIndex <> -1 Then
                ' Show the corresponding Product ID
                Dim selectedID As String = ProductNameComboBox.SelectedValue.ToString()
                ProductIDLabel.Text = selectedID
            Else
                ProductIDLabel.Text = "" ' Clear label if nothing selected
            End If
        Catch ex As Exception
            ' In case SelectedValue is temporarily null when resetting DataSource
            ProductIDLabel.Text = ""
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
        Me.Show() ' Return here after closing ViewOrderForm
    End Sub

    Private Sub OrderButton_Click(sender As Object, e As EventArgs) Handles OrderButton.Click

    End Sub
End Class
