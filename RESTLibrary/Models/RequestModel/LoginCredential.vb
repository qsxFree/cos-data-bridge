Public Class LoginCredential
    Private _username As String
    Private _password As String

    Public Property password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property


    Public Property username() As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property

    Public Sub New(username As String, password As String)
        Me._username = username
        Me._password = password
    End Sub

End Class
