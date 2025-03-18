using CryptoViewer.Data.Services;
using CryptoViewer.WPF.Commands;
using CryptoViewer.WPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoViewer.WPF.ViewModels
{
    public class CurrencyDetailsViewModel:BaseViewModel
    {
        private readonly NavigationService _navigationService;

        private readonly CurrencyManager _currencyManager;

        private CurrencyViewModel _currencyInfoViewModel;

        private ObservableCollection<MarketViewModel> _markets;

        public ObservableCollection<MarketViewModel> Markets => _markets;

        public CurrencyViewModel CurrencyInfo => _currencyInfoViewModel;

        public CurrencyManager CurrencyManager { get => _currencyManager; }

        public ICommand CloseCurrencyDetailsView { get; }
        public ICommand LoadMarkets { get; }

        public CurrencyDetailsViewModel(CurrencyViewModel currencyInfoViewModel, 
            NavigationService navigationService, 
            CurrencyManager currencyManager)
        {
            _navigationService = navigationService;
            _currencyManager = currencyManager;

            _currencyInfoViewModel = currencyInfoViewModel;
            _markets = new ObservableCollection<MarketViewModel>();

            CloseCurrencyDetailsView = new CloseCurrencyDetailsViewCommand(_navigationService);
            LoadMarkets = new LoadMarketsListCommand(this);

            LoadMarkets.Execute(null);
        }
    }
}
