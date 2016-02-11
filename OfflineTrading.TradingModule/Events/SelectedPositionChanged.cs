using Microsoft.Practices.Prism.PubSubEvents;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Events
{
    class SelectedPositionChanged : PubSubEvent<PositionItem>
    {
    }
}
