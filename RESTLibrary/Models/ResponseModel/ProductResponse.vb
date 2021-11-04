Public Class ProductResponse
    Private _id As Int64
    Private _name As String
    Private _slug As String
    Private _img As String
    Private _price As String
    Private _date_added As String


    Public Property id As Long
        Get
            Return _id
        End Get
        Set
            _id = value
        End Set
    End Property

    Public Property name As String
        Get
            Return _name
        End Get
        Set
            _name = value
        End Set
    End Property

    Public Property slug As String
        Get
            Return _slug
        End Get
        Set
            _slug = value
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

    Public Property price As String
        Get
            Return _price
        End Get
        Set
            _price = value
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