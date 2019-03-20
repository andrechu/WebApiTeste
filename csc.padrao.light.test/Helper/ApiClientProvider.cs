using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Autoatendimento.Test.Helper
{
    public class ApiClientProvider
    {
        private readonly string _hostUri;

        public string AccessToken { get; private set; }

        public ApiClientProvider(string hostUri)
        {
            _hostUri = hostUri;
        }

        public async Task<string> GetToken(string userName, string password)
        {
            HttpResponseMessage response;

            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password)
            };

            var content = new FormUrlEncodedContent(pairs);

            using (var client = new HttpClient())
            {
                var tokenEndpoint = new Uri(new Uri(_hostUri), "Token");
                response = await client.PostAsync(tokenEndpoint, content);
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(string.Format("Error: {0}", responseContent));
            }

            return GetTokenDictionary(responseContent)["access_token"];
        }


        private Dictionary<string, string> GetTokenDictionary(string responseContent)
        {
            var tokenDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
            return tokenDictionary;
        }
    }
}
