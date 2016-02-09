using Internovus.Wpf.Training.RateFeed.Constants;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using System;

namespace Internovus.Wpf.Training.RateFeed.Implementations.Waves
{
    public class RandomWaveFunc : IWaveFunc
    {
        private readonly Random _random = new Random();
        private readonly decimal _initialRate;
        private readonly decimal _amplitude;

        private decimal _minValue => _initialRate - _amplitude;
        private decimal _maxValue => _initialRate + _amplitude;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomWaveFunc"/> class.
        /// </summary>
        /// <param name="initialRate">The initial rate.</param>
        /// <param name="amplitude">The amplitude.</param>
        public RandomWaveFunc(decimal initialRate, decimal amplitude)
        {
            _initialRate = initialRate;
            _amplitude = amplitude;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="timeInMilliseconds">The time in milliseconds.</param>
        /// <returns></returns>
        public decimal GetValue(double timeInMilliseconds)
        {
            return _minValue + Convert.ToDecimal(_random.NextDouble()) * (_maxValue - _minValue);
        }
    }
}
