﻿using Internovus.Wpf.Training.RateFeed.Interfaces;
using System;
using static System.Math;

namespace Internovus.Wpf.Training.RateFeed.Implementations.Waves
{
    public class SineWaveFunc : IWaveFunc
    {
        private readonly decimal _initialRate;
        private readonly decimal _amplitude;
        private readonly int _periodInMilliseconds;

        /// <summary>
        /// Initializes a new instance of the <see cref="SineWaveFunc"/> class.
        /// </summary>
        /// <param name="initialRate">The initial rate.</param>
        /// <param name="amplitude">The amplitude.</param>
        /// <param name="periodInMilliseconds">The period in milliseconds.</param>
        public SineWaveFunc(decimal initialRate, decimal amplitude, int periodInMilliseconds)
        {
            _initialRate = initialRate;
            _amplitude = amplitude;
            _periodInMilliseconds = periodInMilliseconds;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="timeInMilliseconds">The time in milliseconds.</param>
        /// <returns></returns>
        public decimal GetValue(double timeInMilliseconds)
        {
            return _initialRate + _amplitude * Convert.ToDecimal(Sin(2 * PI * timeInMilliseconds / _periodInMilliseconds));
        }
    }
}
