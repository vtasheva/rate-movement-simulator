using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces
{
    public interface IOpenedPositionsViewModel
    {
        /// <summary>
        /// Gets the opened positions.
        /// </summary>
        /// <value>
        /// The opened positions.
        /// </value>
        ObservableCollection<PositionItem> OpenedPositions { get; }

        /// <summary>
        /// Gets or sets the selected position item.
        /// </summary>
        /// <value>
        /// The selected position item.
        /// </value>
        PositionItem SelectedPositionItem { get; set; }
    }
}
