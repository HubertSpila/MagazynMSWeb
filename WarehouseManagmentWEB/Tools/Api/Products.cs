using RestSharp;
using System.Text.Json;
using WarehouseManagmentWEB.PostModels;
using WarehouseManagmentWEB.Tools.Api.Models;

namespace WarehouseManagmentWEB.Tools.Api
{
    public static class Products
    {
        //Zapytanie do API
        public static List<ProductModel>? GetProducts()
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/");
            var request = new RestRequest("products", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");
            var body = @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            List<ProductModel>? response = client.Execute<List<ProductModel>>(request).Data;

            return response;
        }
        public static List<ProductModel> GetAvailableProducts()
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/products");
            var request = new RestRequest("available", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");
            var body = @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            List<ProductModel>? response = client.Execute<List<ProductModel>>(request).Data;

            if(response == null ) return new List<ProductModel>();

            return response;
        }
        public static bool AddProduct(AddProductModel form)
        {
            string token = Singleton.TokenWithout();



            //-------------------------------------

            var client = new RestClient("https://localhost:7145/api/");
            var request = new RestRequest("products", Method.Post);
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
        public static bool DeleteProduct(string sku)
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/products/");
            var request = new RestRequest($"delete/{sku}", Method.Delete);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("Content-Type", "application/json");

            var response = client.Execute(request);

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        public static bool ChangeProduct(ChangeProductModel form)
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/products/");
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
    }
}