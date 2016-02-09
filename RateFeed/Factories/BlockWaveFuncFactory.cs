using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.RateFeed.Constants;
using Internovus.Wpf.Training.RateFeed.Implementations.Waves;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class BlockWaveFuncFactory : IWaveFuncFactory
    {
        public string WaveType => WaveNames.Block;

        /// <summary>
        /// Creates new block wave function.
        /// </summary>
        /// <returns></returns>
        public IWaveFunc Create(ISymbolConfiguration symbolConfiguration)
        {
            return new BlockWaveFunc(symbolConfiguration.InitialRate, symbolConfiguration.Amplitude, symbolConfiguration.PeriodInMilliseconds);
        }
    }
}
