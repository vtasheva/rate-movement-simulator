using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.RateFeed.Implementations.Waves;
using Internovus.Wpf.Training.RateFeed.Interfaces;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class BlockWaveFuncFactory
    {
        private readonly ApplicationArgs _applicationArgs;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockWaveFuncFactory"/> class.
        /// </summary>
        /// <param name="applicationArgs">The application arguments.</param>
        public BlockWaveFuncFactory(ApplicationArgs applicationArgs)
        {
            _applicationArgs = applicationArgs;
        }

        /// <summary>
        /// Creates new block wave function.
        /// </summary>
        /// <returns></returns>
        public IWaveFunc Create()
        {
            return new BlockWaveFunc(_applicationArgs.InitialRate, _applicationArgs.Amplitude, _applicationArgs.PeriodInMilliseconds);
        }
    }
}
