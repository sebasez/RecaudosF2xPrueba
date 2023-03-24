using Recaudo.ConsultaRecaudo.Entities;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Recaudo.ConsultaRecaudo
{
    public class RecuadoClient
    {
        public readonly IRestClient _client;
        public RecuadoClient()
        {
            _client = new RestClient(CreateHttpClient());
            
        }
        public async Task<LoginResponse> Login()
        {
            var request = new RestRequest("/api/Login", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var user = new
            {
                userName = "user",
                password = "1234"
            };
            request.AddBody(user, ContentType.Json);
            var result = await _client.ExecuteAsync(request);
            LoginResponse tokenResponse = JsonSerializer.Deserialize<LoginResponse>(json: result.Content);
            return tokenResponse;
        }

        private static RestClientOptions CreateHttpClient()
        {
            return new RestClientOptions("http://23.102.103.53:5200")
            {
                MaxTimeout = -1,
            };
        }
    }
}
