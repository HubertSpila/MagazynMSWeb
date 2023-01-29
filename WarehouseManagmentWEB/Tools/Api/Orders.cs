using RestSharp;
using System.Net;
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

        public static bool ImportOrders()
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/orders");
            var request = new RestRequest("import", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");
            var body = @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        }
    }
}
