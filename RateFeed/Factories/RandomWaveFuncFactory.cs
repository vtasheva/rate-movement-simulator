using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.RateFeed.Implementations.Waves;
using Internovus.Wpf.Training.RateFeed.Interfaces;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class RandomWaveFuncFactory
    {
        private readonly ISymbolConfiguration _symbolConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomWaveFuncFactory"/> class.
        /// </summary>
        /// <param name="symbolConfiguration">The application arguments.</param>
        public RandomWaveFuncFactory(ISymbolConfiguration symbolConfiguration)
        {
            _symbolConfiguration = symbolConfiguration;
        }

        /// <summary>
        /// Creates new random wave function.
        /// </summary>
        /// <returns></returns>
        public IWaveFunc Create()
        {
            return new RandomWaveFunc(_symbolConfiguration.InitialRate, _symbolConfiguration.Amplitude);
        }
    }
}
