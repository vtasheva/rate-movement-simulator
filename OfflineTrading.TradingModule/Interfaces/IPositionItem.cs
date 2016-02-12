using System;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces
{
    public interface IPositionItem
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        int Id { get; }

        /// <summary>
        /// Gets the name of the symbol.
        /// </summary>
        /// <value>
        /// The name of the symbol.
        /// </value>
        string SymbolName { get; }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        decimal Amount { get; }

        /// <summary>
        /// Gets the open time.
        /// </summary>
        /// <value>
        /// The open time.
        /// </value>
        DateTime OpenTime { get; }

        /// <summary>
        /// Gets the open rate.
        /// </summary>
        /// <value>
        /// The open rate.
        /// </value>
        decimal OpenRate { get; }

        /// <summary>
        /// Gets or sets the current rate.
        /// </summary>
        /// <value>
        /// The current rate.
        /// </value>
        decimal CurrentRate { get; set; }

        /// <summary>
        /// Gets the profit.
        /// </summary>
        /// <value>
        /// The profit.
        /// </value>
        decimal Profit { get; }
    }
}
