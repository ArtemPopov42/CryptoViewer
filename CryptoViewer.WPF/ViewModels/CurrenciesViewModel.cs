using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using CryptoViewer.Data.Services;
using CryptoViewer.WPF.Commands;
using CryptoViewer.WPF.Services;

namespace CryptoViewer.WPF.ViewModels
{
    public class CurrenciesViewModel:BaseViewModel
    {
        private DispatcherTimer _timer;

        private EventHandler _eventHandler;

        private readonly CurrencyManager _currencyManager;

        private readonly NavigationService _navigationService;

        private CurrencyListItemViewModel? _selectedItem;

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

        public CurrencyListItemViewModel? SelectedItem
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
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 30);
            _eventHandler = new EventHandler(OnTimerTick);
            _timer.Tick += _eventHandler;
            _timer.Start();

            _navigationService = navigationService;
            _currencyManager = new CurrencyManager();
            _currencies = new ObservableCollection<CurrencyListItemViewModel>();

            DisplayedCurrencies = CollectionViewSource.GetDefaultView(Currencies);
            DisplayedCurrencies.Filter = Filter;

            ShowCarrencyDetails = new ShowCurrencyDeteilsViewCommand(_navigationService, this);
            LoadCurrenciesList = new LoadCurrenciesListCommand(this);

            LoadCurrenciesList.Execute(null);
        }

        public void OnTimerTick(object? sender, EventArgs e)
        {
            if (IsActive)
            {
                LoadCurrenciesList.Execute(null);
            }
        }

        private bool Filter(object obj)
        {
            if (obj is CurrencyListItemViewModel item)
            {
                return item.Name.ToLower().Contains(_searchString.ToLower()) || item.Symbol.ToLower().Contains(_searchString.ToLower());
            }
            return false;
        }

        public override void Dispose()
        {
            _timer.Stop();
            _timer.Tick -= _eventHandler;
            _timer = null;
            base.Dispose();
        }
    }
}
