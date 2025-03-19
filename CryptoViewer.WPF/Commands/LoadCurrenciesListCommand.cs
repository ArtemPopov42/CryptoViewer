using CryptoViewer.Data.Models;
using CryptoViewer.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoViewer.WPF.Commands
{
    public class LoadCurrenciesListCommand : BaseAsyncCommand
    {
        private CurrenciesViewModel _currenciesViewModel;

        public LoadCurrenciesListCommand(CurrenciesViewModel currenciesViewModel)
        {
            _currenciesViewModel = currenciesViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _currenciesViewModel.CurrencyManager.UpdateCurrencies();
                IEnumerable<Currency>? res = await _currenciesViewModel.CurrencyManager.GetCurrenciesAsync();
                if (res is not null)
                {
                    _currenciesViewModel.Currencies.Clear();
                    foreach (CurrencyListItemViewModel currency in res.Select(c => new CurrencyListItemViewModel(c)))
                    {
                        _currenciesViewModel.Currencies.Add(currency);
                    }
                    _currenciesViewModel.DisplayedCurrencies.Refresh();
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
