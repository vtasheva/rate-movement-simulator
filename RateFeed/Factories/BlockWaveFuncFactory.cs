using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.RateFeed.Constants;
using Internovus.Wpf.Training.RateFeed.Implementations.Waves;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Internovus.Wpf.Training.RateFeed.Factories
{
    public class BlockWaveFuncFactory
    {
        private readonly ISymbolConfiguration _symbolConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockWaveFuncFactory"/> class.
        /// </summary>
        /// <param name="symbolConfiguration">The application arguments.</param>
        public BlockWaveFuncFactory(IEnumerable<ISymbolConfiguration> symbolConfigurations, ISymbolConfiguration defaultConfiguration)
        {
            _symbolConfiguration = symbolConfigurations.FirstOrDefault(c => c.WaveType == WaveNames.Random);

            if (_symbolConfiguration == null)
            {
                _symbolConfiguration = defaultConfiguration;
            }
        }

        /// <summary>
        /// Creates new block wave function.
        /// </summary>
        /// <returns></returns>
        public IWaveFunc Create()
        {
            return new BlockWaveFunc(_symbolConfiguration.InitialRate, _symbolConfiguration.Amplitude, _symbolConfiguration.PeriodInMilliseconds);
        }
    }
}
