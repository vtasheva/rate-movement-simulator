using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.RateFeed.Constants;
using Internovus.Wpf.Training.RateFeed.Implementations.Waves;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class TriangleWaveFuncFactory
    {
        private readonly ISymbolConfiguration _symbolConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="TriangleWaveFuncFactory"/> class.
        /// </summary>
        /// <param name="symbolConfiguration">The application arguments.</param>
        public TriangleWaveFuncFactory(IEnumerable<ISymbolConfiguration> symbolConfigurations, ISymbolConfiguration defaultConfiguration)
        {
            _symbolConfiguration = symbolConfigurations.FirstOrDefault(c => c.WaveType == WaveNames.Triangle);
            if (_symbolConfiguration == null)
            {
                _symbolConfiguration = defaultConfiguration;
            }
        }

        /// <summary>
        /// Creates new triangle wave function.
        /// </summary>
        /// <returns></returns>
        public IWaveFunc Create()
        {
            return new TriangleWaveFunc(_symbolConfiguration.InitialRate, _symbolConfiguration.Amplitude, _symbolConfiguration.PeriodInMilliseconds);
        }
    }
}
