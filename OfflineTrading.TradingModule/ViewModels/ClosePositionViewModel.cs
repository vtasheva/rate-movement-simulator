using Internovus.Wpf.Training.OfflineTrading.TradingModule.Events;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces;
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

        public PositionItem CurrentPostionItem { get; private set; }

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

        public bool CanClosePositoin => CurrentPostionItem != null;

        private void SubscribeToEvents()
        {
            _eventAggregator.GetEvent<SelectedPositionChanged>().Subscribe(pi => CurrentPostionItem = pi);
        }
    }
}
