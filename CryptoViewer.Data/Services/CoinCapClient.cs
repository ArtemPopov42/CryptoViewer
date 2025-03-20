using CryptoViewer.Data.Models;
using CryptoViewer.Data.Exceptions;
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
    public class CoinCapClient
    {
        private static CoinCapClient? _client;
        private HttpClient _httpClient;

        private CoinCapClient()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://rest.coincap.io/v3/"),
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "1122d87bc8adad85d3690f6a90e94800b5b1e24fb927af35b8447f7a849a9445");
        }

        public static CoinCapClient GetClient()
        {
            if (_client is null)
            {
                _client = new CoinCapClient();
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
