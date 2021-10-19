
Module Program
     Sub Main(args As String()) 
         Dim authentication  =  Service.Login.Login(New LoginCredential("SCASH-0000", "$password123"))
         SharedPreference.Auth = authentication.Result
         Console.WriteLine(SharedPreference.Auth.token)
         Dim customerAddBalanceCredential = New CustomerAddBalanceCredential("18-1338",500.0)
         Dim response = Service.SchoolCashier.AddBalance(customerAddBalanceCredential,SharedPreference.Auth.token)
         Console.WriteLine(response.Result.detail)
    End Sub
     
End Module
