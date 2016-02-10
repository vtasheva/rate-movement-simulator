using System;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule
{
    public class PositionItem
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
        /// Gets or sets the current rate.
        /// </summary>
        /// <value>
        /// The current rate.
        /// </value>
        public decimal Profit { get; set; }

        public PositionItem(string symbolName, decimal amount)
        {
            SymbolName = symbolName;
            Amount = amount;
            CurrentTime = DateTime.Now;
        }
    }
}
