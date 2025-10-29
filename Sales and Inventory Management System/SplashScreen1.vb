Imports System.Windows.Forms
Imports System.Drawing

Public Class SplashScreen1
    Inherits Form

    Private TitleLabel As Label
    Private SubtitleLabel As Label
    Private ProgressBar1 As ProgressBar
    Private Timer1 As Timer
    Private LogoPictureBox As PictureBox
    Private progressValue As Integer = 0

    Public Sub New()
        'Basic Form Settings
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(255, 247, 238)
        Me.Size = New Size(600, 350)
        Me.TopMost = True

        'Rounded Corners
        Me.Region = New Region(New Drawing2D.GraphicsPath())
        Dim path As New Drawing2D.GraphicsPath()
        path.AddArc(0, 0, 20, 20, 180, 90)
        path.AddArc(Me.Width - 20, 0, 20, 20, 270, 90)
        path.AddArc(Me.Width - 20, Me.Height - 20, 20, 20, 0, 90)
        path.AddArc(0, Me.Height - 20, 20, 20, 90, 90)
        path.CloseAllFigures()
        Me.Region = New Region(path)

        'Logo
        LogoPictureBox = New PictureBox With {
            .Size = New Size(120, 120),
            .Location = New Point((Me.ClientSize.Width - 90) \ 2, 50),
            .SizeMode = PictureBoxSizeMode.Zoom,
            .BackColor = Color.Transparent
        }
        Try
            LogoPictureBox.Image = My.Resources.logo__500_
        Catch
            LogoPictureBox.BackColor = Color.FromArgb(255, 230, 210)
        End Try
        Me.Controls.Add(LogoPictureBox)

        'Title
        TitleLabel = New Label With {
            .Text = "Sales and Inventory Management System",
            .Font = New Font("Segoe UI Semibold", 14, FontStyle.Bold),
            .ForeColor = Color.FromArgb(120, 80, 40),
            .AutoSize = False,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Dock = DockStyle.None,
            .Size = New Size(Me.ClientSize.Width, 50),
            .Location = New Point(0, 160)
        }
        Me.Controls.Add(TitleLabel)

        'Subtitle
        SubtitleLabel = New Label With {
            .Text = "Loading, please wait...",
            .Font = New Font("Segoe UI", 10, FontStyle.Regular),
            .ForeColor = Color.FromArgb(130, 100, 70),
            .AutoSize = False,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Dock = DockStyle.None,
            .Size = New Size(Me.ClientSize.Width, 30),
            .Location = New Point(0, 200)
        }
        Me.Controls.Add(SubtitleLabel)

        'ProgressBar
        ProgressBar1 = New ProgressBar With {
            .Location = New Point(100, 260),
            .Size = New Size(400, 12),
            .Style = ProgressBarStyle.Continuous,
            .ForeColor = Color.FromArgb(120, 80, 40)
        }
        ProgressBar1.BackColor = Color.FromArgb(255, 230, 210)
        Me.Controls.Add(ProgressBar1)

        'Timer to Control Loading Animation
        Timer1 = New Timer()
        Timer1.Interval = 40 ' Speed (milliseconds)
        AddHandler Timer1.Tick, AddressOf Timer1_Tick
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        progressValue += 2
        If progressValue <= 100 Then
            ProgressBar1.Value = progressValue
        Else
            Timer1.Stop()
            Me.Hide()
            Dim mainForm As New LoginForm()
            mainForm.Show()
        End If
    End Sub
End Class