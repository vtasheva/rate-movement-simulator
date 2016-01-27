using Internovus.Wpf.Training.RateFeed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Internovus.Wpf.Training.RateFeed
{
    public delegate void OnTickEventHandler(object sender, decimal rate);
    
    public class RateGenerator
    {
        private readonly IWave _waveFunction;
        private readonly Timer _tickTimer;
        private double _elapsedTimeInMilliseconds;

        public RateGenerator(IWave waveFunction, double tickIntervalInMilliseconds)
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

        void TickTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _elapsedTimeInMilliseconds += _tickTimer.Interval;

            if (OnTick != null)
            {
                OnTick(this, _waveFunction.GetValue(_elapsedTimeInMilliseconds));
            }
        }

        public event OnTickEventHandler OnTick;
    }
}
