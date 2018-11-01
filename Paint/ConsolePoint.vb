Public Class ConsolePoint

    Private xCord As Integer
    Public Property X() As Integer
        Get
            Return xCord
        End Get
        Set(ByVal value As Integer)
            xCord = value
        End Set
    End Property

    Private yCord As Integer
    Public Property Y() As Integer
        Get
            Return yCord
        End Get
        Set(ByVal value As Integer)
            yCord = value
        End Set
    End Property

    Sub New(ByVal X As Integer, Y As Integer)
        Me.X = X
        Me.Y = Y
    End Sub
End Class
