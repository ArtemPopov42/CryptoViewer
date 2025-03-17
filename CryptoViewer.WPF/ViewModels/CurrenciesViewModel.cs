using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CryptoViewer.Data.Services;
using CryptoViewer.WPF.Commands;
using CryptoViewer.WPF.Services;

namespace CryptoViewer.WPF.ViewModels
{
    public class CurrenciesViewModel:BaseViewModel
    {
        private CurrencyManager _currencyManager;
        private readonly NavigationService _navigationService;
        private CurrencyListItemViewModel _selectedItem;
        private ObservableCollection<CurrencyListItemViewModel> _currencies;

        public ObservableCollection<CurrencyListItemViewModel> DisplayedCurrencies
        {
            get => _currencies;
            set
            {
                _currencies = value;
                OnPropertyChanged(nameof(DisplayedCurrencies));
            }
        }

        public CurrencyListItemViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public ICommand ShowCarrencyDetails { get; }

        public CurrenciesViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
            _currencyManager = new CurrencyManager();
            _currencies = new ObservableCollection<CurrencyListItemViewModel>();
            _currencies = new ObservableCollection<CurrencyListItemViewModel>(_currencyManager.GetAssetsAll().Select(c => new CurrencyListItemViewModel(c)));

            ShowCarrencyDetails = new ShowCurrencyDeteilsCommand(_navigationService,_currencyManager.GetAssetsById);
        }
    }
}
