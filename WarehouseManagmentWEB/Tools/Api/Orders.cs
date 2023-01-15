using RestSharp;

namespace WarehouseManagmentWEB.Tools.Api
{
    public static class Orders
    {
        public static string GetOrders()
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/orders");

            var request = new RestRequest("https://localhost:7145/api/orders", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");
            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            var response = client.Execute(request);

            if (response.Content == null) return string.Empty;

            return response.Content.ToString();
        }
    }
}
