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
        ObservableCollection<PositionItem> CurrentPositions { get; }

        /// <summary>
        /// Gets or sets the selected position item.
        /// </summary>
        /// <value>
        /// The selected position item.
        /// </value>
        PositionItem SelectedPositionItem { get; set; }
    }
}
