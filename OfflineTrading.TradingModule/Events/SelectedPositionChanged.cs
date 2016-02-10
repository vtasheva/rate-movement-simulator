using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.PubSubEvents;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Events
{
    class SelectedPositionChanged : PubSubEvent<PositionItem>
    {
    }
}
