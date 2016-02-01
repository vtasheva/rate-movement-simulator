using Internovus.Wpf.Training.OfflineTrading.Common;
using System;
using System.Timers;

namespace Internovus.Wpf.Training.RateFeed
{
    /// <summary>
    /// Class RateGenerator.
    /// </summary>
    public class RateGenerator : IRateGenerator
    {
        private readonly Func<double, decimal> _waveFunction;
        private readonly Timer _rateFeedTimer;
        private double _elapsedTimeInMilliseconds;

        /// <summary>
        /// Initializes a new instance of the <see cref="RateGenerator"/> class.
        /// </summary>
        /// <param name="waveFunction">The wave function.</param>
        /// <param name="tickIntervalInMilliseconds">The tick interval in milliseconds.</param>
        public RateGenerator(Func<double, decimal> waveFunction, Timer rateFeedTimer)
        {

            _waveFunction = waveFunction;
            _rateFeedTimer = rateFeedTimer;
        }

        /// <summary>
        /// Starts the wave generator.
        /// </summary>
        public void Start()
        {
            _rateFeedTimer.Elapsed += TickTimer_Elapsed;
            _rateFeedTimer.Start();
        }

        /// <summary>
        /// Stops the wave generator.
        /// </summary>
        public void Stop()
        {
            _rateFeedTimer.Stop();
            _rateFeedTimer.Elapsed -= TickTimer_Elapsed;
        }

        /// <summary>
        /// Occurs when the time specified elapses.
        /// </summary>
        public event OnTickEventHandler OnTick;

        private void TickTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _elapsedTimeInMilliseconds += _rateFeedTimer.Interval;
            var currentRate = _waveFunction(_elapsedTimeInMilliseconds);
            OnTick?.Invoke(this, new RatePoint(_elapsedTimeInMilliseconds, currentRate));
        }
    }
}
