using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedditBulkSub_api
{
    public class RedditOauth
    {
        private static readonly System.Net.Http.HttpClient client = new HttpClient();
        private string _appId;
        private string _appSecret;

        // constructor
        public RedditOauth(string applicationId, string applicationSecret)
        {
            this._appId = applicationId;
            this._appSecret = applicationSecret;
        }

        async public Task<RedditResponse> authAsync(string username, string password)
        {
            string crap = _appId + ":" + _appSecret;

            var values = new Dictionary<string, string>
           {
               { "grant_type", "password"},
               {"username", username},
               {"password", password}
           };

            var content = new System.Net.Http.FormUrlEncodedContent(values);

            string authBase64 = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(crap));

            // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "MFQ2OUZnaV9pU084Vmc6czBWbmdrWFp6UjRVS2xVYlJQekxaRFZBU3VR");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authBase64);
            var response = await client.PostAsync("https://www.reddit.com/api/v1/access_token", content);

            string strRes = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<RedditResponse>(strRes);
        }
    }
}
