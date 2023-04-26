using RestSharp;
using System.Net;
using System.Text.Json;
using WarehouseManagmentWEB.PostModels;
using WarehouseManagmentWEB.Tools.Api.Models;

namespace WarehouseManagmentWEB.Tools.Api
{
    public static class Orders
    {
        //Zapytanie do API
        public static List<OrderModel>? GetOrders()
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/");
            var request = new RestRequest("orders", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");
            var body = @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            List<OrderModel>? response = client.Execute<List<OrderModel>>(request).Data;

            return response;
        }
        public static string ImportOrders()
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/");
            var request = new RestRequest("orders/import", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddParameter("application/json", ParameterType.RequestBody);

            string response = client.Execute<string>(request).Data;

            return response;
        }
        public static string WerifyOrder(int id)
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/");
            var request = new RestRequest($"orders/werify/{id}", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddParameter("application/json", ParameterType.RequestBody);

            string response = client.Execute<string>(request).Data;

            return response;
        }
        public static bool UpdateCarton(UpdateCartonOrderModel form)
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/orders/");
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
        public static bool WarehouseOut(WarehouseOutModel form)
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/orders/");
            var request = new RestRequest("warehouseout", Method.Put);
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

    }
}
