Imports LiveCharts
Imports LiveCharts.WinForms
Public Class AdminDashboardForm
    Private Sub AboutUsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutUsToolStripMenuItem.Click
        Dim aboutbox As New AboutBox
        aboutbox.Show()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Dim login As New LoginForm
        login.Show()
        Close()
    End Sub


    Private Sub AdminDashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim chart As New LiveCharts.WinForms.CartesianChart() With {.Dock = DockStyle.Fill}

        Dim months = {"Dec", "Jan", "Feb", "Mar", "Apr", "May", "Jun"}
        Dim expenses As Double() = {28000, 15000, 20000, 32000, 25000, 27000, 30000}
        Dim profits As Double() = {22000, 18000, 23000, 19000, 26000, 31000, 35000}

        chart.Series = New SeriesCollection From {
            New LiveCharts.Wpf.LineSeries With {
                .Title = "Expense",
                .Values = New ChartValues(Of Double)(expenses)
            },
            New LiveCharts.Wpf.LineSeries With {
                .Title = "Profit",
                .Values = New ChartValues(Of Double)(profits)
            }
        }

        chart.AxisX.Add(New LiveCharts.Wpf.Axis With {.Labels = months})
        chart.AxisY.Add(New LiveCharts.Wpf.Axis With {.Title = "RM"})

        AdminTableLayoutPanel.Controls.Add(chart, 1, 1)
        chart.Dock = DockStyle.Fill
    End Sub
End Class