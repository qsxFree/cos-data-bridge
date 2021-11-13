Public Class OrderItem
    Private _p_id As Int32
    Private _product As String
    Private _price As Double
    Private _img As String
    Private _quantity As Int32


    Public Property p_id As Integer
        Get
            Return _p_id
        End Get
        Set
            _p_id = value
        End Set
    End Property

    Public Property product As String
        Get
            Return _product
        End Get
        Set
            _product = value
        End Set
    End Property

    Public Property price As Double
        Get
            Return _price
        End Get
        Set
            _price = value
        End Set
    End Property

    Public Property img As String
        Get
            Return _img
        End Get
        Set
            _img = value
        End Set
    End Property

    Public Property quantity As Integer
        Get
            Return _quantity
        End Get
        Set
            _quantity = value
        End Set
    End Property
End Class