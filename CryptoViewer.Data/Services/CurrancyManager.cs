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

        public CurrencyManager()
        {
            _client = Client.GetClient();
        }

        public IEnumerable<Currency> GetAssetsAll()
        {
            string responceStr = _client.GetAsync("assets");
            if (responceStr == null || responceStr.Length == 0) {
                throw new Exception("empty responce"); 
            }

            AssetsResponce? responce = Serialaizer.Deserialize<AssetsResponce>(responceStr);

            if(responce is null)
            {
                return new List<Currency>();
            }

            return responce.Data;
        }

        public Currency GetAssetsById(string currencyId)
        {
            string responceStr = _client.GetAsync("assets/" + currencyId);
            if (responceStr == null || responceStr.Length == 0)
            {
                throw new Exception("empty responce");
            }

            AssetsByIdResponce? responce = Serialaizer.Deserialize<AssetsByIdResponce>(responceStr);

            if (responce is null)
            {
                return new Currency();
            }

            return responce.Data;
        }
    }
}
