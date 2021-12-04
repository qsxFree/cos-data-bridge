Public Class Orders
    Private _product As String
    Private _quantity AS Integer

    
    'product slug
    Public Property product As String
        Get
            Return _product
        End Get
        Set
            _product = value
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