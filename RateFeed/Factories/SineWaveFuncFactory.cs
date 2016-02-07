using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.RateFeed.Implementations.Waves;
using Internovus.Wpf.Training.RateFeed.Interfaces;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class SineWaveFuncFactory
    {
        private readonly ISymbolConfiguration _symbolConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="SineWaveFuncFactory"/> class.
        /// </summary>
        /// <param name="symbolConfiguration">The application arguments.</param>
        public SineWaveFuncFactory(ISymbolConfiguration symbolConfiguration)
        {
            _symbolConfiguration = symbolConfiguration;
        }

        /// <summary>
        /// Creates new sine wave function.
        /// </summary>
        /// <returns></returns>
        public IWaveFunc Create()
        {
            return new SineWaveFunc(_symbolConfiguration.InitialRate, _symbolConfiguration.Amplitude, _symbolConfiguration.PeriodInMilliseconds);
        }
    }
}
