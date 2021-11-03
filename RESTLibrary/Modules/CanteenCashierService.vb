Imports Utils.WebRequest
Namespace Service.CanteenCashier
    Public Module CanteenCashierService
        Private Const CCASH_ENDPOINT As String = "/management/ccash"
        
        Async Function GetProfile(token As String) As Task(Of StaffResponse)
            Dim response = Await GetAsync(AppendEndpoint($"{CCASH_ENDPOINT}/profile/"), WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                return Utils.Json.Deserialize(Of StaffResponse)(response.Body)
            Else 
                Throw New Exception("Cannot retrieve profile")
            End If
        End Function
        
        
        Async Function GetMenuList(token As String) As Task(Of StaffResponse)
            Dim response = Await GetAsync(AppendEndpoint($"{CCASH_ENDPOINT}/menu_list/"), WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                return Utils.Json.Deserialize(Of StaffResponse)(response.Body)
            Else 
                Throw New Exception("Cannot retrieve profile")
            End If
        End Function
        
        
    End Module
End Namespace