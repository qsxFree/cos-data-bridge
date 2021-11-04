Public Class MenuSlugs
    Private _product As String
    Private _category As String

    Public Sub New(productSlug As String, categorySlug As String)
        _product = productSlug
        _category = categorySlug
    End Sub

    Public Property product As String
        Get
            Return _product
        End Get
        Set
            _product = value
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
End Class