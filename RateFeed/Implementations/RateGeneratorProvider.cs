using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Internovus.Wpf.Training.RateFeed.Implementations
{
    public class RateGeneratorProvider : IRateGeneratorProvider
    {
        private readonly IWaveFuncProvider _waveFuncProvider;
        private readonly ApplicationArgs _applicationArgs;
        private readonly Timer _timer;

        public RateGeneratorProvider(IWaveFuncProvider waveFuncProvider, ApplicationArgs applicationArgs, Timer timer)
        {
            _waveFuncProvider = waveFuncProvider;
            _applicationArgs = applicationArgs;
            _timer = timer;
        }

        public IRateGenerator GetRateGenerator()
        {
            var waveFunc = _waveFuncProvider.GetWaveFunc(_applicationArgs.WaveType);

            _timer.Interval = _applicationArgs.StepInMilliseconds;

            return new RateGenerator(waveFunc, _timer);
        }
    }
}
