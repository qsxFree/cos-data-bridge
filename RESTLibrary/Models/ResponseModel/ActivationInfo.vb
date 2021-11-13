Public Class ActivationInfo
    Private _id As Integer
    Private _customer As String
    Private _scash As String
    Private _is_activated As String
    Private _date_created As String

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

    Public Property scash As String
        Get
            Return _scash
        End Get
        Set
            _scash = value
        End Set
    End Property

    Public Property is_activated As String
        Get
            Return _is_activated
        End Get
        Set
            _is_activated = value
        End Set
    End Property

    Public Property date_created As String
        Get
            Return _date_created
        End Get
        Set
            _date_created = value
        End Set
    End Property
End Class