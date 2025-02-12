﻿Public Class CreateStaffCredential
    Private _first_name As String
    Private _last_name As String
    Private _role_code As String

    Public Sub New(firstName As String, lastName As String, roleCode As String)
        _first_name = firstName
        _last_name = lastName
        _role_code = roleCode
    End Sub

    Public Property first_name As String
        Get
            Return _first_name
        End Get
        Set
            _first_name = value
        End Set
    End Property

    Public Property last_name As String
        Get
            Return _last_name
        End Get
        Set
            _last_name = value
        End Set
    End Property

    Public Property role_code As String
        Get
            Return _role_code
        End Get
        Set
            _role_code = value
        End Set
    End Property
End Class