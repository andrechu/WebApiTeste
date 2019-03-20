using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Autoatendimento.Test.Response;
using RestSharp;

namespace Autoatendimento.Test.Helper
{
    public static class RequestHelper
    {
        public static T SetRequest<T>(string urlParcial, Method requestMethod, Dictionary<string, object> dadosEnviados, string token, string address = null)
            where T : new()
        {
            var restClient =new RestClient(string.IsNullOrWhiteSpace(address) ? ConfigurationManagerHelper.GetWebAPIAddress() : address);
            var restRequest = new RestRequest(urlParcial, requestMethod);

            restRequest.AddHeader("Authorization", token);

            switch (requestMethod)
            {
                case Method.PUT:
                case Method.POST:
                    if (dadosEnviados.Count == 1 && dadosEnviados.ContainsKey(""))
                    {
                        restRequest.RequestFormat = DataFormat.Json;
                        restRequest.AddJsonBody(dadosEnviados[""]);
                    }
                    else
                    {
                        foreach (var dado in dadosEnviados)
                            restRequest.AddParameter(dado.Key, dado.Value, ParameterType.GetOrPost);
                    }
                    break;
                case Method.GET:
                    foreach (var dado in dadosEnviados)
                    {
                        restRequest.AddQueryParameter(dado.Key, (dado.Value == null) ? "" : dado.Value.ToString());
                    }
                    break;
            }

            var response = restClient.Execute<T>(restRequest);
           
            return response.Data;
        }
        
        public static TokenResponse GetTokenAuthentication(string username, string password)
        {
            var restClient = new RestClient(ConfigurationManagerHelper.GetWebAPIAddress());
            var restRequest = new RestRequest("api/auth/v1/token", Method.POST);
            restRequest.AddParameter("grant_type", "password");
            restRequest.AddParameter("username", username);
            restRequest.AddParameter("password", password);

            var response = restClient.Execute<TokenResponse>(restRequest);
            return response.Data;
        }
    }

    //public static class RequestHelperIntegrador
    //{
    //    public static dynamic SetRequest(string urlParcial, Method requestMethod, Dictionary<string, object> dadosEnviados, string token, string address = null)
    //    {
    //        var restClient = new RestClient(string.IsNullOrWhiteSpace(address) ? ConfigurationManagerHelper.GetWebAPIAddressIntegrador() : address);
    //        var restRequest = new RestRequest(urlParcial, requestMethod);

    //        restRequest.AddHeader("Authorization", token);

    //        switch (requestMethod)
    //        {
    //            case Method.PUT:
    //            case Method.POST:
    //                if (dadosEnviados.Count == 1 && dadosEnviados.ContainsKey(""))
    //                {
    //                    restRequest.RequestFormat = DataFormat.Json;
    //                    restRequest.AddJsonBody(dadosEnviados[""]);
    //                }
    //                else
    //                {
    //                    foreach (var dado in dadosEnviados)
    //                        restRequest.AddParameter(dado.Key, dado.Value, ParameterType.GetOrPost);
    //                }
    //                break;
    //            case Method.GET:
    //                foreach (var dado in dadosEnviados)
    //                {
    //                    restRequest.AddQueryParameter(dado.Key, (dado.Value == null) ? "" : dado.Value.ToString());
    //                }
    //                break;
    //        }

    //        var response = restClient.Execute(restRequest);

    //        //if (response.StatusCode != HttpStatusCode.OK || string.IsNullOrEmpty(response.Content))

    //        return response.Content.FromJson<dynamic>();
    //    }

    //    public static TokenResponse GetTokenAuthentication(string username, string password)
    //    {
    //        var restClient = new RestClient(ConfigurationManagerHelper.GetWebAPIAddressIntegrador());
    //        var restRequest = new RestRequest("api/auth/v1/token", Method.POST);
    //        restRequest.AddParameter("grant_type", "password");
    //        restRequest.AddParameter("username", username);
    //        restRequest.AddParameter("password", password);

    //        var response = restClient.Execute<TokenResponse>(restRequest);
    //        return response.Data;
    //    }
    //}
}
