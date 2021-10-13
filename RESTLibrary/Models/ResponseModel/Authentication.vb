Public Class Authentication
    Private _expiry As String
    Private _token As String
    Private _user As User

    Public Property expiry As String
        Get
            Return _expiry
        End Get
        Set
            _expiry = value
        End Set
    End Property

    Public Property token As String
        Get
            Return _token
        End Get
        Set
            _token = value
        End Set
    End Property

    Public Property user As User
        Get
            Return _user
        End Get
        Set
            _user = value
        End Set
    End Property
End Class