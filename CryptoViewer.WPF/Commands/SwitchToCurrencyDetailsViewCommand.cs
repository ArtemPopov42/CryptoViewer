using CryptoViewer.WPF.Services;
using CryptoViewer.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.WPF.Commands
{
    internal class SwitchToCurrencyDetailsViewCommand : BaseCommand
    {
        private readonly NavigationService _navigationService;

        public SwitchToCurrencyDetailsViewCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            if(parameter is CurrencyDetailsViewModel viewModel)
            {
                _navigationService.SwitchToCurrencyDetailsView(viewModel);
            }
        }
    }
}
