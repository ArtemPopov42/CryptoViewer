using CommunityToolkit.Mvvm.ComponentModel;
using CryptoViewer.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.WPF.Services
{
    public class NavigationService
    {
        private BaseViewModel _currentViewModel;

        private ObservableCollection<CurrencyDetailsViewModel> _currencyDetailsViewModels;

        public BaseViewModel CurrentViewModel 
        {
            get => _currentViewModel;
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    OnCurrentViewModelChanged();
                }
            } 
        }

        private CurrenciesViewModel _currenciesViewModel { get; set; }

        public ObservableCollection<CurrencyDetailsViewModel> CurrencyDetailsViewModels 
        { 
            get => _currencyDetailsViewModels;
            set
            {
                _currencyDetailsViewModels = value;
                OnCurrencyDetailsViewModelsChanged();
            }
        }

        public NavigationService()
        {
            _currenciesViewModel = new CurrenciesViewModel(this);
            CurrentViewModel = _currenciesViewModel;
            CurrencyDetailsViewModels = new ObservableCollection<CurrencyDetailsViewModel>();  
        }

        public void CreateNewCurencyDetailsViewModel(CurrencyInfoViewModel currency)
        {
            if (!_currencyDetailsViewModels.Any(c => c.CurrencyInfo.Id == currency.Id))
            {
                CurrencyDetailsViewModel newViewModel = new(currency, this, _currenciesViewModel.CurrencyManager);
                CurrencyDetailsViewModels.Add(newViewModel);
            }
            CurrentViewModel = _currencyDetailsViewModels.First(c => c.CurrencyInfo.Id == currency.Id);
        }

        public void SwitchToCurrencyDetailsView(CurrencyDetailsViewModel viewModel)
        {
            CurrentViewModel = _currencyDetailsViewModels.First(vm => vm == viewModel);
        }

        public void CloseCurrencyDetailsView(CurrencyDetailsViewModel viewModel)
        {
            _currencyDetailsViewModels.Remove(viewModel);
            CurrentViewModel = _currenciesViewModel;
        }
        
        public void ShowCurrenciesView()
        {
            CurrentViewModel = _currenciesViewModel;
        }

        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrencyDetailsViewModelsChanged;

        private void OnCurrencyDetailsViewModelsChanged()
        {
            CurrencyDetailsViewModelsChanged?.Invoke();
        }
    }
}
