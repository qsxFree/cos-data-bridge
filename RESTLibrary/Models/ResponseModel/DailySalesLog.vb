Public Class DailySalesLog
    Private _id As Integer
    Private _overall_sales As String
    Private _overall_quantity As Integer
    Private _date_reported As String

    Public Property id As Integer
        Get
            Return _id
        End Get
        Set
            _id = value
        End Set
    End Property

    Public Property overall_sales As String
        Get
            Return _overall_sales
        End Get
        Set
            _overall_sales = value
        End Set
    End Property

    Public Property overall_quantity As Integer
        Get
            Return _overall_quantity
        End Get
        Set
            _overall_quantity = value
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