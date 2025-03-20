using CryptoViewer.Data.Models;
using CryptoViewer.Data.Services;
using CryptoViewer.WPF.Services;
using CryptoViewer.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoViewer.WPF.Commands
{
    internal class ShowCurrencyDeteilsViewCommand : BaseAsyncCommand
    {
        private NavigationService _navegationService;
        private CurrenciesViewModel _viewModel;

        public ShowCurrencyDeteilsViewCommand(NavigationService navegationService, CurrenciesViewModel currenciesViewModel)
        {
            _navegationService = navegationService;
            _viewModel = currenciesViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (_viewModel.SelectedItem is null)
            {
                MessageBox.Show("Item dont chosen", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                CurrencyViewModel currency = new CurrencyViewModel(await _viewModel.CurrencyManager.GetAssetsByIdAsync(_viewModel.SelectedItem.Id));
                _navegationService.CreateNewCurencyDetailsViewModel(currency);
            }
        }
    }
}
