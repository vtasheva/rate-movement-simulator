using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.RateFeed.Constants;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class WaveFuncFactoryProvider
    {
        public IWaveFuncFactory GetWaveFuncFactory(ISymbolConfiguration symbolConfiguration)
        {
            switch (symbolConfiguration.WaveType)
            {
                case WaveNames.Sine:
                    return new SineWaveFuncFactory(symbolConfiguration);
                case WaveNames.Triangle:
                    return new TriangleWaveFuncFactory(symbolConfiguration);
                case WaveNames.DoubleTriangle:
                    return new DoubleTriangleWaveFuncFactory(symbolConfiguration);
                case WaveNames.Block:
                    return new BlockWaveFuncFactory(symbolConfiguration);
                case WaveNames.Random:
                    return new RandomWaveFuncFactory(symbolConfiguration);
                default:
                    throw new Exception($"No WaveFuncFactory for { symbolConfiguration.WaveType } wave type exists.");
            }
        }
    }
}
