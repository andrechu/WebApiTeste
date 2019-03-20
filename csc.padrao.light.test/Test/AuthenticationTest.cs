using Autoatendimento.Test.Helper;
using Autoatendimento.Test.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace Autoatendimento.Test.Test
{
    [TestClass]
    public class AuthenticationTest : Test
    {
        [TestInitialize]
        public void Initialize()
        {
            Request = new Dictionary<string, object>();
            Url = "api/authentication/method/";
            User = "ccprofessional2@teste.com.br";
            Password = "*Teste2*";
            SetToken();
        }

        #region [Main Scenario]

        [TestMethod]
        public void FirstLogin_Success()
        {
            //arrange:
            Url = Url.Replace("method", "firstlogin");
            Request.Add("login", "ccprofessional2@teste.com.br");
            Request.Add("password", "*Teste2*");
            Request.Add("confirmpassword", "*Teste2*");
            Request.Add("token", "605B3F0B-6E624C39-BD8609B4-9840B45F-267277");

            //act:
            var result = RequestHelper.SetRequest<UserLoginFirstLoginResponse>(Url, Method.PUT, Request, Token.GetToken);

            //acert:            
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void GetData_Success()
        {
            //arrange:
            Url = Url.Replace("method", "getdata");            

            //act:
            var result = RequestHelper.SetRequest<UserLoginDataBasicResponse>(Url, Method.GET, Request, Token.GetToken);

            //acert:            
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void AlterPassword_Success()
        {
            //arrange:
            Url = Url.Replace("method", "alterpassword");
            Request.Add("id", "1");
            Request.Add("prevpassword", "*Teste233*");
            Request.Add("password", "*Teste23*");
            Request.Add("confirmpassword", "*Teste23*");

            //act:
            var result = RequestHelper.SetRequest<BaseResponse>(Url, Method.PUT, Request, Token.GetToken);

            //acert:            
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void RecoverPasswordByEmail_Success()
        {
            //arrange:
            Url = Url.Replace("method", "recoverpasswordbyemail");
            Request.Add("email", "ccprofessional@teste.com.br");

            //act:
            var result = RequestHelper.SetRequest<BaseResponse>(Url, Method.PUT, Request, Token.GetToken);

            //acert:            
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void GetEmails_ByLogin_Success()
        {
            //arrange:
            Url = Url.Replace("method", "getemailsbylogin");
            Request.Add("login", "ccprofessional@teste.com.br");

            //act:
            var result = RequestHelper.SetRequest<UserLoginResponse>(Url, Method.POST, Request, Token.GetToken);

            //acert:            
            Assert.IsTrue(result.Success && (result.Emails != null && result.Emails.Any()));
        }

        [TestMethod]
        public void CheckToken_Success()
        {
            //arrange:            
            Url = Url.Replace("method", "checktoken/605B3F0B-6E624C39-BD8609B4-9840B45F-267277");

            //act:
            var result = RequestHelper.SetRequest<UserLoginCheckTokenResponse>(Url, Method.GET, Request, Token.GetToken);

            //acert:            
            Assert.IsTrue(result.Success && !string.IsNullOrEmpty(result.Login));
        }

        [TestMethod]
        public void NewPassword_ByToken_Success()
        {
            //arrange:
            Url = Url.Replace("method", "newpassword");
            Request.Add("password", "*Teste23*");
            Request.Add("confirmpassword", "*Teste23*");
            Request.Add("token", "605B3F0B-6E624C39-BD8609B4-9840B45F-267277");

            //act:
            var result = RequestHelper.SetRequest<UserLoginResponse>(Url, Method.PUT, Request, Token.GetToken);

            //acert:            
            Assert.IsTrue(result.Success && !string.IsNullOrEmpty(result.Login));
        }

        [TestMethod]
        public void ListUsers_ByProfileId_Success()
        {
            //arrange:
            Url = Url.Replace("method", "listusersbyprofileid/1");

            //act:
            var result = RequestHelper.SetRequest<ListUserloginResponse>(Url, Method.GET, Request, Token.GetToken);

            //acert:            
            Assert.IsTrue(result.Success && (result.ListUsers != null && result.ListUsers.Any()));
        }

        [TestMethod]
        public void GetUser_ByLogin_Success()
        {
            //arrange:
            Url = Url.Replace("method", "getbylogin");
            Request.Add("login", "ccprofessional@teste.com.br");

            //act:
            var result = RequestHelper.SetRequest<UserResponse>(Url, Method.POST, Request, Token.GetToken);

            //acert:            
            string expectedResult = "ccprofessional@teste.com.br";
            Assert.IsTrue(result.Success && result.Login.Equals(expectedResult));
        }

        [TestMethod]
        public void GetUser_ByRegister_Success()
        {
            //arrange:
            Url = Url.Replace("method", "getbyregister");
            Request.Add("register", "12165482121");

            //act:
            var result = RequestHelper.SetRequest<UserResponse>(Url, Method.POST, Request, Token.GetToken);

            //acert:            
            string expectedResult = "12165482121";
            Assert.IsTrue(result.Success && result.Register.Equals(expectedResult));
        }

        [TestMethod]
        public void GetUser_ByName_Success()
        {
            //arrange:
            Url = Url.Replace("method", "getbyname");
            Request.Add("name", "Client Final 1");

            //act:
            var result = RequestHelper.SetRequest<UserResponse>(Url, Method.POST, Request, Token.GetToken);

            //acert:            
            string expectedResult = "Client Final 1";
            Assert.IsTrue(result.Success && result.Name.Equals(expectedResult));
        }

        [TestMethod]
        public void UpdateProfilesUser_Success()
        {
            //arrange:
            Url = Url.Replace("method", "updateprofileuser");
            Request.Add("userid", "1");
            Request.Add("profilesid[0]", "1");
            Request.Add("profilesid[1]", "4");
            Request.Add("profilesid[2]", "3");

            //act:
            var result = RequestHelper.SetRequest<BaseResponse>(Url, Method.PUT, Request, Token.GetToken);

            //acert:            
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void IsLogged_Success()
        {
            //arrange:
            Url = Url.Replace("method", "islogged");

            //act:
            var result = RequestHelper.SetRequest<BaseResponse>(Url, Method.GET, Request, Token.GetToken);

            //acert:            
            Assert.IsTrue(result.Success);
        }

        #endregion [Main Scenario]
    }
}
