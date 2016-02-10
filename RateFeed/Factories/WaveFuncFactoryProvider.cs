using Internovus.Wpf.Training.RateFeed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class WaveFuncFactoryProvider : IWaveFuncFactoryProvider
    {
        private IEnumerable<IWaveFuncFactory> _waveFuncFactories;

        public WaveFuncFactoryProvider(IEnumerable<IWaveFuncFactory> waveFuncFactories)
        {
            _waveFuncFactories = waveFuncFactories;
        }

        public IWaveFuncFactory GetWaveFuncFactory(string waveType)
        {
            var waveFuncFactory = _waveFuncFactories.FirstOrDefault(f => f.WaveType == waveType);

            if (waveFuncFactory == null)
            {
                throw new ArgumentException($"No wave with name \"{ waveType }\" found.");
            }

            return waveFuncFactory;
        }
    }
}
