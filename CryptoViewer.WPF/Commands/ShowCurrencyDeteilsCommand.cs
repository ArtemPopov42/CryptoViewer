using CryptoViewer.Data.Models;
using CryptoViewer.WPF.Services;
using CryptoViewer.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.WPF.Commands
{
    internal class ShowCurrencyDeteilsCommand : BaseCommand
    {
        private NavigationService _navegationService;
        private Func<string, Currency> _getCurrency;

        public ShowCurrencyDeteilsCommand(NavigationService navegationService, Func<string, Currency> func)
        {
            _navegationService = navegationService;
            _getCurrency = func;
        }

        public override void Execute(object? parameter)
        {
            if (parameter is CurrencyListItemViewModel)
            {
                var currency = new CurrencyInfoViewModel(_getCurrency.Invoke(((CurrencyListItemViewModel)parameter).Id));
                _navegationService.CreateNewCurencyDetailsViewModel(currency);
            }
        }
    }
}
