using Internovus.Wpf.Training.RateFeed.Constants;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using System;
using static System.Math;

namespace Internovus.Wpf.Training.RateFeed.Implementations
{
    /// <summary>
    /// Class WaveFuncFactory.
    /// </summary>
    public class WaveFuncFactory : IWaveFuncFactory
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// Gets the wave function.
        /// </summary>
        /// <param name="waveType">Type of the wave.</param>
        /// <param name="initialRate">The initial rate.</param>
        /// <param name="amplitude">The amplitude.</param>
        /// <param name="periodInMilliseconds">The period in milliseconds.</param>
        /// <returns>Func<System.Double, System.Decimal> - the wave function.</returns>
        /// <exception cref="ArgumentException">Unknown wave name</exception>
        public Func<double, decimal> GetWaveFunc(string waveType, decimal initialRate, decimal amplitude, int periodInMilliseconds)
        {
            switch (waveType.ToLower())
            {
                case WaveName.Sine:
                    return (double x) => initialRate + amplitude * Convert.ToDecimal(Sin(2 * PI * x / periodInMilliseconds));
                case WaveName.Triangle:
                    return (double x) => initialRate + (2 * amplitude / Convert.ToDecimal(PI)) * Convert.ToDecimal(Asin(Sin(2 * PI * x / periodInMilliseconds)));
                case WaveName.Block:
                    return (double x) => initialRate + amplitude * Convert.ToDecimal(Abs(Sin(2 * PI * x / periodInMilliseconds)) / Sin(2 * PI * x / periodInMilliseconds));
                case WaveName.DoubleTriangle:
                    return (double x) => initialRate + (2 * amplitude / Convert.ToDecimal(PI)) * Convert.ToDecimal(Asin(Sin(4 * PI * x / periodInMilliseconds)) * Sign(Cos(2 * PI * x / periodInMilliseconds)));
                case WaveName.Random:
                    return (double x) => initialRate - amplitude + (Convert.ToDecimal(_random.NextDouble()) * 2 * amplitude);
                default:
                    throw new ArgumentException("Unknown wave name", nameof(waveType));
            }
        }
    }
}
