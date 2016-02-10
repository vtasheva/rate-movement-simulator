using Internovus.Wpf.Training.OfflineTrading.Common.Events.Arguments;
using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.Common.Events
{
    public class RateChanged : PubSubEvent<RateChangedEventArgs>
    {
    }
}
