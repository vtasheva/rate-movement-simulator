using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Events;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using System.Windows.Input;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels
{
    class ClosePositionViewModel : NotifyPropertyChangedBase, IClosePositionViewModel
    {
        private readonly ITradingEventsManager _tradingEventsManager;
        private readonly IEventAggregator _eventAggregator;

        private PositionItem _currentPositionItem;
        /// <summary>
        /// Gets the current position item.
        /// </summary>
        /// <value>
        /// The current position item.
        /// </value>
        public PositionItem CurrentPositionItem
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
                    (ClosePosition as DelegateCommand).RaiseCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClosePositionViewModel"/> class.
        /// </summary>
        /// <param name="tradingEventsManager">The trading events manager.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        public ClosePositionViewModel(ITradingEventsManager tradingEventsManager, IEventAggregator eventAggregator)
        {
            _tradingEventsManager = tradingEventsManager;
            _eventAggregator = eventAggregator;

            SubscribeToEvents();
        }

        private ICommand _closePosition;
        /// <summary>
        /// Gets the close position.
        /// </summary>
        /// <value>
        /// The close position.
        /// </value>
        public ICommand ClosePosition
        {
            get
            {
                if (_closePosition == null)
                {
                    _closePosition = new DelegateCommand(ClosePositionHandler, CanClosePosition);
                }

                return _closePosition;
            }
        }

        private void ClosePositionHandler() => _tradingEventsManager.Sell(CurrentPositionItem);

        private bool CanClosePosition() => CurrentPositionItem != null;

        private void SubscribeToEvents()
        {
            _eventAggregator.GetEvent<SelectedPositionChanged>().Subscribe(pi => CurrentPositionItem = pi);
        }
    }
}
