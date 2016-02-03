using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.RateFeed.Implementations.Waves;
using Internovus.Wpf.Training.RateFeed.Interfaces;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class SineWaveFuncFactory
    {
        private readonly ApplicationArgs _applicationArgs;

        /// <summary>
        /// Initializes a new instance of the <see cref="SineWaveFuncFactory"/> class.
        /// </summary>
        /// <param name="applicationArgs">The application arguments.</param>
        public SineWaveFuncFactory(ApplicationArgs applicationArgs)
        {
            _applicationArgs = applicationArgs;
        }

        /// <summary>
        /// Creates new sine wave function.
        /// </summary>
        /// <returns></returns>
        public IWaveFunc Create()
        {
            return new SineWaveFunc(_applicationArgs.InitialRate, _applicationArgs.Amplitude, _applicationArgs.PeriodInMilliseconds);
        }
    }
}
