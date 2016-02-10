using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.RateFeed.Constants;
using Internovus.Wpf.Training.RateFeed.Implementations.Waves;
using Internovus.Wpf.Training.RateFeed.Interfaces;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class RandomWaveFuncFactory : IWaveFuncFactory
    {
        public string WaveType => WaveNames.Random;

        /// <summary>
        /// Creates new random wave function.
        /// </summary>
        /// <returns></returns>
        public IWaveFunc Create(ISymbolConfiguration symbolConfiguration)
        {
            return new RandomWaveFunc(symbolConfiguration.InitialRate, symbolConfiguration.Amplitude);
        }
    }
}
