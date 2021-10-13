Public Class InvalidLoginCredentialException
    Inherits Exception
    Public Sub New()
        MyBase.New("Invalid Login Credential")
    End Sub
    
End Class