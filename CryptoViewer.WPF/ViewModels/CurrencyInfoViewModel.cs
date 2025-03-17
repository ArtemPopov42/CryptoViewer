using CryptoViewer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.WPF.ViewModels
{
    internal class CurrencyInfoViewModel
    {
        private Currency _currency;

        public string Name => _currency.Name;
        public string Symbol => _currency.Symbol;
        public string Price => _currency.PriceUsd;
        public string Change => _currency.ChangePercent24Hr;
        public string Volume => _currency.VolumeUsd24Hr;
        public string Vwap => _currency.Vwap24Hr;
        public string Supply => _currency.Supply;
        public string MaxSupply => _currency.MaxSupply;

        public CurrencyInfoViewModel(Currency currency)
        {
            _currency = currency;
        }
    }
}
