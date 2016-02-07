using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.RateFeed.Implementations.Waves;
using Internovus.Wpf.Training.RateFeed.Interfaces;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class DoubleTriangleWaveFuncFactory
    {
        private readonly ISymbolConfiguration _symbolConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleTriangleWaveFuncFactory"/> class.
        /// </summary>
        /// <param name="symbolConfiguration">The application arguments.</param>
        public DoubleTriangleWaveFuncFactory(ISymbolConfiguration symbolConfiguration)
        {
            _symbolConfiguration = symbolConfiguration;
        }

        /// <summary>
        /// Creates new double triangle function.
        /// </summary>
        /// <returns></returns>
        public IWaveFunc Create()
        {
            return new DoubleTriangleWaveFunc(_symbolConfiguration.InitialRate, _symbolConfiguration.Amplitude, _symbolConfiguration.PeriodInMilliseconds);
        }
    }
}
