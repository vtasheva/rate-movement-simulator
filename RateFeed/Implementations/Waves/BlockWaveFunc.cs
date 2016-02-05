using Internovus.Wpf.Training.RateFeed.Constants;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using System;
using static System.Math;

namespace Internovus.Wpf.Training.RateFeed.Implementations.Waves
{
    public class BlockWaveFunc : IWaveFunc
    {
        private readonly decimal _initialRate;
        private readonly decimal _amplitude;
        private readonly int _periodInMilliseconds;

        /// <summary>
        /// Gets the name of the wave.
        /// </summary>
        /// <value>
        /// The name of the wave.
        /// </value>
        public string WaveName => WaveNames.Block;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockWaveFunc"/> class.
        /// </summary>
        /// <param name="initialRate">The initial rate.</param>
        /// <param name="amplitude">The amplitude.</param>
        /// <param name="periodInMilliseconds">The period in milliseconds.</param>
        public BlockWaveFunc(decimal initialRate, decimal amplitude, int periodInMilliseconds)
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
            try
            {
                return _initialRate + _amplitude * Convert.ToDecimal(Abs(Sin(2 * PI * timeInMilliseconds / _periodInMilliseconds)) / Sin(2 * PI * timeInMilliseconds / _periodInMilliseconds));
            }
            catch
            {
                return 1;
            }
        }
    }
}
