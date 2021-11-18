Imports System.IO

Public Class ProductCredential
    Private _name As String
    Private _img As String
    Private _price As Double

    Public Sub New(name As String, img As String, price As Double)
        _name = name
        _img = img
        _price = price
    End Sub

    Public Property name As String
        Get
            Return _name
        End Get
        Set
            _name = value
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

    Public Property price As Double
        Get
            Return _price
        End Get
        Set
            _price = value
        End Set
    End Property
End Class