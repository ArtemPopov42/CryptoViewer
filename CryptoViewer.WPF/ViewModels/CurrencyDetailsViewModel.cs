using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoViewer.WPF.ViewModels
{
    public class CurrencyDetailsViewModel:BaseViewModel
    {
        private CurrencyInfoViewModel _currencyInfoViewModel;
        public CurrencyInfoViewModel CurrencyInfo => _currencyInfoViewModel; 

        public CurrencyDetailsViewModel(CurrencyInfoViewModel currencyInfoViewModel)
        {
            _currencyInfoViewModel = currencyInfoViewModel;
        }
    }
}
