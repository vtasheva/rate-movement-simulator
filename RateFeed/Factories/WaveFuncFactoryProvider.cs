using Internovus.Wpf.Training.RateFeed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class WaveFuncFactoryProvider : IWaveFuncFactoryProvider
    {
        private IEnumerable<IWaveFuncFactory> _waveFuncFactories;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaveFuncFactoryProvider"/> class.
        /// </summary>
        /// <param name="waveFuncFactories">The wave function factories.</param>
        public WaveFuncFactoryProvider(IEnumerable<IWaveFuncFactory> waveFuncFactories)
        {
            _waveFuncFactories = waveFuncFactories;
        }

        /// <summary>
        /// Gets the wave function factory.
        /// </summary>
        /// <param name="waveType">Type of the wave.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
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
