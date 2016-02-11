using System.Windows.Input;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces
{
    public interface IOpenPositionViewModel
    {
        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        decimal Amount { get; }

        /// <summary>
        /// Gets the open position.
        /// </summary>
        /// <value>
        /// The open position.
        /// </value>
        ICommand OpenPosition { get; }
    }
}
