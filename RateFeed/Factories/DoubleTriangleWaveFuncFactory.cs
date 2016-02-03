using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.RateFeed.Implementations.Waves;
using Internovus.Wpf.Training.RateFeed.Interfaces;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class DoubleTriangleWaveFuncFactory
    {
        private readonly ApplicationArgs _applicationArgs;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleTriangleWaveFuncFactory"/> class.
        /// </summary>
        /// <param name="applicationArgs">The application arguments.</param>
        public DoubleTriangleWaveFuncFactory(ApplicationArgs applicationArgs)
        {
            _applicationArgs = applicationArgs;
        }

        /// <summary>
        /// Creates new double triangle function.
        /// </summary>
        /// <returns></returns>
        public IWaveFunc Create()
        {
            return new DoubleTriangleWaveFunc(_applicationArgs.InitialRate, _applicationArgs.Amplitude, _applicationArgs.PeriodInMilliseconds);
        }
    }
}
