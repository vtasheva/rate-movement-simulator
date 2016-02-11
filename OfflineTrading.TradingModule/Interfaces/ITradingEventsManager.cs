namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces
{
    public interface ITradingEventsManager
    {
        /// <summary>
        /// Buys the specified symbol name.
        /// </summary>
        /// <param name="symbolName">Name of the symbol.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="openRate">The open position rate.</param>
        void Buy(string symbolName, decimal amount, decimal openRate);

        /// <summary>
        /// Sells the specified position item.
        /// </summary>
        /// <param name="positionItem">The position item.</param>
        void Sell(PositionItem positionItem);
    }
}
