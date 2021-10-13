Public Class Customer
    Private _fk_customer As Integer
    Private _user_info As CustomerInfo
    Private _current_balance As Double
    Private _phone_num As String
    private _pin As String
    private _address As String
    private _is_activated As Boolean

    Public Property fk_customer As Integer
        Get
            Return _fk_customer
        End Get
        Set
            _fk_customer = value
        End Set
    End Property

    Public Property user_info As CustomerInfo
        Get
            Return _user_info
        End Get
        Set
            _user_info = value
        End Set
    End Property

    Public Property current_balance As Double
        Get
            Return _current_balance
        End Get
        Set
            _current_balance = value
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

    Public Property pin As String
        Get
            Return _pin
        End Get
        Set
            _pin = value
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

    Public Property is_activated As Boolean
        Get
            Return _is_activated
        End Get
        Set
            _is_activated = value
        End Set
    End Property
End Class