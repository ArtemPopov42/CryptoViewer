using CryptoViewer.Data.Models;
using CryptoViewer.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoViewer.WPF.Commands
{
    public class LoadMarketsListCommand : BaseAsyncCommand
    {
        private CurrencyDetailsViewModel _viewModel;

        public LoadMarketsListCommand(CurrencyDetailsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try { 
                IEnumerable<Market>? markets = await _viewModel.CurrencyManager.GetAssetMarketsAsync(_viewModel.CurrencyInfo.Id);

                if(markets is not null)
                {
                    _viewModel.Markets.Clear();
                    foreach(MarketViewModel market in markets.Select(m => new MarketViewModel(m)))
                    {
                        _viewModel.Markets.Add(market);
                    }
                }
                _viewModel.SelectedMarket = null;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
}
    }
}
