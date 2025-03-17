using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CryptoViewer.Data.Models;

namespace CryptoViewer.WPF.ViewModels
{
    public class CurrencyListItemViewModel:BaseViewModel
    {
        private Currency _currency;

        public string Id => _currency.Id;
        public string Name => _currency.Name;
        public string Symbol => _currency.Symbol;
        public string Price => _currency.PriceUsd;
        public string Change => _currency.ChangePercent24Hr;

        public CurrencyListItemViewModel(Currency currency)
        {
            _currency = currency;
        }
    }
}
