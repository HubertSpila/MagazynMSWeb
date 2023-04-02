﻿using RestSharp;
using System.Net;
using WarehouseManagmentWEB.PostModels;
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
        public static string ImportOrders()
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/");
            var request = new RestRequest("orders/import", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddParameter("application/json", ParameterType.RequestBody);

            string response = client.Execute<string>(request).Data;

            return response;
        }
        public static bool UpdateCarton(UpdateCartonOrderModel form)
        {
            string token = Singleton.TokenWithout();

            var client = new RestClient("https://localhost:7145/api/orders/");
            var request = new RestRequest("update", Method.Put);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
            $@"    ""id_zamowienia"":{form.Id_zamowienia},
" + "\n" +
            $@"    ""id_kartonu"" : {form.Id_kartonu}
" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(request);

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

    }
}
