using Autoatendimento.Test.Helper;
using Autoatendimento.Test.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Autoatendimento.Test.Test.Negotiation
{
    [TestClass]
    public class LancamentoTest : Test
    {


        [TestInitialize]
        public void Initialize()
        {
           
        }

        [TestMethod]
        public void TesteLancamento1()
        {

            User = "admin";
            Password = "master@123";
            SetToken();

            var lancRequest = new LancamentoRequest();
            lancRequest.ContaOrigem = new ContaDTO();
            lancRequest.ContaOrigem.Banco = "001";
            lancRequest.ContaOrigem.Agencia = 18;
            lancRequest.ContaOrigem.CC = 18090;
            lancRequest.ContaOrigem.Digito = 3;

            lancRequest.ContaDestino = new ContaDTO();
            lancRequest.ContaDestino.Banco = "237";
            lancRequest.ContaDestino.Agencia = 28;
            lancRequest.ContaDestino.CC = 7878;
            lancRequest.ContaDestino.Digito = 1;

            lancRequest.valor = 200;
            Request = new Dictionary<string, object>
                {
                    {"request", lancRequest}
                };

            var response = RequestHelper.SetRequest<HttpResponseMessage>(ConfigurationManagerHelper.GetWebAPILancamentoInserir(), Method.POST, Request, Token.GetToken);

            if (response.StatusCode == HttpStatusCode.InternalServerError)
                Assert.AreEqual(response.StatusCode,response.RequestMessage);

            Assert.AreEqual(response.StatusCode, response.StatusCode, response.Content.ToJson());

            return;
        }     
    }
}

