using Internovus.Wpf.Training.RateFeed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Internovus.Wpf.Training.RateFeed.Waves
{
    public class TriangleWave : IWave
    {
        public decimal InitialRate { get; set; }

        public int PeriodInMilliseconds { get; set; }

        public decimal Amplitude { get; set; }

        public decimal GetValue(double x)
        {
            return InitialRate + (2 * Amplitude / Convert.ToDecimal(PI)) * Convert.ToDecimal(Asin(Sin(2 * PI * x / PeriodInMilliseconds)));
        }
    }
}
