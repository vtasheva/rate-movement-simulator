using Internovus.Wpf.Training.OfflineTrading.TradingModule.Events;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces;
using Microsoft.Practices.Prism.PubSubEvents;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Implementations
{
    class TradingEventsManager : ITradingEventsManager
    {
        private IEventAggregator _eventAggregator;
        private IPositionItemProvider _positionItemProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="TradingEventsManager"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="positionItemProvider">The position item provider.</param>
        public TradingEventsManager(IEventAggregator eventAggregator, IPositionItemProvider positionItemProvider)
        {
            _eventAggregator = eventAggregator;
            _positionItemProvider = positionItemProvider;
        }

        /// <summary>
        /// Buys the specified symbol name.
        /// </summary>
        /// <param name="symbolName">Name of the symbol.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="openPositionRate">The open position rate.</param>
        public void Buy(string symbolName, decimal amount, decimal openPositionRate)
        {
            var positionItem = _positionItemProvider.Create(symbolName, amount, openPositionRate);
            _eventAggregator.GetEvent<OpenPosition>().Publish(positionItem);
        }

        /// <summary>
        /// Sells the specified position item.
        /// </summary>
        /// <param name="positionItem">The position item.</param>
        public void Sell(PositionItem positionItem)
        {
            _eventAggregator.GetEvent<ClosePosition>().Publish(positionItem);
        }
    }
}
