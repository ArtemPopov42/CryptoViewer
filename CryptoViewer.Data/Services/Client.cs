using CryptoViewer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptoViewer.Data.Services
{
    internal class Client
    {
        private static Client? _client;
        private HttpClient _httpClient;

        private Client()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.coincap.io/v2"),
            };
        }

        public static Client GetClient()
        {
            if (_client == null)
            {
                _client = new Client();
            }
            return _client;
        }
 
        public string GetAsync(string endpoint)
        {
            var responce = _httpClient.GetAsync(endpoint).Result;
            responce.EnsureSuccessStatusCode();

            string responceStr = responce.Content.ReadAsStringAsync().Result;

            return responceStr;
        }

    }
}
