using Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Implementations
{
    class PositionItemProvider : IPositionItemProvider
    {
        private int nextId = 0;

        public PositionItem Create(string symbolName, decimal amount, decimal openPositionRate)
        {
            nextId++;
            return new PositionItem(nextId, symbolName, amount, openPositionRate);
        }
    }
}
