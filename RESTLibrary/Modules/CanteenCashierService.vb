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
        
        Async Function GetMenuList(token As String) As Task(Of List(Of MenuTodayResponse))
            Dim response = Await GetAsync(AppendEndpoint($"{CCASH_ENDPOINT}/menu_list/"), WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                return Utils.Json.Deserialize(Of List(Of MenuTodayResponse))(response.Body)
            Else 
                Throw New Exception("Cannot retrieve profile")
            End If
        End Function
        
        
        Async Function SetMenuAvailability(menuId As Integer, menuItemAvailability As SetMenuItemAvailableCredential, token As String) As Task(Of DetailMessage)
            Dim payload = Utils.Json.Serialize(menuItemAvailability)
            Dim response = Await PutAsync(AppendEndpoint($"{CCASH_ENDPOINT}/set_menu_availability/{menuId}/"),payload,WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Or response.Result.StatusCode = Net.HttpStatusCode.Created Then
                Return Utils.Json.Deserialize(Of DetailMessage)(response.Body)
            Else
                Throw New Exception("Can't modify item availability")
            End If
        End Function
        
        '' TODO To be Tested
        Async Function GetOrderLogs(token As String) As Task(Of List(Of OrderInfo))
            Dim response = Await GetAsync(AppendEndpoint($"{CCASH_ENDPOINT}/order_logs/"),WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                return Utils.Json.Deserialize(Of List(Of OrderInfo))(response.Body)
            Else 
                Throw New Exception("Cannot retrieve order log")
            End If
        End Function
        
        '' TODO To be Tested
        Async Function BalanceLog(token As String) As Task(Of List(Of BalanceInfo))
            Dim response = Await GetAsync(AppendEndpoint($"{CCASH_ENDPOINT}/customer_balance_log/"), WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                Return Utils.Json.Deserialize(Of List(Of BalanceInfo))(response.Body)
            Else
                Throw New Exception("Cannot retrieve balance log")
            End If
        End Function
        
        '' TODO To be Tested
        '' TODO Check the if the request will work with a given payload
        Async Function CancelOrder(orderId As Integer, token As String) As Task(Of DetailMessage)
            Dim payload =  Utils.Json.Serialize(New Status("CANCELLED"))
            Dim response = Await PutAsync(AppendEndpoint($"{CCASH_ENDPOINT}/cancel_order/{orderId}/"),payload, WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                Return Utils.Json.Deserialize(Of DetailMessage)(response.Body)
            Else
                Throw New Exception("Cannot cancel order")
            End If
        End Function
        
    End Module
End Namespace