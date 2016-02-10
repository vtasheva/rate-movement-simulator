using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;

namespace Internovus.Wpf.Training.RateFeed.Interfaces
{
    public interface IWaveFuncFactory
    {
        string WaveType { get; }

        IWaveFunc Create(ISymbolConfiguration symbolConfiguration);
    }
}
