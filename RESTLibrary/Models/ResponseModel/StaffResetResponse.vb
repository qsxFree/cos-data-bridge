﻿Public Class StaffResetResponse
    Private _username As String
    Private _password As String

    Public Property username As String
        Get
            Return _username
        End Get
        Set
            _username = value
        End Set
    End Property

    Public Property password As String
        Get
            Return _password
        End Get
        Set
            _password = value
        End Set
    End Property
End Class