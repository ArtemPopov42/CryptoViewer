using CryptoViewer.Data.Services;
using CryptoViewer.WPF.Commands;
using CryptoViewer.WPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Text.RegularExpressions;

namespace CryptoViewer.WPF.ViewModels
{
    public class CurrencyDetailsViewModel:BaseViewModel
    {
        private DispatcherTimer _timer;

        private DispatcherTimer _dinamicIntervalTimer;

        private EventHandler _timerEventHandler;

        private EventHandler _dinamicIntervalTimerEventHandler;

        private readonly NavigationService _navigationService;

        private readonly CurrencyManager _currencyManager;

        private CurrencyViewModel _currencyViewModel;

        private ObservableCollection<MarketViewModel> _markets;

        private MarketViewModel? _selectedMarket; 

        private SeriesCollection _series;

        private ObservableCollection<string> _labels;

        private string _selectedSymbol;

        private string _selectedInterval;

        public SeriesCollection Series
        {
            get => _series;
            set
            {
                _series = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Labels
        {
            get => _labels;
            set
            {
                _labels = value;
                OnPropertyChanged();
            }
        }

        public MarketViewModel? SelectedMarket
        {
            get => _selectedMarket;
            set
            {
                _selectedMarket = value;
                SelectedSymbol = _selectedMarket?.Symbol ?? "";
                OnPropertyChanged(nameof(SelectedMarket));
            }
        }

        public string SelectedSymbol { 
            get => _selectedSymbol; 
            set
            {
                if (value is not null && value != string.Empty)
                {
                    if (_selectedSymbol != value)
                    {
                        _selectedSymbol = value;
                        OnPropertyChanged(nameof(SelectedSymbol));
                    }
                }
            }
        }

        public string SelectedInterval
        {
            get => _selectedInterval;
            set
            {
                _selectedInterval = value;
                _dinamicIntervalTimer.Interval = ParceTimeSpan(value);
                ShowChart.Execute(null);
            }
        }

        public ObservableCollection<MarketViewModel> Markets => _markets;

        public CurrencyViewModel CurrencyInfo => _currencyViewModel;

        public CurrencyManager CurrencyManager { get => _currencyManager; }

        public ICommand CloseCurrencyDetailsView { get; }
        public ICommand LoadMarkets { get; }
        public ICommand ShowChart { get; }
        public ICommand SwitchInterval { get; }

        public CurrencyDetailsViewModel(CurrencyViewModel currencyViewModel, 
            NavigationService navigationService, 
            CurrencyManager currencyManager)
        {
            _navigationService = navigationService;
            _currencyManager = currencyManager;

            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 30);
            _timerEventHandler = new EventHandler(OnTimerTick);
            _timer.Tick += _timerEventHandler;
            _timer.Start();

            _dinamicIntervalTimer = new DispatcherTimer();
            _dinamicIntervalTimer.Interval = TimeSpan.FromMinutes(1);
            _dinamicIntervalTimerEventHandler = new EventHandler(OnDinamicIntervalTimerTick);
            _dinamicIntervalTimer.Tick += _dinamicIntervalTimerEventHandler;
            _dinamicIntervalTimer.Start();

            _currencyViewModel = currencyViewModel;
            _markets = new ObservableCollection<MarketViewModel>();

            _selectedSymbol = string.Empty;
            _selectedInterval = "1m";

            Series = new SeriesCollection()
            {
                new CandleSeries()
                {
                    Values = new ChartValues<OhlcPoint>()
                } 
            };
            Labels = new ObservableCollection<string>();

            CloseCurrencyDetailsView = new CloseCurrencyDetailsViewCommand(_navigationService);
            LoadMarkets = new LoadMarketsListCommand(this);
            ShowChart = new ShowChartCommand(this);
            SwitchInterval = new SwitchIntervalCommand(this);

            LoadMarkets.Execute(null);
            ShowChart.Execute(null);
        }

        public void OnTimerTick(object? sender, EventArgs e)
        {
            if (IsActive)
            {
                LoadMarkets.Execute(null);
            }
        }

        private void OnDinamicIntervalTimerTick(object? sender, EventArgs e)
        {
            if (IsActive)
            {
                ShowChart.Execute(null);
            }
        }

        public override void Dispose()
        {
            _timer.Stop();
            _timer.Tick -= _timerEventHandler;
            _timer = null;

            _dinamicIntervalTimer.Stop();
            _dinamicIntervalTimer.Tick -= _dinamicIntervalTimerEventHandler;
            _dinamicIntervalTimer = null;

            base.Dispose();
        }

        private TimeSpan ParceTimeSpan(string str)
        {
            Match match = Regex.Match(str, @"(\d+)([smhd])");

            if (!match.Success)
                throw new Exception("cannot parce timeSpan");

            int interval = int.Parse(match.Groups[1].Value);
            string symbol = match.Groups[2].Value;

            TimeSpan res = symbol switch
            {
                "s" => TimeSpan.FromSeconds(interval),
                "m" => TimeSpan.FromMinutes(interval),
                "h" => TimeSpan.FromHours(interval),
                "d" => TimeSpan.FromDays(interval),
                _ => throw new Exception("unallowd interval symbol")
            };

            return res;

        }
    }
}
