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
        public CurrenciesViewModel CurrenciesViewModel { get; set; }
        public ObservableCollection<CurrencyDetailsViewModel> CurrencyDetailsViewModels { get; set; }

        public NavigationService()
        {
            CurrenciesViewModel = new CurrenciesViewModel(this);
            CurrentViewModel = CurrenciesViewModel;
            CurrencyDetailsViewModels = new ObservableCollection<CurrencyDetailsViewModel>();  
        }

        public void CreateNewCurencyDetailsViewModel(CurrencyInfoViewModel currency)
        {
            CurrencyDetailsViewModel newViewModel = new(currency);
            CurrentViewModel = newViewModel;
            CurrencyDetailsViewModels.Add(newViewModel);
        }

        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
