using Internovus.Wpf.Training.OfflineTrading.Common.Events;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels
{
    class OpenPositionViewModel : IOpenPositionViewModel, INotifyPropertyChanged
    {
        private readonly ITradingEventsManager _tradingEventsManager;
        private readonly IEventAggregator _eventAggregator;

        private string _selectedSymbolName;

        private decimal _amount;
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
                }
            }
        }

        public bool CanOpenPosition => !string.IsNullOrEmpty(_selectedSymbolName);

        public OpenPositionViewModel(ITradingEventsManager tradingEventsManager, IEventAggregator eventAggregator)
        {
            _tradingEventsManager = tradingEventsManager;
            _eventAggregator = eventAggregator;

            SubscribeToEvents();
        }

        private ICommand _openPosition;
        public ICommand OpenPosition
        {
            get
            {
                if (_openPosition == null)
                {
                    _openPosition = new DelegateCommand(() => { _tradingEventsManager.Buy(_selectedSymbolName, Amount); Amount = 0; });
                }

                return _openPosition;
            }
        }

        private void SubscribeToEvents()
        {
            _eventAggregator.GetEvent<SelectedSymbolNameChanged>().Subscribe(name =>
            {
                _selectedSymbolName = name;
                NotifyPropertyChanged(nameof(CanOpenPosition));
            });
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
