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
    public class MainWindowViewModel:BaseViewModel
    {
        private NavigationService _navigationService;

        private CurrencyDetailsViewModel? _selectedViewModel;

        public BaseViewModel CurrentViewModel => _navigationService.CurrentViewModel;

        public ObservableCollection<CurrencyDetailsViewModel> CurrencyDetailsViewModels =>_navigationService.CurrencyDetailsViewModels;

        public CurrencyDetailsViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand ShowCurrenciesView { get; }
        public ICommand SwitchToCurrencyDetails { get; }

        public MainWindowViewModel()
        {
            _navigationService = new NavigationService();
            _navigationService.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _navigationService.CurrencyDetailsViewModelsChanged += OnCurrencyDetailsViewModelsChanged;

            _selectedViewModel = null;

            ShowCurrenciesView = new ShowCurrenciesViewCommand(_navigationService);
            SwitchToCurrencyDetails = new SwitchToCurrencyDetailsViewCommand(_navigationService);
        }

        private void OnCurrencyDetailsViewModelsChanged()
        {
            OnPropertyChanged(nameof(CurrencyDetailsViewModels));
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
