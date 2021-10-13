Imports Utils.WebRequest
Namespace Service.SchoolCashier
    Public Module SchoolCashierService
        Async Function GetCustomerList(token As String) As Task(Of List(Of Customer))
            Dim response = Await GetAsync(AppendEndpoint("/management/scash/customers/"), WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                Return Utils.Json.Deserialize(Of List(Of Customer))(response.Body)
            Else
                Throw New Exception("Can't retrieve customers")
            End If
        End Function
        
        Async Function GetCustomer(username As String,token As String) As Task(Of Customer)
            Dim response = Await GetAsync(AppendEndpoint($"/management/scash/customers/{username}/"), WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                Return Utils.Json.Deserialize(Of Customer)(response.Body)
            Else
                Throw New CustomerNotFoundException()
            End If
        End Function
    End Module
End Namespace
