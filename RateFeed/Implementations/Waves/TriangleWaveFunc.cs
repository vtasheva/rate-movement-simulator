using Internovus.Wpf.Training.RateFeed.Constants;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Internovus.Wpf.Training.RateFeed.Implementations.Waves
{
    public class TriangleWaveFunc : IWaveFunc
    {
        private readonly decimal _initialRate;
        private readonly decimal _amplitude;
        private readonly int _periodInMilliseconds;

        public string WaveName => WaveNames.Triangle;

        public TriangleWaveFunc(decimal initialRate, decimal amplitude, int periodInMilliseconds)
        {
            _initialRate = initialRate;
            _amplitude = amplitude;
            _periodInMilliseconds = periodInMilliseconds;
        }

        public decimal GetValue(double timeInMilliseconds)
        {
            return _initialRate + (2 * _amplitude / Convert.ToDecimal(PI)) * Convert.ToDecimal(Asin(Sin(2 * PI * timeInMilliseconds / _periodInMilliseconds)));
        }
    }
}
