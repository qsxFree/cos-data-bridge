Public Class CustomerNotFoundException 
    Inherits Exception
    
    Public Sub New ()
        MyBase.New("Customer didn't exist")
    End Sub
    
End Class