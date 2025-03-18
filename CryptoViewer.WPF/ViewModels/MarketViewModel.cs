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

        public MarketViewModel(Market market)
        {
            _market = market;
        }
    }
}
