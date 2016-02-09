using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule
{
    public class OpenPosition
    {
        public string MyProperty { get; set; }

        public string SymbolName { get; set; }

        public decimal Amount { get; set; }

        public DateTime CurrentTime { get; set; }

        public decimal CurrentRate { get; set; }
    }
}
