using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.WPF.ViewModels
{
    internal class CurrencyDetailViewModel:BaseViewModel
    {
        private CurrencyInfoViewModel _currencyInfoViewModel;
        public CurrencyInfoViewModel CurrencyInfo => _currencyInfoViewModel;

        public CurrencyDetailViewModel(CurrencyInfoViewModel currencyInfoViewModel)
        {
            _currencyInfoViewModel = currencyInfoViewModel;
        }
    }
}
