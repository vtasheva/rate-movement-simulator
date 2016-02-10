using System;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule
{
    public class OpenPosition
    {
        /// <summary>
        /// Gets or sets the name of the symbol.
        /// </summary>
        /// <value>
        /// The name of the symbol.
        /// </value>
        public string SymbolName { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the current time.
        /// </summary>
        /// <value>
        /// The current time.
        /// </value>
        public DateTime CurrentTime { get; set; }

        /// <summary>
        /// Gets or sets the current rate.
        /// </summary>
        /// <value>
        /// The current rate.
        /// </value>
        public decimal CurrentRate { get; set; }
    }
}
