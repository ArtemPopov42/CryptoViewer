using CryptoViewer.WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CryptoViewer.WPF.ViewModels
{
    public class MainWindowViewModel:BaseViewModel
    {
        private NavigationService _navigationService;

        public BaseViewModel CurrentViewModel 
        { 
            get => _navigationService.CurrentViewModel; 
            set
            {
                _navigationService.CurrentViewModel = value;
                OnPropertyChanged();
            }
        } 

        public MainWindowViewModel()
        {
            _navigationService = new NavigationService(new CurrenciesViewModel());
        }
    }
}
