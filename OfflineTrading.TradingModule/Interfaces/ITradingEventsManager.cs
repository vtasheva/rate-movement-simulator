using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces
{
    public interface ITradingEventsManager
    {
        /// <summary>
        /// Buys the specified symbol name.
        /// </summary>
        /// <param name="symbolName">Name of the symbol.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="openPositionRate">The open position rate.</param>
        void Buy(string symbolName, decimal amount, decimal openPositionRate);

        /// <summary>
        /// Sells the specified position item.
        /// </summary>
        /// <param name="positionItem">The position item.</param>
        void Sell(PositionItem positionItem);
    }
}
