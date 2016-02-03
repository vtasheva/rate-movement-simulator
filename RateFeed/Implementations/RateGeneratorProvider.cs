using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using System.Timers;

namespace Internovus.Wpf.Training.RateFeed.Implementations
{
    public class RateGeneratorProvider : IRateGeneratorProvider
    {
        private readonly IWaveFuncProvider _waveFuncProvider;
        private readonly ApplicationArgs _applicationArgs;
        private readonly Timer _timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="RateGeneratorProvider"/> class.
        /// </summary>
        /// <param name="waveFuncProvider">The wave function provider.</param>
        /// <param name="applicationArgs">The application arguments.</param>
        /// <param name="timer">The timer.</param>
        public RateGeneratorProvider(IWaveFuncProvider waveFuncProvider, ApplicationArgs applicationArgs, Timer timer)
        {
            _waveFuncProvider = waveFuncProvider;
            _applicationArgs = applicationArgs;
            _timer = timer;
        }

        /// <summary>
        /// Gets the rate generator.
        /// </summary>
        /// <returns></returns>
        public IRateGenerator GetRateGenerator()
        {
            var waveFunc = _waveFuncProvider.GetWaveFunc(_applicationArgs.WaveType);

            _timer.Interval = _applicationArgs.StepInMilliseconds;

            return new RateGenerator(waveFunc, _timer);
        }
    }
}
