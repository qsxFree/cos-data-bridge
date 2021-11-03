Public Class CategoryResponse
    Private _id As Int64
    Private _name As String
    Private  _slug As String
    Private _date_created As String

    Public Sub New(id As Long, name As String, slug As String, dateCreated As String)
        _id = id
        _name = name
        _slug = slug
        _date_created = dateCreated
    End Sub

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

    Public Property date_created As String
        Get
            Return _date_created
        End Get
        Set
            _date_created = value
        End Set
    End Property
End Class