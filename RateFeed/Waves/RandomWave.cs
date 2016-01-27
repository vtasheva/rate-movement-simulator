using Internovus.Wpf.Training.RateFeed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.RateFeed.Waves
{
    public class RandomWave : IWave
    {
        private static Random random = new Random();

        private decimal _MinValue { get { return InitialRate - Amplitude; } }

        private decimal _MaxValue { get { return InitialRate + Amplitude; } }


        public decimal InitialRate { get; set; }

        public int PeriodInMilliseconds { get; set; }

        public decimal Amplitude { get; set; }

        public decimal GetValue(double x)
        {
            return _MinValue + (Convert.ToDecimal(random.NextDouble()) * (_MaxValue - _MinValue));
        }
    }
}
