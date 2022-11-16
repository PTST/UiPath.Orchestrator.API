namespace PTST.UiPath.Orchestrator.API
{
    using RestSharp;
    using PTST.UiPath.Orchestrator.Models;
    using System.Text.Json;
    using RestSharp.Authenticators;
    using System.Text.Json.Serialization;

    public class Orchestrator
    {
        private RestClient Client { get; set; }

        private JsonSerializerOptions JsonSerializerOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public Orchestrator(string baseUrl, string clientId, string clientSecret, string scopes)
        {
            this.Client = new RestClient(baseUrl.TrimEnd('/'))
            {
                Authenticator = new UiPathOrchestratorAuthentication(clientId, clientSecret, scopes)
            };
        }
        public async Task<T> Create<T>(T data, Folder folder) where T : IUipathResponseSingle
        {
            return await this.Create(data, folder.Id);
        }

        public async Task<T> Create<T>(T data, long? folderId = null) where T: IUipathResponseSingle
        {
            var endPoint = TypeToEndPoint[typeof(T)];
            var headers = new Dictionary<string, string>();
            if (folderId.HasValue)
            {
                headers["X-UIPATH-OrganizationUnitId"] = folderId.Value.ToString();
            }
            return await this.ExecuteRequest<T>(Method.Post, endPoint, json: data, headers: headers);
        }

        public async Task<IList<T>> GetAll<T>(Folder folder, string? odataFilter = null) where T : IUipathResponseSingle
        {
            return await this.GetAll<T>(folder.Id, odataFilter: odataFilter);
        }

        public async Task<IList<T>> GetAll<T>(long? folderId = null, string? odataFilter = null) where T : IUipathResponseSingle
        {
            var endPoint = TypeToEndPoint[typeof(T)];
            var headers = new Dictionary<string, string>();
            var parameters = new Dictionary<string, object>
            {
                {"$skip", 0 }
            };

            if (folderId.HasValue)
            {
                headers["X-UIPATH-OrganizationUnitId"] = folderId.Value.ToString();
            }
            if (!string.IsNullOrEmpty(odataFilter))
            {
                parameters["$filter"] = odataFilter;
            }

            var returnList = new List<T>();
            long totalCount;
            
            do
            {
                var respData = await this.ExecuteRequest<UipathResponseMultiple<T>>(Method.Get, endPoint, parameters: parameters, headers: headers);
                returnList.AddRange(respData.Value);
                totalCount = respData.OdataCount;
                parameters["$skip"] = returnList.Count;

            } while (returnList.Count < totalCount);
            return returnList;
        }
        public async Task<T> Get<T>(long id, Folder folder) where T : IUipathResponseSingle
        {
            return await this.Get<T>(id, folder.Id);
        }
        public async Task<T> Get<T>(long id, long? folderId = null) where T : IUipathResponseSingle
        {
            var endPoint = $"{TypeToEndPoint[typeof(T)]}({id})";
            var headers = new Dictionary<string, string>();
            if (folderId.HasValue)
            {
                headers["X-UIPATH-OrganizationUnitId"] = folderId.Value.ToString();
            }
            return await this.ExecuteRequest<T>(Method.Get, endPoint, headers: headers);
        }


        internal async Task<T> ExecuteRequest<T> (Method method, string endPoint, IUipathResponseSingle? json = null, Dictionary<string, object>? parameters = null, Dictionary<string, string>? headers = null)
        {
            var request = new RestRequest(endPoint, method);
            if (json != null)
            {
                request.AddStringBody(JsonSerializer.Serialize(json, json.GetType(), this.JsonSerializerOptions), DataFormat.Json);
            }
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    request.AddParameter(parameter.Key, parameter.Value, ParameterType.UrlSegment);
                }
            }
            if (headers != null)
            {
                request.AddHeaders(headers);
            }
            var response = await Client.ExecuteAsync<T>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                var _ = await ((UiPathOrchestratorAuthentication)this.Client.Authenticator!).RefreshToken();
                return await this.ExecuteRequest<T>(method, endPoint, json, parameters, headers);
            }
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception(response.Content);
            }
            ResponseThrowExtension.ThrowIfError(response);
            return response.Data!;
        }

        private static Dictionary<Type, string> TypeToEndPoint = new()
        {
            {typeof(Folder), "odata/Folders" },
            {typeof(QueueDefinition), "odata/QueueDefinitions" },
            {typeof(QueueItem), "odata/QueueItems"}
        };
    }
}