
Imports Utils.WebRequest

Namespace Service.Login
    Public Module LoginService
        Async Function Login(loginCredential As LoginCredential) As Task(Of Authentication)
            
            Dim payload = Utils.Json.Serialize(loginCredential)
            Dim response = Await PostAsync(AppendEndpoint("/auth/management/login/"), payload, WithoutToken())
            If response.Result.StatusCode = Net.HttpStatusCode.OK Then
                Return Utils.Json.Deserialize(Of Authentication)(response.Body)
            Else
                Throw New InvalidLoginCredentialException()
            End If
            
        End Function
    End Module

End Namespace