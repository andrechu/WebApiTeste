using Autoatendimento.Test.Helper;
using Autoatendimento.Test.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace Autoatendimento.Test.Test
{
    [TestClass]
    public class ServiceTest : Test
    {
        [TestInitialize]
        public void Initialize()
        {
            Request = new Dictionary<string, object>();
            Url = "api/auth/v1/token";
            User = "admin";
            Password = "master@123";
            SetToken();
        }

        #region [Main Scenario]

        [TestMethod]
        public void AllServices_Success()
        {
            //arrange:
            Url = Url.Replace("method", "All");

            //act:
            var result = RequestHelper.SetRequest<ListServicesResponse>(Url, Method.GET, Request, Token.GetToken);

            //acert:    
            Assert.IsTrue(result.Success && (result.Services != null && result.Services.Any()));
        }

        #endregion [Main Scenario]
    }
}
