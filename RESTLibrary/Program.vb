
Imports System.IO

Module Program
    Sub Main(args As String()) 
        Dim token = "6c18146b4cf677cb380b3e16637f17f9a618cbc5a65b71415e9fcf43018a9a45"
        Try
            Dim res = Service.CanteenManager.UpdateProduct(New ProductCredential("Chicken Curry",Nothing,30),"chicken",token).Result
            Console.WriteLine(res.detail)
        Catch ex  As Exception
            Console.WriteLine(ex)
        End Try
        
        
    End Sub
     
End Module
