using RestSharp;
using WarehouseManagmentWEB.PostModels;
using System.Net;
using System.Text.Json;

namespace WarehouseManagmentWEB.Tools.Api
{
    public static class Authentication
    {
        public static string GetToken(LoginModel form)
        {
            //Wysłanie zapytania do API
            RestClient client = new RestClient("https://localhost:7145/api/");
            var request = new RestRequest("authentication", Method.Post);
            request.AddHeader("Content-Type", "application/json");

            JsonSerializerOptions _jsonSerializaerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            string body = JsonSerializer.Serialize(form, _jsonSerializaerOptions);
            
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(request);

            if (response.Content == null) return string.Empty;

            //Sprawdzenie odpowiedzi z API
            if(response.StatusCode == HttpStatusCode.OK)
            {
                Singleton.Instance.Token = response.Content;
                return response.Content.ToString();
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return "Unauthorized";
            }

            return string.Empty;
        }
    }
}
