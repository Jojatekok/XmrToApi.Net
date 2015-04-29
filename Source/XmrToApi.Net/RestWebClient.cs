using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace Jojatekok.XmrToAPI
{
    static class RestWebClient
    {
        internal static readonly HttpClientHandler HttpClientHandler;
        private static readonly HttpClient HttpClient;

        private static readonly JsonSerializer JsonSerializer = new JsonSerializer();
        private static readonly Encoding EncodingUtf8 = Encoding.UTF8;

        static RestWebClient()
        {
            HttpClientHandler = new HttpClientHandler();
            if (HttpClientHandler.SupportsAutomaticDecompression) {
                HttpClientHandler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            }

            if (HttpClientHandler.SupportsProxy) {
                var proxy = XmrToClient.Proxy;

                HttpClientHandler.Proxy = proxy;
                HttpClientHandler.UseProxy = proxy != null;
            }

            HttpClient = new HttpClient(HttpClientHandler) {
                Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite)
            };

            HttpClient.DefaultRequestHeaders.ExpectContinue = false;
        }

        public static T Get<T>(string command)
        {
            var jsonString = SendRequest(HttpMethod.Get, command);
            return JsonSerializer.DeserializeObject<T>(jsonString);
        }

        public static T Post<T>(string command, object postData)
        {
            var jsonString = SendRequest(HttpMethod.Post, command, JsonSerializer.SerializeObject(postData));
            return JsonSerializer.DeserializeObject<T>(jsonString);
        }

        private static string SendRequest(HttpMethod requestMethod, string requestRelativeUri, string requestContent = null)
        {
            using (var requestMessage = new HttpRequestMessage(requestMethod, new Uri(Utilities.ApiUrlHttpsBase + requestRelativeUri + "/"))) {
                if (requestContent != null) {
                    requestMessage.Content = new StringContent(requestContent, EncodingUtf8, "application/json");
                }

                var response = HttpClient.SendAsync(requestMessage).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
