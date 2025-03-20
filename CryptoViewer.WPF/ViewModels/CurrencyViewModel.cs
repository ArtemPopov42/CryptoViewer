using CryptoViewer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.WPF.ViewModels
{
    public class CurrencyViewModel:BaseViewModel
    {
        private Currency _currency;

        public string Id => _currency.Id;
        public string Name => _currency.Name;
        public string Symbol => _currency.Symbol;
        public string Price => _currency.PriceUsd;
        public string MarketCap => _currency.MarketCapUsd;
        public string Change => _currency.ChangePercent24Hr;
        public string Volume => _currency.VolumeUsd24Hr;
        public string Vwap => _currency.Vwap24Hr;
        public string Supply => _currency.Supply;
        public string MaxSupply => _currency.MaxSupply;

        public double PriceDouble => ParceToDouble(Price);
        public double MarketCapDouble => ParceToDouble(MarketCap);
        public double ChangeDouble => ParceToDouble(Change, 5);
        public double VolumeDouble => ParceToDouble(Volume);
        public double VwapDouble => ParceToDouble(Vwap);
        public double SupplyDouble => ParceToDouble(Supply, 1);
        public double MaxSupplyDouble => ParceToDouble(MaxSupply, 1);

        public CurrencyViewModel(Currency currency)
        {
            _currency = currency;
        }

        private double ParceToDouble(string str, int symbols = 3)
        {
            if(str is null || str == string.Empty)
            {
                return 0;
            }
            return Math.Round(double.Parse(str, System.Globalization.CultureInfo.InvariantCulture), symbols);
        }
    }
}
