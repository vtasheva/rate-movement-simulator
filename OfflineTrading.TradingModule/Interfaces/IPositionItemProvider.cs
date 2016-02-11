namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces
{
    public interface IPositionItemProvider
    {
        /// <summary>
        /// Creates the specified symbol name.
        /// </summary>
        /// <param name="symbolName">Name of the symbol.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="openRate">The open position rate.</param>
        /// <returns></returns>
        PositionItem Create(string symbolName, decimal amount, decimal openRate);
    }
}
