using Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces;

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
        /// <param name="openPositionRate">The open position rate.</param>
        /// <returns></returns>
        public PositionItem Create(string symbolName, decimal amount, decimal openPositionRate)
        {
            nextId++;
            return new PositionItem(nextId, symbolName, amount, openPositionRate);
        }
    }
}
