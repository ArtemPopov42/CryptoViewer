using CryptoViewer.WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.WPF.Commands
{
    internal class ShowCurrenciesViewCommand : BaseCommand
    {
        private readonly NavigationService _navigationService;

        public ShowCurrenciesViewCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.ShowCurrenciesView();
        }
    }
}
