using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.RateFeed.Implementations.Waves;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class RandomWaveFuncFactory
    {
        private readonly ApplicationArgs _applicationArgs;

        public RandomWaveFuncFactory(ApplicationArgs applicationArgs)
        {
            _applicationArgs = applicationArgs;
        }

        public IWaveFunc Create()
        {
            return new RandomWaveFunc(_applicationArgs.InitialRate, _applicationArgs.Amplitude);
        }
    }
}
