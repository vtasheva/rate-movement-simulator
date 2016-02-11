using System.Windows.Input;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces
{
    public interface IClosePositionViewModel
    {
        /// <summary>
        /// Gets the close position.
        /// </summary>
        /// <value>
        /// The close position.
        /// </value>
        ICommand ClosePosition { get; }
    }
}
