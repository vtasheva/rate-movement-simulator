using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces;
using System.Collections.Generic;
using System;
using Microsoft.Practices.Prism.PubSubEvents;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Events;
using System.Collections.ObjectModel;
using Internovus.Wpf.Training.OfflineTrading.Common.Events;
using System.ComponentModel;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels
{
    public class OpenedPositionsViewModel : IOpenedPositionsViewModel, INotifyPropertyChanged
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

            _eventAggregator.GetEvent<ClosePosition>().Subscribe(p =>
            {
                OpenedPositions.Remove(p);
            });

            _eventAggregator.GetEvent<RateChanged>().Subscribe(args =>
            {
                foreach (var item in OpenedPositions)
                {
                    if (item.SymbolName == args.SymbolName)
                    {
                        item.CurrentRate = args.Rate;
                    }
                }
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
