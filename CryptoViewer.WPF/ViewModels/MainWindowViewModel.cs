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
    public class MainWindowViewModel:BaseViewModel
    {
        private NavigationService _navigationService;

        public BaseViewModel CurrentViewModel => _navigationService.CurrentViewModel;

        public ICommand ShowCurrenciesView { get; }

        public MainWindowViewModel()
        {
            _navigationService = new NavigationService();
            _navigationService.CurrentViewModelChanged += OnCurrentViewModelChanged;

            ShowCurrenciesView = new ShowCurrenciesViewCommand(_navigationService);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
