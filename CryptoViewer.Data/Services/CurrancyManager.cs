using CryptoViewer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.Data.Services
{
    public class CurrencyManager
    {
        private readonly Client _client;

        private IEnumerable<Currency>? _currencies = null;

        public CurrencyManager()
        {
            _client = Client.GetClient();
        }

        public async Task<IEnumerable<Currency>?> GetCurrenciesAsync()
        {
            _currencies ??= await GetAssetsAll();
            return _currencies;
        }

        public async Task UpdateCurrencies()
        {
            _currencies = await GetAssetsAll();
            OnCurrenciesChanged();

        }

        private async Task<IEnumerable<Currency>?> GetAssetsAll()
        {
            string responceStr = await _client.GetAsync("assets");

            ResponceList<Currency>? responce = Serialaizer.Deserialize<ResponceList<Currency>>(responceStr);

            return responce?.Data;
        }

        public async Task<Currency?> GetAssetsByIdAsync(string currencyId)
        {
            return (await GetCurrenciesAsync())?.First(c => c.Id == currencyId);
        }

        public async Task<IEnumerable<Market>?> GetAssetMarketsAsync(string currencyId)
        {
            string responceStr = await _client.GetAsync("markets?quoteId="+currencyId);

            ResponceList<Market>? responce = Serialaizer.Deserialize<ResponceList<Market>>(responceStr);

            return responce?.Data;
        }

        public event Action CurrenciesChanged;

        private void OnCurrenciesChanged()
        {
            CurrenciesChanged?.Invoke();
        }
    }
}
