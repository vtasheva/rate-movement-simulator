using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.RateFeed.Implementations.Waves;
using Internovus.Wpf.Training.RateFeed.Interfaces;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class RandomWaveFuncFactory
    {
        private readonly ApplicationArgs _applicationArgs;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomWaveFuncFactory"/> class.
        /// </summary>
        /// <param name="applicationArgs">The application arguments.</param>
        public RandomWaveFuncFactory(ApplicationArgs applicationArgs)
        {
            _applicationArgs = applicationArgs;
        }

        /// <summary>
        /// Creates new random wave function.
        /// </summary>
        /// <returns></returns>
        public IWaveFunc Create()
        {
            return new RandomWaveFunc(_applicationArgs.InitialRate, _applicationArgs.Amplitude);
        }
    }
}
