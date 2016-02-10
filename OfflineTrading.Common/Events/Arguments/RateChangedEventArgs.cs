using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.Common.Events.Arguments
{
    public class RateChangedEventArgs : EventArgs
    {
        public string SymbolName { get; private set; }

        public decimal Rate { get; private set; }

        public RateChangedEventArgs(string symbolName, decimal rate)
        {
            SymbolName = symbolName;
            Rate = rate;
        }
    }
}
