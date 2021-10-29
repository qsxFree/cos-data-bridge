Imports Utils.WebRequest
Namespace Service.SchoolCashier
    Public Module SchoolCashierService
        Private Const SCASH_ENDPOINT As String = "/management/scash"
        Async Function GetCustomerList(token As String) As Task(Of List(Of Customer))
            Dim response = Await GetAsync(AppendEndpoint($"{SCASH_ENDPOINT}/customers/"), WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                Return Utils.Json.Deserialize(Of List(Of Customer))(response.Body)
            Else
                Throw New Exception("Can't retrieve customers")
            End If
        End Function
        
        Async Function GetCustomer(username As String,token As String) As Task(Of Customer)
            Dim response = Await GetAsync(AppendEndpoint($"{SCASH_ENDPOINT}/customers/{username}/"), WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                Return Utils.Json.Deserialize(Of Customer)(response.Body)
            Else
                Throw New CustomerNotFoundException()
            End If
        End Function

        Async Function SendActivationCode(customerActivationCredential As CustomerActivationCredential, token As String) As Task(Of DetailMessage)
            Dim payload = Utils.Json.Serialize(customerActivationCredential)
            Dim response = Await PostAsync(AppendEndpoint($"{SCASH_ENDPOINT}/send_code/"), payload, WithToken(token))
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                Return Utils.Json.Deserialize(Of DetailMessage)(response.Body)
            Else
                Try
                    Return Utils.Json.Deserialize(Of DetailMessage)(response.Body)
                Catch ex As Exception
                    Return New DetailMessage With {
                        .detail = ex.Message
                        }
                End Try
            End If
        End Function

        Async Function  DeactivateCustomer(customerDeactivationCredential As CustomerDeactivationCredential, token As String) As Task(Of DetailMessage)
            Dim payload = Utils.Json.Serialize(customerDeactivationCredential)
            Dim response = Await PostAsync(AppendEndpoint($"{SCASH_ENDPOINT}/deactivate_customer/"),payload,WithToken(token))
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
        
        
        Async Function VerifyActivation(customerActivationCode As CustomerActivationCode, token As String) As Task(Of DetailMessage)
            Dim payload = Utils.Json.Serialize(customerActivationCode)
            Dim response = Await PostAsync(AppendEndpoint($"{SCASH_ENDPOINT}/activate_customer/"),payload,WithToken(token))
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
        
        Async Function AddBalance(customerAddBalalance As CustomerAddBalanceCredential,token As String) As Task(Of  DetailMessage)
            Dim payload = Utils.Json.Serialize(customerAddBalalance)
            Dim response = Await PostAsync(AppendEndpoint($"{SCASH_ENDPOINT}/add_balance/"),payload,WithToken(token))
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
    End Module
End Namespace
