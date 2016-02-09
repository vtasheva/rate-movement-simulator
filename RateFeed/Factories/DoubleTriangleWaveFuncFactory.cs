using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.RateFeed.Constants;
using Internovus.Wpf.Training.RateFeed.Implementations.Waves;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class DoubleTriangleWaveFuncFactory : IWaveFuncFactory
    {
        public string WaveType => WaveNames.DoubleTriangle;

        /// <summary>
        /// Creates new double triangle function.
        /// </summary>
        /// <returns></returns>
        public IWaveFunc Create(ISymbolConfiguration symbolConfiguration)
        {
            return new DoubleTriangleWaveFunc(symbolConfiguration.InitialRate, symbolConfiguration.Amplitude, symbolConfiguration.PeriodInMilliseconds);
        }
    }
}
