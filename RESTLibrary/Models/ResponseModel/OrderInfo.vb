Public Class OrderInfo
    Private _id As Integer
    Private _cashier As String
    Private _customer As String
    Private _items As List(Of OrderItem)
    Private _account_based As Boolean
    Private _total_price As String
    Private _status As String
    Private _date_ordered As String

    Public Property id As Integer
        Get
            Return _id
        End Get
        Set
            _id = value
        End Set
    End Property

    Public Property cashier As String
        Get
            Return _cashier
        End Get
        Set
            _cashier = value
        End Set
    End Property

    Public Property customer As String
        Get
            Return _customer
        End Get
        Set
            _customer = value
        End Set
    End Property

    Public Property items As List(Of OrderItem)
        Get
            Return _items
        End Get
        Set
            _items = value
        End Set
    End Property

    Public Property account_based As Boolean
        Get
            Return _account_based
        End Get
        Set
            _account_based = value
        End Set
    End Property

    Public Property total_price As String
        Get
            Return _total_price
        End Get
        Set
            _total_price = value
        End Set
    End Property

    Public Property status As String
        Get
            Return _status
        End Get
        Set
            _status = value
        End Set
    End Property

    Public Property date_ordered As String
        Get
            Return _date_ordered
        End Get
        Set
            _date_ordered = value
        End Set
    End Property
End Class