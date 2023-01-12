using RestSharp;

namespace WarehouseManagmentWEB.Tools.Api
{
    public static class Authentication
    {
        public static string GetToken(string login, string password)
        {
            if (login == "" || password == "")
                return string.Empty;

            RestClient client = new RestClient("https://localhost:7145/api/authentication");
            var request = new RestRequest("https://localhost:7145/api/authentication", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
            $@"        ""username"": ""{login}"",
" + "\n" +
            $@"        ""password"": ""{password}""
" + "\n" +
            @"    }";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(request);

            if (response.Content == null) return String.Empty;

            Singleton.Instance.Token = response.Content;
            return response.Content.ToString();
        }
    }
}
