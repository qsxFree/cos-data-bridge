Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
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
            Dim payload = Utils.Json.Serialize(categoryCredential)
            Dim response = Await PostAsync(AppendEndpoint($"{CMNGR_ENDPOINT}/category_list/"),payload,WithToken(token))
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
            Dim payload = Utils.Json.Serialize(categoryCredential)
            Dim response = Await PostAsync(AppendEndpoint($"{CMNGR_ENDPOINT}/category_detail/{categoryId}/"),payload,WithToken(token))
            If response.Result.StatusCode = HttpStatusCode.OK Or response.Result.StatusCode = HttpStatusCode.Created Then
                Return Utils.Json.Deserialize(Of DetailMessage)(response.Body)
            Else
                Throw New Exception("Can't update category")
            End If
        End Function
        
        ''TODO Add the AddProduct Method here
        
        ''TODO To be Tested
        Async Function ProductList(token As String) As Task(Of List(Of ProductResponse))
            Dim response = Await GetAsync(AppendEndpoint($"{CMNGR_ENDPOINT}/product_list/"),WithToken(token))
            If response.Result.StatusCode = HttpStatusCode.OK Then
                Return Utils.Json.Deserialize(Of List(Of ProductResponse))(response.Body)
            Else
                Throw New Exception("Can't retrieve product list")
            End If
        End Function
        
        ''TODO Add the UpdateProduct Method here
        
        ''TODO To be Tested
        Async Function AddMenuItem(slugs As MenuSlugs,token As String) As Task(Of DetailMessage)
            Dim payload = Utils.Json.Serialize(slugs)
            Dim response = Await PostAsync(AppendEndpoint($"{CMNGR_ENDPOINT}/menu_list/"),payload,WithToken(token))
            If response.Result.StatusCode = HttpStatusCode.OK Or response.Result.StatusCode = HttpStatusCode.Created Then
                Return Utils.Json.Deserialize(Of DetailMessage)(response.Body)
            Else
                Throw New Exception("Can't update category")
            End If
        End Function
        
        ''TODO To be Tested
        Async Function GetMenuToday(token As String) As Task(Of List(Of MenuTodayResponse))
            Dim response = Await GetAsync(AppendEndpoint($"{CMNGR_ENDPOINT}/menu_list/"),WithToken(token))
            If response.Result.StatusCode = HttpStatusCode.OK Then
                Return Utils.Json.Deserialize(Of List(Of MenuTodayResponse))(response.Body)
            Else
                Throw New Exception("Can't retrieve today's menu")
            End If
        End Function
        
        ''TODO To be Tested
        Async Function SetMenuAvailability(menuId As Int16,menuItemAvailability As SetMenuItemAvailableCredential, token As String) As Task(Of DetailMessage)
            Dim payload = Utils.Json.Serialize(menuItemAvailability)
            Dim response = Await PutAsync(AppendEndpoint($"{CMNGR_ENDPOINT}/set_menu_availability/{menuId}/"),payload,WithToken(token))
            If response.Result.StatusCode = HttpStatusCode.OK Or response.Result.StatusCode = HttpStatusCode.Created Then
                Return Utils.Json.Deserialize(Of DetailMessage)(response.Body)
            Else
                Throw New Exception("Can't modify item availability")
            End If
        End Function
        
        ''TODO To be Tested
        Async Function GetProductSalesLogs(token As String) As Task(Of List(Of ProductSales))
            Dim response = Await GetAsync(AppendEndpoint($"{CMNGR_ENDPOINT}/product_sales/"),WithToken(token))
            If response.Result.StatusCode = HttpStatusCode.OK Or response.Result.StatusCode = HttpStatusCode.Created Then
                Return Utils.Json.Deserialize(Of List(Of ProductSales))(response.Body)
            Else
                Throw New Exception("Can't  retrieve product sales log")
            End If
        End Function

        ''TODO To be Tested
        Async Function GetStaffDetail(username As String,token As String) As Task(Of StaffResponse)
            Dim response = Await GetAsync(AppendEndpoint($"{CMNGR_ENDPOINT}/staff_detail/{username}"),WithToken(token))
            If response.Result.StatusCode = HttpStatusCode.OK Or response.Result.StatusCode = HttpStatusCode.Created Then
                Return Utils.Json.Deserialize(Of StaffResponse)(response.Body)
            Else
                Throw New Exception("Can't retrieve staff detail")
            End If
        End Function
        
        
        Async Function AddProduct(name As String, price As Double, fileData As FileStream,token As String) As Task(Of DetailMessage)
         
            Dim form  = New MultipartFormDataContent()
            form.Add(New StreamContent(fileData),"img",fileData.Name)
            form.Add(New StringContent(name),"name")
            form.Add(New StringContent(price.ToString()),"price")
            form.Headers.ContentType.MediaType = "multipart/form-data"
            
            Dim client = New HttpClient()
            client.DefaultRequestHeaders.Add("Authorization",$"Token {token}")
            
            Dim httpResponse = Await client.PostAsync(AppendEndpoint($"{CMNGR_ENDPOINT}/product_list/"),form)
            If httpResponse.StatusCode = HttpStatusCode.OK Or httpResponse.StatusCode = HttpStatusCode.Created Then
                Return Utils.Json.Deserialize(Of DetailMessage)(Await httpResponse.Content.ReadAsStringAsync())
            ElseIf httpResponse.StatusCode = HttpStatusCode.BadRequest Then
                Return Utils.Json.Deserialize(Of DetailMessage)(Await httpResponse.Content.ReadAsStringAsync())
            Else
                Throw New Exception("Can't  retrieve product sales log")
            End If
        End Function
        
    End Module
End Namespace