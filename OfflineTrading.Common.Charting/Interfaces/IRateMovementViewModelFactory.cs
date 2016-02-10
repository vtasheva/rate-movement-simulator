using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;

namespace Internovus.Wpf.Training.OfflineTrading.Common.Charting.Interfaces
{
    public interface IRateMovementViewModelFactory
    {
        IRateMovementViewModel Create(ISymbolConfiguration symbolConfiguration);
    }
}
