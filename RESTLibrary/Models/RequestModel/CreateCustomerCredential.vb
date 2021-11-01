Public Class CreateCustomerCredential
    Private _username As String
    Private _first_name As String
    Private _last_name As String
    Private _rfid_key As String

    Public Property username As String
        Get
            Return _username
        End Get
        Set
            _username = value
        End Set
    End Property

    Public Property first_name As String
        Get
            Return _first_name
        End Get
        Set
            _first_name = value
        End Set
    End Property

    Public Property last_name As String
        Get
            Return _last_name
        End Get
        Set
            _last_name = value
        End Set
    End Property

    Public Property rfid_key As String
        Get
            Return _rfid_key
        End Get
        Set
            _rfid_key = value
        End Set
    End Property
End Class