using CryptoViewer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections;

namespace CryptoViewer.Data.Services
{
    public class Client
    {
        private static Client? _client;
        private HttpClient _httpClient;

        private Client()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.coincap.io/v2/"),
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "08eb1791-06ad-456b-8886-6270514d73e4");
        }

        public static Client GetClient()
        {
            if (_client is null)
            {
                _client = new Client();
            }
            return _client;
        }
 
        public async Task<string> GetAsync(string endpoint)
        {
            using (HttpResponseMessage response = await _httpClient.GetAsync(endpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
