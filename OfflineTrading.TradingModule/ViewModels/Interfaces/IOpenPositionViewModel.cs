using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces
{
    public interface IOpenPositionViewModel
    {
        decimal Amount { get; }

        ICommand OpenPosition { get; }
    }
}
