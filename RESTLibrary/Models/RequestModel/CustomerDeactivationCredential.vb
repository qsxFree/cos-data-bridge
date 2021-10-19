Public Class CustomerDeactivationCredential
    Private _username As String

    Public Property username As String
        Get
            Return _username
        End Get
        Set
            _username = value
        End Set
    End Property

    Public Sub New(username As String)
        _username = username
    End Sub
End Class