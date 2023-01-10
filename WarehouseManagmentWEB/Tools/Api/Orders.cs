using RestSharp;

namespace WarehouseManagmentWEB.Tools.Api
{
    public static class Orders
    {
       /* private IConfiguration _configuration { get; set; }
        public Orders(IConfiguration configuration)
        {
            _configuration = configuration;
        }*/
        public static string GetOrders()
        {
            var token = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API")["Token"];

            var client = new RestClient("https://localhost:7145/api/orders");
            var request = new RestRequest("https://localhost:7145/api/orders", Method.Get);
            request.AddHeader("Authorization", token);
            var response = client.Execute(request);

            if (response.Content == null) return string.Empty;

            return response.Content.ToString();
        }
    }
}
