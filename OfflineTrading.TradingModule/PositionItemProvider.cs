using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule
{
    class PositionItemProvider : IPositionItemProvider
    {
        public PositionItem Create(string symbolName, decimal amount, decimal openPositionRate)
        {
            return new PositionItem(symbolName, amount, openPositionRate);
        }
    }
}
