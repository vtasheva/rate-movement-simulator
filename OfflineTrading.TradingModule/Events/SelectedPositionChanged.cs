﻿using Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces;
using Microsoft.Practices.Prism.PubSubEvents;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Events
{
    class SelectedPositionChanged : PubSubEvent<IPositionItem>
    {
    }
}
