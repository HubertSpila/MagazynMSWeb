using RestSharp;
using WarehouseManagmentWEB.Tools.Api.Models;

namespace WarehouseManagmentWEB.Tools.Api
{
    public static class Cartons
    {
        //Zapytanie do API
        public static List<CartonModel>? GetCartons()
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
    }
}
