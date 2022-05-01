using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LaserGame_V2_2
{
    public static class Utils
    {
        public static async Task<string> POSTAsync(string _url)
        {
            string url = _url;
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient httpClient = new HttpClient(handler);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            HttpResponseMessage response = httpClient.Send(request);
            string result = response.Content.ReadAsStringAsync().Result;
            return result;

        }
    }
}
