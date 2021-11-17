
Option Strict On
Option Explicit On

Namespace Global.Utils
    Namespace Json
        Public Module FetchDependecy
            ''' <summary>
            ''' Serializes the specified value to Json
            ''' </summary>
            ''' <param name="value">The value to serialize</param> 
            ''' <param name="settings">The Newtonsoft.Json.JsonSerializerSettings used to serialize the object</param> 
            ''' <returns>The value serialized to Json</returns>
            Public Function Serialize(value As Object _
                                      , Optional settings As Newtonsoft.Json.JsonSerializerSettings = Nothing) As String
                If settings Is Nothing Then
                    settings = GetDefaultSettings()
                End If
                Return Newtonsoft.Json.JsonConvert.SerializeObject(value, settings)
            End Function

            ''' <summary>
            ''' Deserializes the specified value from Json to Object T
            ''' </summary>
            ''' <param name="value">The value to deserialize</param> 
            ''' <param name="settings">The Newtonsoft.Json.JsonSerializerSettings used to deserialize the object</param> 
            ''' <returns>The value deserialized to Object T</returns>
            Public Function Deserialize(Of T)(value As String _
                                              , Optional settings As Newtonsoft.Json.JsonSerializerSettings = Nothing) As T
                If settings Is Nothing Then
                    settings = GetDefaultSettings()
                End If
                Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of T)(value, settings)
            End Function

            Private Function GetDefaultSettings() As Newtonsoft.Json.JsonSerializerSettings
                Static settings As New Newtonsoft.Json.JsonSerializerSettings With {
                    .Formatting = Newtonsoft.Json.Formatting.Indented
                }
                Return settings
            End Function
        End Module
    End Namespace

    Namespace WebRequest
        
        Public Module modRequest
            Private Const ServerAddress As String = "https://cnsc-cos.herokuapp.com"
            
            Public Function AppendEndpoint(endpoint As String) As String
                Return ServerAddress + endpoint
            End Function
        
            Public Function WithToken(token As String) As Options
                Dim options = New Options With {
                        .UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:82.0) Gecko/20100101 Firefox/82.0",
                        .ContentType = ContentType.ApplicationJson,
                        .Headers = New Net.WebHeaderCollection From {
                            {"Authorization", $"Token {token}"}
                        }}
                return options
            End Function
            
            Public Function FormBased(token As String) As Options
                Dim options = New Options With {
                        .UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:82.0) Gecko/20100101 Firefox/82.0",
                        .ContentType = ContentType.MultipartFormData,
                        .Headers = New Net.WebHeaderCollection From {
                            {"Authorization", $"Token {token}"},
                            {"Content-type","multipart/form-data"}
                        }}
                return options
            End Function
        
            Public Function WithoutToken() As Options
                Dim options = New Options With {
                        .UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:82.0) Gecko/20100101 Firefox/82.0",
                        .ContentType = ContentType.ApplicationJson
                        }
                return options
            End Function
            
            
            ''' <summary>
            ''' Executes a GET request on the given url
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function [Get](url As String _
                                  , Optional options As Options = Nothing) As Response
                Return GetAsync(url, options:=options).Result
            End Function

            ''' <summary>
            ''' Executes a GET request on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function GetAsync(url As String _
                                  , Optional options As Options = Nothing) As Task(Of Response)
                Return ExecuteAsync(Method.Get, url, payload:=CType(Nothing, Byte()), options:=options)
            End Function

            ''' <summary>
            ''' Executes a POST request on the given url
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to post to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function Post(url As String, payload As String _
                                , Optional options As Options = Nothing) As Response
                Return Post(url, payload:=payload.GetBytes, options:=options)
            End Function

            ''' <summary>
            ''' Executes a POST request on the given url
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to post to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function Post(url As String, payload As Byte() _
                                , Optional options As Options = Nothing) As Response
                Return PostAsync(url, payload:=payload, options:=options).Result
            End Function

            ''' <summary>
            ''' Executes a POST request on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to post to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function PostAsync(url As String, payload As String _
                                , Optional options As Options = Nothing) As Task(Of Response)
                Return PostAsync(url, payload:=payload.GetBytes, options:=options)
            End Function

            ''' <summary>
            ''' Executes a POST request on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to post to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function PostAsync(url As String, payload As Byte() _
                                , Optional options As Options = Nothing) As Task(Of Response)
                Return ExecuteAsync(Method.Post, url, payload:=payload, options:=options)
            End Function

            ''' <summary>
            ''' Executes a PUT request on the given url
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to put to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function Put(url As String, payload As String _
                                , Optional options As Options = Nothing) As Response
                Return Put(url, payload:=payload.GetBytes, options:=options)
            End Function

            ''' <summary>
            ''' Executes a PUT request on the given url
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to put to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function Put(url As String, payload As Byte() _
                                , Optional options As Options = Nothing) As Response
                Return PutAsync(url, payload:=payload, options:=options).Result
            End Function

            ''' <summary>
            ''' Executes a PUT request on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to put to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function PutAsync(url As String, payload As String _
                                , Optional options As Options = Nothing) As Task(Of Response)
                Return PutAsync(url, payload:=payload.GetBytes, options:=options)
            End Function

            ''' <summary>
            ''' Executes a PUT request on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to put to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function PutAsync(url As String, payload As Byte() _
                                , Optional options As Options = Nothing) As Task(Of Response)
                Return ExecuteAsync(Method.Put, url, payload:=payload, options:=options)
            End Function

            ''' <summary>
            ''' Executes a PATCH request on the given url
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to patch to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function Patch(url As String, payload As String _
                                , Optional options As Options = Nothing) As Response
                Return Patch(url, payload:=payload.GetBytes, options:=options)
            End Function

            ''' <summary>
            ''' Executes a PATCH request on the given url
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to patch to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function Patch(url As String, payload As Byte() _
                                , Optional options As Options = Nothing) As Response
                Return PatchAsync(url, payload:=payload, options:=options).Result
            End Function

            ''' <summary>
            ''' Executes a PATCH request on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to patch to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function PatchAsync(url As String, payload As String _
                                , Optional options As Options = Nothing) As Task(Of Response)
                Return PatchAsync(url, payload:=payload.GetBytes, options:=options)
            End Function

            ''' <summary>
            ''' Executes a PATCH request on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to patch to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function PatchAsync(url As String, payload As Byte() _
                                , Optional options As Options = Nothing) As Task(Of Response)
                Return ExecuteAsync(Method.Patch, url, payload:=payload, options:=options)
            End Function

            ''' <summary>
            ''' Executes a DELETE request on the given url
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function Delete(url As String _
                                  , Optional options As Options = Nothing) As Response
                Return DeleteAsync(url, options:=options).Result
            End Function

            ''' <summary>
            ''' Executes a DELETE request on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function DeleteAsync(url As String _
                                  , Optional options As Options = Nothing) As Task(Of Response)
                Return ExecuteAsync(Method.Delete, url, payload:=CType(Nothing, Byte()), options:=options)
            End Function

            ''' <summary>
            ''' Executes a request method on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="type">The type of request method to execute</param>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to send to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function ExecuteAsync(type As Method _
                                    , url As String _
                                    , Optional payload As String = Nothing _
                                    , Optional options As Options = Nothing) As Task(Of Response)
                Return ExecuteAsync(type, url, payload:=CType(payload?.GetBytes, Byte()), options:=options)
            End Function

            ''' <summary>
            ''' Executes a request method on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="type">The type of request method to execute</param>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to send to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Async Function ExecuteAsync(type As Method _
                                    , url As String _
                                    , Optional payload As Byte() = Nothing _
                                    , Optional options As Options = Nothing) As Task(Of Response)
                Dim request = CType(System.Net.WebRequest.Create(url), System.Net.HttpWebRequest)
                If options IsNot Nothing Then
                    request.CopyProperties(options)
                End If
                request.Method = type.ToString.ToUpper

                If payload IsNot Nothing Then
                    request.ContentLength = payload.Length
                    Using requestStream = request.GetRequestStream
                        Using payloadStream = New System.IO.MemoryStream(payload)
                            payloadStream.CopyTo(requestStream)
                        End Using
                    End Using
                End If

                Dim webResponse As System.Net.HttpWebResponse = Nothing
                Try
                    webResponse = CType(Await request.GetResponseAsync(), System.Net.HttpWebResponse)
                Catch ex As System.Net.WebException
                    If ex.Response Is Nothing Then
                        Throw
                    End If
                    webResponse = CType(ex.Response, System.Net.HttpWebResponse)
                Catch ex As Exception
                    Throw
                End Try

                Dim result = New Response With {
                    .Result = webResponse,
                    .Bytes = GetBytes(webResponse)
                }

                Return result
            End Function

            Private Function GetBytes(response As System.Net.HttpWebResponse) As Byte()
                Dim bytes As Byte()
                Dim responseStream = response.GetResponseStream()
                Using memoryStream = New System.IO.MemoryStream
                    responseStream.CopyTo(memoryStream)
                    bytes = memoryStream.ToArray
                End Using
                Return bytes
            End Function

            <Runtime.CompilerServices.Extension()>
            Public Function GetBytes(str As String, Optional encode As System.Text.Encoding = Nothing) As Byte()
                If encode Is Nothing Then
                    encode = GetDefaultEncoding()
                End If
                Return encode.GetBytes(str)
            End Function

            <Runtime.CompilerServices.Extension()>
            Public Function GetString(bytes As Byte(), Optional encode As System.Text.Encoding = Nothing) As String
                If encode Is Nothing Then
                    encode = GetDefaultEncoding()
                End If
                Return encode.GetString(bytes)
            End Function

            Private Function GetDefaultEncoding() As System.Text.Encoding
                Static encode As New System.Text.UTF8Encoding
                Return encode
            End Function

            <Runtime.CompilerServices.Extension()>
            Private Sub CopyProperties(Of T1, T2)(dest As T1, src As T2)
                Dim srcProps = src.GetType().GetProperties()
                Dim destProps = dest.GetType().GetProperties()
                For Each srcProp In srcProps
                    If srcProp.CanRead Then
                        Dim destProp = destProps.FirstOrDefault(Function(x) x.Name = srcProp.Name)
                        If destProp IsNot Nothing AndAlso destProp.CanWrite Then
                            Dim value = srcProp.GetValue(src, If(srcProp.GetIndexParameters.Count = 1, New Object() {Nothing}, Nothing))
                            destProp.SetValue(dest, value)
                        End If
                    End If
                Next
            End Sub
        End Module

        ''' <summary>
        ''' The response result of a <see cref="System.Net.HttpWebRequest"/> 
        ''' </summary>
        Public Class Response
            Public Property Result As System.Net.HttpWebResponse = Nothing
            Public Property Bytes As Byte() = Nothing
            Public ReadOnly Property Body As String
                Get
                    If _body Is Nothing AndAlso Bytes IsNot Nothing Then
                        _body = Bytes.GetString()
                    End If
                    Return _body
                End Get
            End Property
            Private _body As String = Nothing
        End Class

        ''' <summary>
        ''' Options for the given <see cref="System.Net.HttpWebRequest"/> 
        ''' </summary>
        Public Class Options
            Public Property Headers As New System.Net.WebHeaderCollection
            Public Property Credentials As System.Net.ICredentials = Nothing
            Public Property Connection As String = Nothing
            Public Property KeepAlive As Boolean = True
            Public Property Expect As String = Nothing
            Public Property IfModifiedSince As Date
            Public Property TransferEncoding As String
            Public Property Accept As String = Nothing
            Public Property AllowAutoRedirect As Boolean = True
            Public Property AllowReadStreamBuffering As Boolean = False
            Public Property AllowWriteStreamBuffering As Boolean = True
            Public Property MaximumAutomaticRedirections As Integer = 50
            Public Property MediaType As String = Nothing
            Public Property Pipelined As Boolean = True
            Public Property PreAuthenticate As Boolean = False
            Public Property Referer As String = Nothing
            Public Property SendChunked As Boolean = False
            Public Property UseDefaultCredentials As Boolean = False
            Public Property UserAgent As String = Nothing
            Public Property ContentType As String = Nothing
        End Class

        Public MustInherit Class ContentType
            Public Const ApplicationUrlEncoded As String = "application/x-www-form-urlencoded"
            Public Const ApplicationJson As String = "application/json"
            Public Const TextXml As String = "text/xml"
            Public Const MultipartFormData As String = "multipart/form-data"
        End Class

        Public Enum Method
            [Get]
            Post
            Put
            Patch
            Delete
        End Enum
        
        
    End Namespace
End Namespace ' http://programmingnotes.org/