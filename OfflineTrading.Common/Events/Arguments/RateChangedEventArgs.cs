using System;

namespace Internovus.Wpf.Training.OfflineTrading.Common.Events.Arguments
{
    public class RateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the name of the symbol.
        /// </summary>
        /// <value>
        /// The name of the symbol.
        /// </value>
        public string SymbolName { get; private set; }

        /// <summary>
        /// Gets the rate.
        /// </summary>
        /// <value>
        /// The rate.
        /// </value>
        public decimal Rate { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RateChangedEventArgs"/> class.
        /// </summary>
        /// <param name="symbolName">Name of the symbol.</param>
        /// <param name="rate">The rate.</param>
        public RateChangedEventArgs(string symbolName, decimal rate)
        {
            SymbolName = symbolName;
            Rate = rate;
        }
    }
}
