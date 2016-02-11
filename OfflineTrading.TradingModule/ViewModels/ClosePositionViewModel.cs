using Internovus.Wpf.Training.OfflineTrading.TradingModule.Events;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces;
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
    class ClosePositionViewModel : IClosePositionViewModel, INotifyPropertyChanged
    {
        private readonly ITradingEventsManager _tradingEventsManager;
        private readonly IEventAggregator _eventAggregator;

        private PositionItem _currentPositionItem;
        public PositionItem CurrentPostionItem
        {
            get
            {
                return _currentPositionItem;
            }
            private set
            {
                if (_currentPositionItem != value)
                {
                    _currentPositionItem = value;
                    NotifyPropertyChanged(nameof(CanClosePosition));
                }
            }
        }

        public ClosePositionViewModel(ITradingEventsManager tradingEventsManager, IEventAggregator eventAggregator)
        {
            _tradingEventsManager = tradingEventsManager;
            _eventAggregator = eventAggregator;

            SubscribeToEvents();
        }

        private ICommand _closePosition;
        public ICommand ClosePosition
        {
            get
            {
                if (_closePosition == null)
                {
                    _closePosition = new DelegateCommand(() =>
                    {
                        _tradingEventsManager.Sell(CurrentPostionItem);
                    });
                }

                return _closePosition;
            }
        }

        public bool CanClosePosition => CurrentPostionItem != null;

        private void SubscribeToEvents()
        {
            _eventAggregator.GetEvent<SelectedPositionChanged>().Subscribe(pi => CurrentPostionItem = pi);
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
