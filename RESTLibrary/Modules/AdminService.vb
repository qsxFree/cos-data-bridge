Imports Utils.WebRequest
Namespace Service.Admin
    Public Module AdminService
        
        Private Const ADMN_ENDPOINT As String = "/management/admin"
        Async Function GetCustomerList(token As String) As Task(Of List(Of Customer))
            Dim response = Await GetAsync(AppendEndpoint($"{ADMN_ENDPOINT}/customers/"),WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                return Utils.Json.Deserialize(Of List(Of Customer))(response.Body)
            Else 
                Throw New Exception("Cannot retrieve customer list")
            End If
        End Function
        
        Async Function CreateCustomer(createCustomerCredential As CreateCustomerCredential, token As String) As Task(Of DetailMessage)
            Dim payload = Utils.Json.Serialize(createCustomerCredential)
            Dim response = Await PostAsync(AppendEndpoint($"{ADMN_ENDPOINT}/customers/"), payload, WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                Return Utils.Json.Deserialize(Of DetailMessage)(response.Body)
            Else
                Try
                    Return Utils.Json.Deserialize(Of DetailMessage)(response.Body)
                Catch ex As Exception
                    Return New DetailMessage With{
                        .detail = ex.Message
                        }
                End Try    
            End If
        End Function
        
        '' TODO To be Tested
        Async Function GetCustomer(username As String , token As String ) As Task(Of Customer)
            Dim response = Await GetAsync(AppendEndpoint($"{ADMN_ENDPOINT}/customers/{username}/"), WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                Return Utils.Json.Deserialize(Of Customer)(response.Body)
            Else
                Throw New CustomerNotFoundException()
            End If
        End Function
        
        '' TODO To be Tested
        Async Function UpdateCustomer(createCustomerCredential As CreateCustomerCredential, username As String, token As String) As Task(Of DetailMessage)
            Dim payload = Utils.Json.Serialize(createCustomerCredential)
            Dim response = Await PutAsync(AppendEndpoint($"{ADMN_ENDPOINT}/customers/{username}/"), payload, WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                Return Utils.Json.Deserialize(Of DetailMessage)(response.Body)
            Else
                Try
                    Return Utils.Json.Deserialize(Of DetailMessage)(response.Body)
                Catch ex As Exception
                    Return New DetailMessage With{
                        .detail = ex.Message
                        }
                End Try    
            End If
        End Function
        
        '' TODO To be Tested
        Async Function CreateStaff(createStaffCredential As CreateStaffCredential, token As String) As Task(Of Staff)
            Dim payload = Utils.Json.Serialize(createStaffCredential)
            Dim response = Await PostAsync(AppendEndpoint($"{ADMN_ENDPOINT}/staffs/"), payload, WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Or response.Result.StatusCode = Net.HttpStatusCode.Created Then
                Return Utils.Json.Deserialize(Of Staff)(response.Body)
            Else
                Throw New Exception("Can't create new staff")  
            End If
        End Function
        
        '' TODO To be Tested
        Async Function GetStaffList(token As String) As Task(Of List(Of StaffResponse))
            Dim response = Await GetAsync(AppendEndpoint($"{ADMN_ENDPOINT}/staffs/"),WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                return Utils.Json.Deserialize(Of List(Of StaffResponse))(response.Body)
            Else 
                Throw New Exception("Cannot retrieve staff list")
            End If
        End Function
        
        '' TODO To be Tested
        '' TODO Check the if the request will work with a given payload
        Async Function ResetStaffPassword(username As String, token As String) As Task(Of StaffResetResponse)
            Dim response = Await PutAsync(AppendEndpoint($"{ADMN_ENDPOINT}/staff/reset_pass/{username}/"),"", WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                Return Utils.Json.Deserialize(Of StaffResetResponse)(response.Body)
            Else
                Throw New Exception("Cannot reset staff's password")
            End If
        End Function
        
        '' TODO To be Tested
        Async Function GetUserLogs(token As String) As Task(Of List(Of UserLog))
            Dim response = Await GetAsync(AppendEndpoint($"{ADMN_ENDPOINT}/users/login_log/"),WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                return Utils.Json.Deserialize(Of List(Of UserLog))(response.Body)
            Else 
                Throw New Exception("Cannot retrieve users' log")
            End If
        End Function
        
        '' TODO To be Tested
        Async Function GetOrderLogs(token As String) As Task(Of List(Of OrderInfo))
            Dim response = Await GetAsync(AppendEndpoint($"{ADMN_ENDPOINT}/ordering/orders/"),WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                return Utils.Json.Deserialize(Of List(Of OrderInfo))(response.Body)
            Else 
                Throw New Exception("Cannot retrieve order log")
            End If
        End Function
        
        Async Function GetProductSalesLogs(token As String) As Task(Of List(Of ProductSales))
            Dim response = Await GetAsync(AppendEndpoint($"{ADMN_ENDPOINT}/sales/product_sales/"),WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Or response.Result.StatusCode = Net.HttpStatusCode.Created Then
                Return Utils.Json.Deserialize(Of List(Of ProductSales))(response.Body)
            Else
                Throw New Exception("Can't  retrieve product sales log")
            End If
        End Function
        
        Async Function GetDailySales(token As String) As Task(Of List(Of DailySalesLog))
            Dim response = Await GetAsync(AppendEndpoint($"{ADMN_ENDPOINT}/sales/daily_sales/"),WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Or response.Result.StatusCode = Net.HttpStatusCode.Created Then
                Return Utils.Json.Deserialize(Of List(Of DailySalesLog))(response.Body)
            Else
                Throw New Exception("Can't  retrieve daily sales log")
            End If
        End Function
        
        '' TODO To be Tested
        Async Function GetProfile(token As String) As Task(Of StaffResponse)
            Dim response = Await GetAsync(AppendEndpoint($"{ADMN_ENDPOINT}/profile/"), WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                return Utils.Json.Deserialize(Of StaffResponse)(response.Body)
            Else 
                Throw New Exception("Cannot retrieve profile")
            End If
        End Function
        
        Async Function GetStaffManagementLog(token As String) As Task(Of List(Of StaffManagementLog))
            Dim response = Await GetAsync(AppendEndpoint($"{ADMN_ENDPOINT}/staff_mngmnt_log/"),WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                Return Utils.Json.Deserialize(Of List(Of StaffManagementLog))(response.Body)
            Else
                Throw New Exception("Can't retrieve staff management log")
            End If
        End Function
        
    End Module
End Namespace
