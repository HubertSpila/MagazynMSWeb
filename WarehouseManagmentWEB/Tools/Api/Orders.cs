using RestSharp;
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
    }
}
