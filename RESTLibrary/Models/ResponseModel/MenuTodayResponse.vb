Public Class MenuTodayResponse
    Private _id As Integer
    Private _product As ProductResponse
    Private _category As CategoryResponse
    Private _rating As Double
    Private _is_available As Boolean
    Private _date_added As String


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

    Public Property category As CategoryResponse
        Get
            Return _category
        End Get
        Set
            _category = value
        End Set
    End Property

    Public Property rating As Double
        Get
            Return _rating
        End Get
        Set
            _rating = value
        End Set
    End Property

    Public Property is_available As Boolean
        Get
            Return _is_available
        End Get
        Set
            _is_available = value
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