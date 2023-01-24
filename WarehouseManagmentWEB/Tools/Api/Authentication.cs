using RestSharp;
using WarehouseManagmentWEB.PostModels;
using System.Net;

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
            var body = @"{
" + "\n" +
            $@"        ""username"": ""{form.Login}"",
" + "\n" +
            $@"        ""password"": ""{form.Password}""
" + "\n" +
            @"    }";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(request);

            if (response.Content == null) return string.Empty;

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
