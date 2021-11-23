
Imports System.IO

Module Program
    Sub Main(args As String()) 
        SharedPreference.Auth = Service.Login.Login(New LoginCredential("ADMN-0000","@password123")).Result
        Console.WriteLine(SharedPreference.Auth.token)
    End Sub
     
End Module
