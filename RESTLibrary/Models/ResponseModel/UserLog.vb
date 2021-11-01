Public Class UserLog
    Private _id As Integer
    Private _username As String
    Private _datetime_in As String

    Public Property id As Integer
        Get
            Return _id
        End Get
        Set
            _id = value
        End Set
    End Property

    Public Property username As String
        Get
            Return _username
        End Get
        Set
            _username = value
        End Set
    End Property

    Public Property datetime_in As String
        Get
            Return _datetime_in
        End Get
        Set
            _datetime_in = value
        End Set
    End Property
End Class