using Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces;
using System;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Implementations
{
    class PositionItemProvider : IPositionItemProvider
    {
        private int nextId = 0;

        /// <summary>
        /// Creates the specified symbol name.
        /// </summary>
        /// <param name="symbolName">Name of the symbol.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="openRate">The open position rate.</param>
        /// <returns></returns>
        public IPositionItem Create(string symbolName, decimal amount, decimal openRate)
        {
            nextId++;
            return new PositionItem(nextId, symbolName, amount, DateTime.Now, openRate);
        }
    }
}
