using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.RateFeed.Constants;
using Internovus.Wpf.Training.RateFeed.Implementations.Waves;
using Internovus.Wpf.Training.RateFeed.Interfaces;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class TriangleWaveFuncFactory : IWaveFuncFactory
    {
        public string WaveType => WaveNames.Triangle;

        /// <summary>
        /// Creates new triangle wave function.
        /// </summary>
        /// <returns></returns>
        public IWaveFunc Create(ISymbolConfiguration symbolConfiguration)
        {
            return new TriangleWaveFunc(symbolConfiguration.InitialRate, symbolConfiguration.Amplitude, symbolConfiguration.PeriodInMilliseconds);
        }
    }
}
