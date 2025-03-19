using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using CryptoViewer.Data.Services;
using CryptoViewer.WPF.Commands;
using CryptoViewer.WPF.Services;

namespace CryptoViewer.WPF.ViewModels
{
    public class CurrenciesViewModel:BaseViewModel
    {
        private readonly CurrencyManager _currencyManager;

        private readonly NavigationService _navigationService;

        private CurrencyListItemViewModel _selectedItem;

        private ObservableCollection<CurrencyListItemViewModel> _currencies;

        private string _searchString = string.Empty;

        public CurrencyManager CurrencyManager { get => _currencyManager; }

        public ICollectionView DisplayedCurrencies { get; set; }

        public string SearchString
        {
            get => _searchString; 
            set 
            { 
                _searchString = value;
                OnPropertyChanged(nameof(SearchString));
                DisplayedCurrencies.Refresh();
            }
        }

        public ObservableCollection<CurrencyListItemViewModel> Currencies
        {
            get => _currencies;
            set
            {
                _currencies = value;
                OnPropertyChanged(nameof(Currencies));
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
        public ICommand LoadCurrenciesList { get; }

        public CurrenciesViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
            _currencyManager = new CurrencyManager();
            _currencies = new ObservableCollection<CurrencyListItemViewModel>();

            DisplayedCurrencies = CollectionViewSource.GetDefaultView(Currencies);
            DisplayedCurrencies.Filter = Filter;

            ShowCarrencyDetails = new ShowCurrencyDeteilsViewCommand(_navigationService, this);
            LoadCurrenciesList = new LoadCurrenciesListCommand(this);

            LoadCurrenciesList.Execute(null);
        }

        private bool Filter(object obj)
        {
            if (obj is CurrencyListItemViewModel item)
            {
                return item.Name.ToLower().Contains(_searchString.ToLower()) || item.Symbol.ToLower().Contains(_searchString.ToLower());
            }
            return false;
        }
    }
}
