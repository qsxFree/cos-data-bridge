Imports Utils.WebRequest
Namespace Service.Admin
    Public Module AdminService
        Async Function GetCustomerList(token As String) As Task(Of List(Of Customer))
            Dim response = GetAsync(AppendEndpoint("/management/admin/customers/"),WithToken(token))
            return Utils.Json.Deserialize(Of List(Of Customer))(response.Result.Body)
        End Function
    End Module
End Namespace
