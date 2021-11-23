Public Class StaffResponse
    Private _fk_staff As Integer
    Private _user_info As StaffInfo
    Private _address As String
    Private _role_code As String
    Private _role_type As String

    Public Property fk_staff As Long
        Get
            Return _fk_staff
        End Get
        Set
            _fk_staff = value
        End Set
    End Property

    Public Property user_info As StaffInfo
        Get
            Return _user_info
        End Get
        Set
            _user_info = value
        End Set
    End Property

    Public Property address As String
        Get
            Return _address
        End Get
        Set
            _address = value
        End Set
    End Property

    Public Property role_code As String
        Get
            Return _role_code
        End Get
        Set
            _role_code = value
        End Set
    End Property

    Public Property role_type As String
        Get
            Return _role_type
        End Get
        Set
            _role_type = value
        End Set
    End Property
End Class