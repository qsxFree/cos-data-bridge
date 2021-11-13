Public Class BalanceInfo
    
    Private _id As Integer
    Private _customer As String
    Private _cashier As String
    Private _amount As String
    Private _is_deduct As String
    Private _date_transac As String

    Public Property id As Integer
        Get
            Return _id
        End Get
        Set
            _id = value
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

    Public Property cashier As String
        Get
            Return _cashier
        End Get
        Set
            _cashier = value
        End Set
    End Property

    Public Property amount As String
        Get
            Return _amount
        End Get
        Set
            _amount = value
        End Set
    End Property

    Public Property is_deduct As String
        Get
            Return _is_deduct
        End Get
        Set
            _is_deduct = value
        End Set
    End Property

    Public Property date_transac As String
        Get
            Return _date_transac
        End Get
        Set
            _date_transac = value
        End Set
    End Property
End Class