using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.RateFeed.Implementations.Waves;
using Internovus.Wpf.Training.RateFeed.Interfaces;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class TriangleWaveFuncFactory
    {
        private readonly ISymbolConfiguration _symbolConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="TriangleWaveFuncFactory"/> class.
        /// </summary>
        /// <param name="symbolConfiguration">The application arguments.</param>
        public TriangleWaveFuncFactory(ISymbolConfiguration symbolConfiguration)
        {
            _symbolConfiguration = symbolConfiguration;
        }

        /// <summary>
        /// Creates new triangle wave function.
        /// </summary>
        /// <returns></returns>
        public IWaveFunc Create()
        {
            return new TriangleWaveFunc(_symbolConfiguration.InitialRate, _symbolConfiguration.Amplitude, _symbolConfiguration.PeriodInMilliseconds);
        }
    }
}
