
Module Program
     Sub Main(args As String()) 
         Dim authentication  =  Service.Login.Login(New LoginCredential("SCASH-0000", "$password123"))
         SharedPreference.Auth = authentication.Result
         Dim response = Service.SchoolCashier.GetCustomer("18-1338",SharedPreference.Auth.token)
         
         Console.WriteLine(response.Result.phone_num)
    End Sub
     
End Module
