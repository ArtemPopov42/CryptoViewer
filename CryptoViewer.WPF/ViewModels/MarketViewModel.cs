using CryptoViewer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.WPF.ViewModels
{
    public class MarketViewModel:BaseViewModel
    {
        private Market _market;

        public string Name => _market.ExchangeId;
        public string BaseId => _market.BaseId;
        public string QuteId => _market.QuoteId;
        public string BaseSymbol => _market.BaseSymbol;
        public string QuoteSymbol => _market.QuoteSymbol;
        public string Volume => _market.VolumeUsd24Hr;
        public string Price => _market.PriceUsd;
        public string Symbol => _market.BaseSymbol + _market.QuoteSymbol;

        public double PriceDouble => ParceToDouble(Price);
        public double VolumeDouble => ParceToDouble(Volume);

        public DateTime Timestamp => DateTimeOffset.FromUnixTimeMilliseconds(_market.Updated).DateTime;

        public MarketViewModel(Market market)
        {
            _market = market;
        }

        private double ParceToDouble(string str, int symbols = 3)
        {
            if (str is null || str == string.Empty)
            {
                return 0;
            }
            return Math.Round(double.Parse(str, System.Globalization.CultureInfo.InvariantCulture), symbols);
        }
    }
}
