using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Events;
using Internovus.Wpf.Training.OfflineTrading.Common.Events.Arguments;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Events;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces;
using Microsoft.Practices.Prism.PubSubEvents;
using System.Collections.ObjectModel;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels
{
    public class OpenedPositionsViewModel : NotifyPropertyChangedBase, IOpenedPositionsViewModel
    {
        private IEventAggregator _eventAggregator;

        /// <summary>
        /// Gets or sets the opened positions.
        /// </summary>
        /// <value>
        /// The opened positions.
        /// </value>
        public ObservableCollection<PositionItem> OpenedPositions { get; set; }

        private PositionItem _selectedPositionItem;
        /// <summary>
        /// Gets or sets the selected position item.
        /// </summary>
        /// <value>
        /// The selected position item.
        /// </value>
        public PositionItem SelectedPositionItem
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
        /// Initializes a new instance of the <see cref="OpenedPositionsViewModel" /> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public OpenedPositionsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            OpenedPositions = new ObservableCollection<PositionItem>();

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            _eventAggregator.GetEvent<OpenPosition>().Subscribe(p => OpenedPositions.Add(p));
            _eventAggregator.GetEvent<ClosePosition>().Subscribe(p => OpenedPositions.Remove(p));
            _eventAggregator.GetEvent<RateChanged>().Subscribe(RateChangedHandler);
            _eventAggregator.GetEvent<CancelPosition>().Subscribe(p => OpenedPositions.Remove(p));
        }

        private void RateChangedHandler(RateChangedEventArgs eventArgs)
        {
            foreach (var item in OpenedPositions)
            {
                if (item.SymbolName == eventArgs.SymbolName)
                {
                    item.CurrentRate = eventArgs.Rate;
                }
            }
        }
    }
}
