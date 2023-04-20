using RestSharp;
using System.Text.Json;
using WarehouseManagmentWEB.PostModels;
using WarehouseManagmentWEB.Tools.Api.Models;

namespace WarehouseManagmentWEB.Tools.Api
{
    public static class Cartons
    {
        //Zapytanie do API
        public static List<CartonModel> GetCartons()
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/");
            var request = new RestRequest("cartons", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");
            var body = @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            List<CartonModel>? response = client.Execute<List<CartonModel>>(request).Data;

            return response;
        }
        public static CartonModel? GetCarton(int id)
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/");
            var request = new RestRequest($"cartons/{id}", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");
            var body = @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            CartonModel? response = client.Execute<CartonModel>(request).Data;

            return response;
        }

        public static bool ChangeCarton(ChangeCartonModel form)
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/cartons/");
            var request = new RestRequest("update", Method.Put);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("Content-Type", "application/json");
            
            JsonSerializerOptions _jsonSerializaerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            string body = JsonSerializer.Serialize(form, _jsonSerializaerOptions);

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(request);

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        public static bool AddCarton(AddCartonModel form)
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/cartons/");
            var request = new RestRequest("add", Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("Content-Type", "application/json");

            JsonSerializerOptions _jsonSerializaerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            string body = JsonSerializer.Serialize(form, _jsonSerializaerOptions);

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(request);

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        public static bool DeleteCarton(int id)
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/cartons/");
            var request = new RestRequest($"delete/{id}", Method.Delete);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("Content-Type", "application/json");
            
            var response = client.Execute(request);

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
