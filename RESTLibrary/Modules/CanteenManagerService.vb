Imports System.Net
Imports Utils.WebRequest

Namespace Service.CanteenManager
    Public Module CanteenManagerService
        Private Const CMNGR_ENDPOINT As String = "/management/cmngr"
        
        
        ''TODO To be Tested
        Async Function GetCashierList(token As String) As Task(Of List(Of StaffResponse))
            Dim response = Await GetAsync(AppendEndpoint($"{CMNGR_ENDPOINT}/staff_list/"),WithToken(token))
            If response.Result.StatusCode = HttpStatusCode.OK Then
                Return Utils.Json.Deserialize(Of List(Of StaffResponse))(response.Body)
            Else
                Throw New Exception("Can't retrieve cashier list")
            End If
        End Function
        
        ''TODO To be Tested
        Async Function AddCategory(categoryCredential As CategoryCredential,token As String) As Task(Of DetailMessage)
            Dim response = Await GetAsync(AppendEndpoint($"{CMNGR_ENDPOINT}/category_list/"),WithToken(token))
            If response.Result.StatusCode = HttpStatusCode.OK Or response.Result.StatusCode = HttpStatusCode.Created Then
                Return Utils.Json.Deserialize(Of DetailMessage)(response.Body)
            Else
                Throw New Exception("Can't add category")
            End If
        End Function
        
        ''TODO To be Tested
        Async Function GetCategoryList(token As String) As Task(Of List(Of CategoryResponse))
            Dim response = Await GetAsync(AppendEndpoint($"{CMNGR_ENDPOINT}/category_list/"),WithToken(token))
            If response.Result.StatusCode = HttpStatusCode.OK Then
                Return Utils.Json.Deserialize(Of List(Of CategoryResponse))(response.Body)
            Else
                Throw New Exception("Can't retrieve category list")
            End If
        End Function
        
        ''TODO To be Tested
        Async Function UpdateCategory(categoryCredential As CategoryCredential, categoryId As String ,token As String) As Task(Of DetailMessage)
            Dim response = Await GetAsync(AppendEndpoint($"{CMNGR_ENDPOINT}/category_detail/{categoryId}/"),WithToken(token))
            If response.Result.StatusCode = HttpStatusCode.OK Or response.Result.StatusCode = HttpStatusCode.Created Then
                Return Utils.Json.Deserialize(Of DetailMessage)(response.Body)
            Else
                Throw New Exception("Can't update category")
            End If
        End Function
        
        
        
        
        
    End Module
End Namespace