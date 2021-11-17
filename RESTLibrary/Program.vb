
Imports System.IO

Module Program
     Sub Main(args As String()) 
         Dim token = "5e888f7ddca7e427e7719b55273bc60504d2691e012b743fcf6ae611b036d7fb"
         Dim path = "C:\Users\LC-IPDO-05\Pictures\patrick-tomasso-208114-unsplash.jpg"
         Dim file = New FileStream(path,FileMode.Open)
         
         Dim message = Service.CanteenManager.AddProduct("Sinangag na Rice", 25.0, file, token)
         Console.WriteLine(message.Result.detail)
         
    End Sub
     
End Module
