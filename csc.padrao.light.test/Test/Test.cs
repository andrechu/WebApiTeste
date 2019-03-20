
using System.Collections.Generic;
using Autoatendimento.Test.Helper;
using Autoatendimento.Test.Response;


namespace Autoatendimento.Test.Test
{
    public class Test
    {
        public Dictionary<string, object> Request { get; set; }
        public string User  { get; set; }
        public string Password { get; set; }
        public TokenResponse Token { get; set; }
        public string Url { get; set; }
        public string UrlIntegrador { get; set; }
       
        public Test() { }

        public Test(TokenResponse token)
        {
            Token = token;
        }

        public void SetToken()
        {
            Token = RequestHelper.GetTokenAuthentication(User, Password);
        }

       

        public void SetMethod(string method)
        {
            Url = Url.Replace("method", method);
        }

        public void SetMethodIntegrador(string method)
        {
            UrlIntegrador = UrlIntegrador.Replace("method", method);
        }
         
    }
}
