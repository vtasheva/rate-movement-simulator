using Internovus.Wpf.Training.RateFeed.Interfaces;
using System;
using System.Linq;

namespace Internovus.Wpf.Training.RateFeed.Implementations
{
    public class WaveFuncProvider : IWaveFuncProvider
    {
        private readonly IWaveFunc[] _waveFunctions;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaveFuncProvider"/> class.
        /// </summary>
        /// <param name="waveFunctions">The wave functions.</param>
        public WaveFuncProvider(IWaveFunc[] waveFunctions)
        {
            _waveFunctions = waveFunctions;
        }

        /// <summary>
        /// Gets the wave function.
        /// </summary>
        /// <param name="waveType">Type of the wave.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public IWaveFunc GetWaveFunc(string waveType)
        {
            var waveFunc = _waveFunctions.FirstOrDefault(f => f.WaveName == waveType);

            if (waveFunc == null)
            {
                throw new ArgumentException($"No function with name { waveType } found.");
            }

            return waveFunc;
        }
    }
}
