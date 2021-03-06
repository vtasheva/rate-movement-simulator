﻿using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces;
using System;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Implementations
{
    public class PositionItem : NotifyPropertyChangedBase, IPositionItem
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; }

        /// <summary>
        /// Gets or sets the name of the symbol.
        /// </summary>
        /// <value>
        /// The name of the symbol.
        /// </value>
        public string SymbolName { get; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; }

        /// <summary>
        /// Gets or sets the current time.
        /// </summary>
        /// <value>
        /// The current time.
        /// </value>
        public DateTime OpenTime { get; }

        /// <summary>
        /// Gets or sets the open position rate.
        /// </summary>
        /// <value>
        /// The open position rate.
        /// </value>
        public decimal OpenRate { get; }

        private decimal _currentRate;
        public decimal CurrentRate
        {
            get
            {
                return _currentRate;
            }
            set
            {
                if (_currentRate != value)
                {
                    _currentRate = value;
                    NotifyPropertyChanged(nameof(Profit));
                }
            }
        }

        /// <summary>
        /// Gets or sets the current rate.
        /// </summary>
        /// <value>
        /// The current rate.
        /// </value>
        public decimal Profit { get { return (CurrentRate - OpenRate) * Amount; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="PositionItem"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="symbolName">Name of the symbol.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="openRate">The open position rate.</param>
        public PositionItem(int id, string symbolName, decimal amount, DateTime openTime, decimal openRate)
        {
            Id = id;
            SymbolName = symbolName;
            Amount = amount;
            OpenTime = openTime;
            OpenRate = openRate;
        }
    }
}
