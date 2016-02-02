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
    public class RandomWaveFunc : IWaveFunc
    {
        private readonly Random _random = new Random();
        private readonly decimal _initialRate;
        private readonly decimal _amplitude;

        private decimal _minValue => _initialRate - _amplitude;
        private decimal _maxValue => _initialRate + _amplitude;

        public string WaveName => WaveNames.Random;

        public RandomWaveFunc(decimal initialRate, decimal amplitude)
        {
            _initialRate = initialRate;
            _amplitude = amplitude;
        }

        public decimal GetValue(double timeInMilliseconds)
        {
            return _minValue + Convert.ToDecimal(_random.NextDouble()) * (_maxValue - _minValue);
        }
    }
}
