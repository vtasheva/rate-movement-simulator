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
        ObservableCollection<PositionItem> OpenedPositions { get; }

        PositionItem SelectedPositionItem { get; set; }
    }
}
