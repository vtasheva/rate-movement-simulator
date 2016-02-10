using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule
{
    public interface IPositionItemProvider
    {
        PositionItem Create(string symbolName, decimal amount, decimal openPositionRate);
    }
}
