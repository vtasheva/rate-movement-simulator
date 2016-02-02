using Internovus.Wpf.Training.RateFeed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.RateFeed.Implementations
{
    public class WaveFuncProvider : IWaveFuncProvider
    {
        private readonly IWaveFunc[] _waveFunctions;

        public WaveFuncProvider(IWaveFunc[] waveFunctions)
        {
            _waveFunctions = waveFunctions;
        }

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
