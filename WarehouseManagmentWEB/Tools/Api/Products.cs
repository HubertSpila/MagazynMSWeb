using RestSharp;
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
        public static List<ProductModel>? GetAvailableProducts()
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/products");
            var request = new RestRequest("available", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");
            var body = @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            List<ProductModel>? response = client.Execute<List<ProductModel>>(request).Data;

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
            var body = @"{
" + "\n" +
            $@"    ""SKU"": ""{form.SKU}"",
" + "\n" +
            $@"    ""Nazwa_produktu"" : ""{form.Nazwa_produktu}"",
" + "\n" +
            $@"    ""ID_kartonu"" : {form.ID_kartonu},
" + "\n" +
            $@"    ""Stan_magazynowy"" : {form.Stan_magazynowy},
" + "\n" +
            $@"    ""Potrzebna_ilosc"" : 0

" + "\n" +
            @"}";

            request.AddParameter("application/json", body, ParameterType.RequestBody);
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
            var body = @"{
" + "\n" +
            $@"    ""sku"": ""{form.SKU}"",
" + "\n" +
            $@"    ""ilosc"" : {form.Ilosc}
" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(request);

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}