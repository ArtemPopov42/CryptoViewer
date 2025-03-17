using CryptoViewer.Data.Services;
using CryptoViewer.WPF.Commands;
using CryptoViewer.WPF.Services;
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
        private readonly NavigationService _navigationService;
        private CurrencyInfoViewModel _currencyInfoViewModel;
        private CurrencyManager _currencyManager;
        public CurrencyInfoViewModel CurrencyInfo => _currencyInfoViewModel;

        public ICommand CloseCurrencyDetailsView { get; }

        public CurrencyDetailsViewModel(CurrencyInfoViewModel currencyInfoViewModel, 
            NavigationService navigationService, 
            CurrencyManager currencyManager)
        {
            _currencyInfoViewModel = currencyInfoViewModel;
            _navigationService = navigationService;
            _currencyManager = currencyManager;

            CloseCurrencyDetailsView = new CloseCurrencyDetailsViewCommand(_navigationService);
        }
    }
}
