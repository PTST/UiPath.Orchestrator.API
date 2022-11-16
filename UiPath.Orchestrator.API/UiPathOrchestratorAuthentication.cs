using RestSharp;
using PTST.UiPath.Orchestrator.Models;
using System.Text.Json;
using RestSharp.Authenticators;

namespace PTST.UiPath.Orchestrator.API
{
public class UiPathOrchestratorAuthentication : AuthenticatorBase
    {
        readonly string _clientId;
        readonly string _clientSecret;
        readonly string _scope;

        public UiPathOrchestratorAuthentication(string clientId, string clientSecret, string scope) : base("")
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _scope = scope;
        }

        protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
        {
            var token = string.IsNullOrEmpty(Token) ? await GetToken() : Token;
            Token = token;
            return new HeaderParameter(KnownHeaders.Authorization, token);
        }

        internal async Task<string> RefreshToken()
        {
            return await GetToken();
        }

        async Task<string> GetToken()
        {
            RestRequest authRequest = new RestRequest("https://cloud.uipath.com/identity_/connect/token", Method.Post);
            using var client = new RestClient();
            authRequest.AddParameter("grant_type", "client_credentials", ParameterType.GetOrPost);
            authRequest.AddParameter("client_id", this._clientId, ParameterType.GetOrPost);
            authRequest.AddParameter("client_secret", this._clientSecret, ParameterType.GetOrPost);
            authRequest.AddParameter("scope", this._scope, ParameterType.GetOrPost);
            authRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            var response = await client.ExecuteAsync<AuthResponseModel>(authRequest);
            if (!response.IsSuccessful)
            {
                throw new Exception("Failed");
            }
            if (response.Data is null)
            {
                throw new Exception("Failed");
            }
            Token = $"Bearer {response.Data.AccessToken}";
            return Token;
        }

    }
}