using Internovus.Wpf.Training.OfflineTrading.Common;
using System;
using System.ComponentModel;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule
{
    public class PositionItem : NotifyPropertyChangedBase
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; private set; }

        /// <summary>
        /// Gets or sets the name of the symbol.
        /// </summary>
        /// <value>
        /// The name of the symbol.
        /// </value>
        public string SymbolName { get; private set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; private set; }

        /// <summary>
        /// Gets or sets the current time.
        /// </summary>
        /// <value>
        /// The current time.
        /// </value>
        public DateTime OpenTime { get; private set; }

        /// <summary>
        /// Gets or sets the open position rate.
        /// </summary>
        /// <value>
        /// The open position rate.
        /// </value>
        public decimal OpenPositionRate { get; private set; }

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
        public decimal Profit { get { return (CurrentRate - OpenPositionRate) * Amount; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="PositionItem"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="symbolName">Name of the symbol.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="openPositionRate">The open position rate.</param>
        public PositionItem(int id, string symbolName, decimal amount, DateTime openTime, decimal openPositionRate)
        {
            Id = id;
            SymbolName = symbolName;
            Amount = amount;
            OpenTime = openTime;
            OpenPositionRate = openPositionRate;
        }
    }
}
