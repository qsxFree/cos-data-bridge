Public Class CategoryManagementLog
    Private _id As Integer
    Private _category_id As Integer
    Private _category As String
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

    Public Property category_id As Integer
        Get
            Return _category_id
        End Get
        Set
            _category_id = value
        End Set
    End Property

    Public Property category As String
        Get
            Return _category
        End Get
        Set
            _category = value
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