Public Class CustomerActivationCode
    Private _username As String
    Private _code As String

    Public Sub New(username As String, code As String)
        _username = username
        _code = code
    End Sub

    Public Property username As String
        Get
            Return _username
        End Get
        Set
            _username = value
        End Set
    End Property

    Public Property code As String
        Get
            Return _code
        End Get
        Set
            _code = value
        End Set
    End Property
End Class