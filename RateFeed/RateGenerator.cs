using System;
using System.Timers;

namespace Internovus.Wpf.Training.RateFeed
{
    
    public class RateGenerator
    {
        private readonly Func<double, decimal> _waveFunction;
        private readonly Timer _tickTimer;
        private double _elapsedTimeInMilliseconds;

        public delegate void OnTickEventHandler(object sender, decimal rate);

        public RateGenerator(Func<double, decimal> waveFunction, double tickIntervalInMilliseconds)
        {
            _waveFunction = waveFunction;
            _tickTimer = new Timer(tickIntervalInMilliseconds);
            _tickTimer.Elapsed += TickTimer_Elapsed;
        }

        public void Start()
        {
            _tickTimer.Start();
        }

        public void Stop()
        {
            _tickTimer.Stop();
        }

        private void TickTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _elapsedTimeInMilliseconds += _tickTimer.Interval;

            if (OnTick != null)
            {
                OnTick(this, _waveFunction(_elapsedTimeInMilliseconds));
            }
        }

        public event OnTickEventHandler OnTick;
    }
}
