using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule
{
    public interface ITradingEventsManager
    {
        void Buy(string symbolName, decimal amount, decimal openPositionRate);

        void Sell(PositionItem positionItem);
    }
}
