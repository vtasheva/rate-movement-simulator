using Internovus.Wpf.Training.OfflineTrading.TradingModule.Events;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels
{
    class ClosePositionViewModel : IClosePositionViewModel
    {
        private readonly ITradingEventsManager _tradingEventsManager;
        private readonly IEventAggregator _eventAggregator;

        private PositionItem _currentPostionItem;

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
                if (_closePosition != null)
                {
                    _closePosition = new DelegateCommand(() => _tradingEventsManager.Sell(_currentPostionItem));
                }

                return _closePosition;
            }
        }

        private void SubscribeToEvents()
        {
            _eventAggregator.GetEvent<SelectedPositionChanged>().Subscribe(pi => _currentPostionItem = pi);
        }
    }
}
