Public Class OrderCredentials
    Private _rfid_key As String
    Private _orders As List(Of Orders)
    Private _account_based AS Boolean

    Public Sub New(rfidKey As String, orders As List(Of Orders))
        _rfid_key = rfidKey
        _orders = orders
        _account_based = true
    End Sub

    Public Property rfid_key As String
        Get
            Return _rfid_key
        End Get
        Set
            _rfid_key = value
        End Set
    End Property

    Public Property orders As List(Of Orders)
        Get
            Return _orders
        End Get
        Set
            _orders = value
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
End Class