using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces
{
    public interface IPositionItem
    {
        int Id { get; }

        string SymbolName { get; }

        decimal Amount { get; }

        DateTime OpenTime { get; }

        decimal OpenRate { get; }

        decimal CurrentRate { get; set; }

        decimal Profit { get; }
    }
}
