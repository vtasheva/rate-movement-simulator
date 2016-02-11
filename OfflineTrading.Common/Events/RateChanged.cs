using Internovus.Wpf.Training.OfflineTrading.Common.Events.Arguments;
using Microsoft.Practices.Prism.PubSubEvents;

namespace Internovus.Wpf.Training.OfflineTrading.Common.Events
{
    public class RateChanged : PubSubEvent<RateChangedEventArgs>
    {
    }
}
