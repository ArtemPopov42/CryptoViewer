using CryptoViewer.Data.Models;
using CryptoViewer.WPF.ViewModels;
using LiveCharts;
using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoViewer.WPF.Commands
{
    public class ShowChartCommand : BaseAsyncCommand
    {
        CurrencyDetailsViewModel _viewModel;

        public ShowChartCommand(CurrencyDetailsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                if (_viewModel.SelectedSymbol != string.Empty)
                {
                    IEnumerable<Candle>? candles = await _viewModel.CurrencyManager.GetCandlesAsync(_viewModel.SelectedSymbol, _viewModel.SelectedInterval);

                    if (candles is not null)
                    {
                        _viewModel.Series[0].Values.Clear();
                        _viewModel.Labels.Clear();
                        foreach (Candle candle in candles)
                        {
                            _viewModel.Series[0].Values.Add(new OhlcPoint(candle.Open, candle.High, candle.Low, candle.Close));
                            _viewModel.Labels.Add(DateTimeOffset.FromUnixTimeMilliseconds(candle.Timestemp).DateTime.ToString("g"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
