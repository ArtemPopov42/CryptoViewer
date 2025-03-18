using CryptoViewer.Data.Models;
using CryptoViewer.Data.Services;
using CryptoViewer.WPF.Services;
using CryptoViewer.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CurrencyViewModel currency = new CurrencyViewModel(await _viewModel.CurrencyManager.GetAssetsByIdAsync(_viewModel.SelectedItem.Id));
            _navegationService.CreateNewCurencyDetailsViewModel(currency);
        }
    }
}
