Public Class NoHighlightColorTable
    Inherits ProfessionalColorTable
    Public Overrides ReadOnly Property MenuItemSelected As Color
        Get
            Return Color.FromArgb(255, 235, 200) ' Light peach hover color
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemSelectedGradientBegin As Color
        Get
            Return Color.FromArgb(255, 235, 200) ' Light peach hover color
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemSelectedGradientEnd As Color
        Get
            Return Color.FromArgb(255, 235, 200) ' Light peach hover color
        End Get
    End Property
End Class
