using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.RateFeed.Implementations.Waves;
using Internovus.Wpf.Training.RateFeed.Interfaces;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class TriangleWaveFuncFactory
    {
        private readonly ApplicationArgs _applicationArgs;

        /// <summary>
        /// Initializes a new instance of the <see cref="TriangleWaveFuncFactory"/> class.
        /// </summary>
        /// <param name="applicationArgs">The application arguments.</param>
        public TriangleWaveFuncFactory(ApplicationArgs applicationArgs)
        {
            _applicationArgs = applicationArgs;
        }

        /// <summary>
        /// Creates new triangle wave function.
        /// </summary>
        /// <returns></returns>
        public IWaveFunc Create()
        {
            return new TriangleWaveFunc(_applicationArgs.InitialRate, _applicationArgs.Amplitude, _applicationArgs.PeriodInMilliseconds);
        }
    }
}
