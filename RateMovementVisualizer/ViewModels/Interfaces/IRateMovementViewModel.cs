using Internovus.Wpf.Training.OfflineTrading.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.RateMovementVisualizer.ViewModels.Interfaces
{
    public interface IRateMovementViewModel
    {
        ObservableCollection<RatePoint> RatePoints { get; }
    }
}
