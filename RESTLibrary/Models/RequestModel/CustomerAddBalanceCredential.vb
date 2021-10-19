Public Class CustomerAddBalanceCredential
    Private _username As String
    Private _amount As Double

    Public Property username As String
        Get
            Return _username
        End Get
        Set
            _username = value
        End Set
    End Property

    Public Property amount As Double
        Get
            Return _amount
        End Get
        Set
            _amount = value
        End Set
    End Property

    Public Sub New(username As String, amount As Double)
        _username = username
        _amount = amount
    End Sub
End Class