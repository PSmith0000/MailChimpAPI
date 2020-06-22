using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace ChimpAPI.Core
{
    internal class Network
    {
        private static HttpClient HttpClient = new HttpClient();

        internal static HttpResponseMessage MakeRequest(string apikey, string region, string RequestUri, Type Jsontype, string Method = "GET", object CONTENT = null)
        {
            HttpRequestMessage msg = new HttpRequestMessage();

            msg.Method = new HttpMethod(Method);
            msg.RequestUri = new Uri($"https://{region}.api.mailchimp.com/3.0/" + RequestUri);
            msg.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("anystring:" + apikey)));
            if(CONTENT != null)
            {
                string json = JsonConvert.SerializeObject(CONTENT);
                msg.Content = new StringContent(json);
            }
            var r = HttpClient.SendAsync(msg).Result;
            return r;
        }
    }
}
