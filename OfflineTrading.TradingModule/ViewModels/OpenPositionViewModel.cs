using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.OfflineTrading.Common.Events;
using Internovus.Wpf.Training.OfflineTrading.Common.Events.Arguments;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using System.Windows;
using System.Windows.Input;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels
{
    class OpenPositionViewModel : NotifyPropertyChangedBase, IOpenPositionViewModel
    {
        private readonly ITradingEventsManager _tradingEventsManager;
        private readonly IEventAggregator _eventAggregator;
        private readonly IUserInfo _userInfo;
        private string _selectedSymbolName;
        private decimal _openRate;

        private decimal _amount;
        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount
        {
            get
            {
                return _amount;
            }
            set {
                if (_amount != value)
                {
                    _amount = value;
                    NotifyPropertyChanged(nameof(Amount));
                    (OpenPosition as DelegateCommand).RaiseCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenPositionViewModel"/> class.
        /// </summary>
        /// <param name="tradingEventsManager">The trading events manager.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        public OpenPositionViewModel(ITradingEventsManager tradingEventsManager, IEventAggregator eventAggregator, IUserInfo userInfo)
        {
            _tradingEventsManager = tradingEventsManager;
            _eventAggregator = eventAggregator;
            _userInfo = userInfo;

            SubscribeToEvents();
        }

        private ICommand _openPosition;
        /// <summary>
        /// Gets the open position.
        /// </summary>
        /// <value>
        /// The open position.
        /// </value>
        public ICommand OpenPosition
        {
            get
            {
                if (_openPosition == null)
                {
                    _openPosition = new DelegateCommand(OpenPositionHandler, CanOpenPosition);
                }

                return _openPosition;
            }
        }

        private void OpenPositionHandler()
        {
            if (Amount * _openRate > _userInfo.CurrentAmount)
            {
                MessageBox.Show($"You don't have enough amount to buy {_selectedSymbolName}");
                return;
            }

            _tradingEventsManager.Buy(_selectedSymbolName, Amount, _openRate);
            Amount = 0;
        }

        private bool CanOpenPosition() => !string.IsNullOrEmpty(_selectedSymbolName) && Amount > 0;

        private void SubscribeToEvents()
        {
            _eventAggregator.GetEvent<RateChanged>().Subscribe(RateChangedHandler);
            _eventAggregator.GetEvent<SelectedSymbolNameChanged>().Subscribe(SelectedSymbolNameChangedHandler);
        }

        private void SelectedSymbolNameChangedHandler(string name)
        {
            _selectedSymbolName = name;
            (OpenPosition as DelegateCommand).RaiseCanExecuteChanged();
        }

        private void RateChangedHandler(RateChangedEventArgs eventArgs)
        {
            if (eventArgs.SymbolName == _selectedSymbolName)
            {
                _openRate = eventArgs.Rate;
            }
        }

    }
}
