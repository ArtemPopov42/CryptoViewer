using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CryptoViewer.WPF.ViewModels
{
    public class MainWindowViewModel:BaseViewModel
    {
        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel 
        { 
            get => _currentViewModel; 
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        } 

        public MainWindowViewModel()
        {
            _currentViewModel = new CurrenciesViewModel();
        }
    }
}
