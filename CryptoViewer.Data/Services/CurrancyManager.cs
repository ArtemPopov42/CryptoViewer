using CryptoViewer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.Data.Services
{
    public class CurrancyManager
    {
        private readonly Client _client;

        public CurrancyManager()
        {
            _client = Client.GetClient();
        }

        public IEnumerable<Currency> GetAllAssets()
        {
            string responceStr = _client.GetAsync("/assets");
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
    }
}
