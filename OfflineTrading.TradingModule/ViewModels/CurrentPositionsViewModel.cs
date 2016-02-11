using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Events;
using Internovus.Wpf.Training.OfflineTrading.Common.Events.Arguments;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Events;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces;
using Microsoft.Practices.Prism.PubSubEvents;
using System.Collections.ObjectModel;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels
{
    public class CurrentPositionsViewModel : NotifyPropertyChangedBase, ICurrentPositionsViewModel
    {
        private IEventAggregator _eventAggregator;

        /// <summary>
        /// Gets or sets the current positions.
        /// </summary>
        /// <value>
        /// The current positions.
        /// </value>
        public ObservableCollection<IPositionItem> CurrentPositions { get; set; }

        private IPositionItem _selectedPositionItem;
        /// <summary>
        /// Gets or sets the selected position item.
        /// </summary>
        /// <value>
        /// The selected position item.
        /// </value>
        public IPositionItem SelectedPositionItem
        {
            get
            {
                return _selectedPositionItem;
            }
            set
            {
                if (_selectedPositionItem != value)
                {
                    _selectedPositionItem = value;
                    _eventAggregator.GetEvent<SelectedPositionChanged>().Publish(_selectedPositionItem);
                    NotifyPropertyChanged(nameof(SelectedPositionItem));
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentPositionsViewModel" /> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public CurrentPositionsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            CurrentPositions = new ObservableCollection<IPositionItem>();

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            _eventAggregator.GetEvent<OpenPosition>().Subscribe(p => CurrentPositions.Add(p));
            _eventAggregator.GetEvent<ClosePosition>().Subscribe(p => CurrentPositions.Remove(p));
            _eventAggregator.GetEvent<RateChanged>().Subscribe(RateChangedHandler);
            _eventAggregator.GetEvent<CancelPosition>().Subscribe(p => CurrentPositions.Remove(p));
        }

        private void RateChangedHandler(RateChangedEventArgs eventArgs)
        {
            foreach (var item in CurrentPositions)
            {
                if (item.SymbolName == eventArgs.SymbolName)
                {
                    item.CurrentRate = eventArgs.Rate;
                }
            }
        }
    }
}
