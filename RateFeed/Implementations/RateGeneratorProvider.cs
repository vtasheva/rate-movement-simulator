﻿using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using System.Timers;

namespace Internovus.Wpf.Training.RateFeed.Implementations
{
    public class RateGeneratorProvider : IRateGeneratorProvider
    {
        private readonly IWaveFuncFactoryProvider _waveFuncFactoryProvider;
        private readonly Timer _timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="RateGeneratorProvider"/> class.
        /// </summary>
        /// <param name="waveFuncFactoryProvider">The wave function provider.</param>
        /// <param name="symbolConfiguration">The application arguments.</param>
        /// <param name="timer">The timer.</param>
        public RateGeneratorProvider(IWaveFuncFactoryProvider waveFuncFactoryProvider, Timer timer)
        {
            _waveFuncFactoryProvider = waveFuncFactoryProvider;
            _timer = timer;
        }

        /// <summary>
        /// Gets the rate generator.
        /// </summary>
        /// <returns></returns>
        public IRateGenerator GetRateGenerator(ISymbolConfiguration symbolConfiguration)
        {
            var waveFunc = _waveFuncFactoryProvider.GetWaveFuncFactory(symbolConfiguration.WaveType).Create(symbolConfiguration);

            _timer.Interval = symbolConfiguration.StepInMilliseconds;

            return new RateGenerator(waveFunc, _timer);
        }
    }
}
