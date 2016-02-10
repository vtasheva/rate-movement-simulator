using System;
using System.ComponentModel;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule
{
    public class PositionItem : INotifyPropertyChanged
    {
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
        public DateTime CurrentTime { get; private set; }

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
        public decimal Profit { get { return Math.Round((CurrentRate / OpenPositionRate - 1) * Amount, 2); } }

        public PositionItem(string symbolName, decimal amount, decimal openPositionRate)
        {
            SymbolName = symbolName;
            Amount = amount;
            CurrentTime = DateTime.Now;
            OpenPositionRate = openPositionRate;
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
