using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.Data.Models
{
    public class AssetsResponce
    {
        public IEnumerable<Currency> Data { get; set; }
        public long Timestamp { get; set; }
    }

    public class AssetsByIdResponce
    {
        public Currency Data { get; set; }
        public long Timestamp { get; set; }
    }
}
