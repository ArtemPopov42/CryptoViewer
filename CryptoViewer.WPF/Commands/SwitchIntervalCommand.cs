using CryptoViewer.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.WPF.Commands
{
    internal class SwitchIntervalCommand:BaseCommand
    {
        private CurrencyDetailsViewModel _viewModel;

        public SwitchIntervalCommand(CurrencyDetailsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            if (parameter is string)
            {
                string interval = parameter as string;
                _viewModel.SelectedInterval = interval;
            }
        }
    }
}
