using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CryptoViewer.Data.Services;

namespace CryptoViewer.WPF.ViewModels
{
    public class CurrenciesViewModel:BaseViewModel
    {
        private CurrencyManager _currencyManager;

        private ObservableCollection<CurrencyListItemViewModel> _currencies;

        public IEnumerable<CurrencyListItemViewModel> Currencies => _currencies;

        public CurrenciesViewModel()
        {
            _currencyManager = new CurrencyManager();
            _currencies = new ObservableCollection<CurrencyListItemViewModel>(_currencyManager.GetAllAssets().Select(c => new CurrencyListItemViewModel(c)));
        }
    }
}
