Public Class ProductManagementLog
    Private _id As Integer
    Private _product_id As Integer
    Private _product As String
    Private _manager As String
    Private _action As String
    Private _date_added As String

    Public Property id As Integer
        Get
            Return _id
        End Get
        Set
            _id = value
        End Set
    End Property

    Public Property product_id As Integer
        Get
            Return _product_id
        End Get
        Set
            _product_id = value
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

    Public Property manager As String
        Get
            Return _manager
        End Get
        Set
            _manager = value
        End Set
    End Property

    Public Property action As String
        Get
            Return _action
        End Get
        Set
            _action = value
        End Set
    End Property

    Public Property date_added As String
        Get
            Return _date_added
        End Get
        Set
            _date_added = value
        End Set
    End Property
End Class