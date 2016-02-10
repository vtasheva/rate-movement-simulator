using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces;
using System.Collections.Generic;
using System;
using Microsoft.Practices.Prism.PubSubEvents;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Events;
using System.Collections.ObjectModel;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels
{
    public class OpenedPositionsViewModel : IOpenedPositionsViewModel
    {
        private IEventAggregator _eventAggregator;

        /// <summary>
        /// Gets or sets the opened positions.
        /// </summary>
        /// <value>
        /// The opened positions.
        /// </value>
        public ObservableCollection<PositionItem> OpenedPositions { get; set; }

        public PositionItem SelectedPositionItem { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenedPositionsViewModel"/> class.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        public OpenedPositionsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            OpenedPositions = new ObservableCollection<PositionItem>();

            SubscriptToEvents();
        }

        private void SubscriptToEvents()
        {
            _eventAggregator.GetEvent<OpenPosition>().Subscribe(p => OpenedPositions.Add(p));
            _eventAggregator.GetEvent<ClosePosition>().Subscribe(p => OpenedPositions.Remove(p));
        }
    }
}
