Public Class ProductSales
    Private _id As Int64
    Private _product As ProductResponse
    Private _total_sales As Double
    Private _quantity As Int64
    Private _date_reported As String

    Public Property id As Long
        Get
            Return _id
        End Get
        Set
            _id = value
        End Set
    End Property

    Public Property product As ProductResponse
        Get
            Return _product
        End Get
        Set
            _product = value
        End Set
    End Property

    Public Property total_sales As Double
        Get
            Return _total_sales
        End Get
        Set
            _total_sales = value
        End Set
    End Property

    Public Property quantity As Long
        Get
            Return _quantity
        End Get
        Set
            _quantity = value
        End Set
    End Property

    Public Property date_reported As String
        Get
            Return _date_reported
        End Get
        Set
            _date_reported = value
        End Set
    End Property
End Class