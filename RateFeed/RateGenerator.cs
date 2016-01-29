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
        private readonly Timer _tickTimer;
        private double _elapsedTimeInMilliseconds;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RateGenerator"/> class.
        /// </summary>
        /// <param name="waveFunction">The wave function.</param>
        /// <param name="tickIntervalInMilliseconds">The tick interval in milliseconds.</param>
        public RateGenerator(Func<double, decimal> waveFunction, double tickIntervalInMilliseconds)
        {
            _waveFunction = waveFunction;
            _tickTimer = new Timer(tickIntervalInMilliseconds);
            _tickTimer.Elapsed += TickTimer_Elapsed;
        }

        /// <summary>
        /// Starts the wave generator.
        /// </summary>
        public void Start()
        {
            _tickTimer.Start();
        }

        /// <summary>
        /// Stops the wave generator.
        /// </summary>
        public void Stop()
        {
            _tickTimer.Stop();
        }

        /// <summary>
        /// Occurs when the time specified elapses.
        /// </summary>
        public event OnTickEventHandler OnTick;

        private void TickTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _elapsedTimeInMilliseconds += _tickTimer.Interval;

            if (OnTick != null)
            {
                OnTick(this, _waveFunction(_elapsedTimeInMilliseconds));
            }
        }
    }
}
