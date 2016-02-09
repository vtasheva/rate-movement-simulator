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
    public class WaveFuncFactoryProvider : IWaveFuncFactoryProvider
    {
        private IEnumerable<IWaveFuncFactory> _waveFuncFactories;

        public WaveFuncFactoryProvider(IWaveFuncFactory[] waveFuncFactories)
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
