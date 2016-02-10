using Internovus.Wpf.Training.OfflineTrading.TradingModule.Events;
using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule
{
    class TradingEventsManager : ITradingEventsManager
    {
        private IEventAggregator _eventAggregator;
        private IPositionItemProvider _positionItemProvider;

        public TradingEventsManager(IEventAggregator eventAggregator, IPositionItemProvider positionItemProvider)
        {
            _eventAggregator = eventAggregator;
            _positionItemProvider = positionItemProvider;
        }

        public void Buy(string symbolName, decimal amount)
        {
            var positionItem = _positionItemProvider.Create(symbolName, amount);
            _eventAggregator.GetEvent<OpenPosition>().Publish(positionItem);
        }

        public void Sell(PositionItem positionItem)
        {
            _eventAggregator.GetEvent<ClosePosition>().Publish(positionItem);
        }
    }
}
