using Internovus.Wpf.Training.RateFeed.Constants;
using System;
using static System.Math;

namespace Internovus.Wpf.Training.RateFeed.Waves
{
    public class WaveFuncFactory
    {
        private readonly Random _random = new Random();

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
                    return (double x) => initialRate + (2 * amplitude / Convert.ToDecimal(PI)) / Convert.ToDecimal(Asin(Sin(4 * PI * x / periodInMilliseconds)) * Sign(Cos(2 * PI * x / periodInMilliseconds)));
                case WaveName.Random:
                    return (double x) => initialRate - amplitude + (Convert.ToDecimal(_random.NextDouble()) * 2 * amplitude);
                default:
                    throw new ArgumentException("Unknown wave name", nameof(waveType));
            }
        }
    }
}
