Public Class CustomerActivationCredential
    Private _username As String
    Private _phone_num As String

    Public Property username As String
        Get
            Return _username
        End Get
        Set
            _username = value
        End Set
    End Property

    Public Property phone_num As String
        Get
            Return _phone_num
        End Get
        Set
            _phone_num = value
        End Set
    End Property

    Public Sub New(username As String, phoneNum As String)
        _username = username
        _phone_num = phoneNum
    End Sub
End Class