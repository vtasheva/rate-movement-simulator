using Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces;
using System.Collections.ObjectModel;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces
{
    public interface ICurrentPositionsViewModel
    {
        /// <summary>
        /// Gets the current positions.
        /// </summary>
        /// <value>
        /// The current positions.
        /// </value>
        ObservableCollection<IPositionItem> CurrentPositions { get; }

        /// <summary>
        /// Gets or sets the selected position item.
        /// </summary>
        /// <value>
        /// The selected position item.
        /// </value>
        IPositionItem SelectedPositionItem { get; set; }
    }
}
