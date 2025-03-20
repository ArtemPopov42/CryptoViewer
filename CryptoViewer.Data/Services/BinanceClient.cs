using CryptoViewer.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.Data.Services
{
    internal class BinanceClient
    {
        private static BinanceClient? _client;
        private HttpClient _httpClient;

        private BinanceClient()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://data-api.binance.vision/api/v3/"),
            };
        }

        public static BinanceClient GetClient()
        {
            if (_client is null)
            {
                _client = new BinanceClient();
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

                throw new HttpClientBadRequestException(response.ReasonPhrase);
            }
        }
    }
}
