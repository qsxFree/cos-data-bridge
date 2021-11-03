Public Class CategoryCredential
    Private _name As String

    Public Sub New(name As String)
        _name = name
    End Sub

    Public Property Name As String
        Get
            Return _name
        End Get
        Set
            _name = value
        End Set
    End Property
    
    
End Class