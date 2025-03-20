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
        private readonly CoinCapClient _coinCapClient;
        private readonly BinanceClient _binanceClient;

        private IEnumerable<Currency>? _currencies = null;

        public CurrencyManager()
        {
            _coinCapClient = CoinCapClient.GetClient();
            _binanceClient = BinanceClient.GetClient();
        }

        public async Task<IEnumerable<Currency>?> GetCurrenciesAsync()
        {
            _currencies ??= await GetAssetsAll();
            return _currencies;
        }

        public async Task UpdateCurrencies()
        {
            _currencies = await GetAssetsAll();
        }

        private async Task<IEnumerable<Currency>?> GetAssetsAll()
        {
            string responceStr = await _coinCapClient.GetAsync("assets?limit=10");

            ResponceList<Currency>? responce = Serialaizer.Deserialize<ResponceList<Currency>>(responceStr);

            return responce?.Data;
        }

        public async Task<Currency?> GetAssetsByIdAsync(string currencyId)
        {
            return (await GetCurrenciesAsync())?.First(c => c.Id == currencyId);
        }

        public async Task<IEnumerable<Market>?> GetAssetMarketsAsync(string currencyId)
        {
            string responceStr = await _coinCapClient.GetAsync("markets?baseId="+currencyId+"&limit=30");

            ResponceList<Market>? responce = Serialaizer.Deserialize<ResponceList<Market>>(responceStr);

            return responce?.Data;
        }

        public async Task<IEnumerable<Candle>> GetCandlesAsync(string symbol, string interval = "1m", int candleCount = 50)
        {
            string responceStr = await _binanceClient.GetAsync($"uiKlines?symbol={symbol}&interval={interval}&limit={candleCount}");

            IEnumerable<Candle> responce = Serialaizer.DesirealizeToCandlesFromAnnamedArray(responceStr);

            return responce;
        }
    }
}
