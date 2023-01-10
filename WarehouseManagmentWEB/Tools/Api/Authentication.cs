﻿using RestSharp;

namespace WarehouseManagmentWEB.Tools.Api
{
    public static class Authentication
    {
        public static string GetToken()
        {
            RestClient client = new RestClient("https://localhost:7145/api/authentication");
            var request = new RestRequest("https://localhost:7145/api/authentication", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
            @"        ""username"": ""User"",
" + "\n" +
            @"        ""password"": ""user""
" + "\n" +
            @"    }";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(request);

            if (response.Content == null) return String.Empty;

            return response.Content.ToString();
        }
    }
}
