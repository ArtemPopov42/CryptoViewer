using CryptoViewer.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.WPF.Services
{
    internal class NavigationService
    {
        public BaseViewModel CurrentViewModel { get; set; }
        public CurrenciesViewModel CurrenciesViewModel { get; set; }
        public ObservableCollection<BaseViewModel> CurrencyDetailsViewModels { get; set; }

        public NavigationService(CurrenciesViewModel currenciesViewModel)
        {
            CurrenciesViewModel = currenciesViewModel;
            CurrentViewModel = CurrenciesViewModel;
            CurrencyDetailsViewModels = new ObservableCollection<BaseViewModel>();  
        }
    }
}
