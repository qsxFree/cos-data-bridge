Public Class SetMenuItemAvailableCredential
    Private _is_available As Boolean

    Public Sub New(isAvailable As Boolean)
        _is_available = isAvailable
    End Sub

    Public Property IsAvailable As Boolean
        Get
            Return _is_available
        End Get
        Set
            _is_available = value
        End Set
    End Property
End Class