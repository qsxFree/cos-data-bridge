Public Class Status
    Private _status As String

    Public Property status As String
        Get
            Return _status
        End Get
        Set
            _status = value
        End Set
    End Property

    Public Sub New(status As String)
        _status = status
    End Sub
End Class