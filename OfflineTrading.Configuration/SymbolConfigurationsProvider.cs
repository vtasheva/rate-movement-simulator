using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    class SymbolConfigurationsProvider : ISymbolConfigurationsProvider
    {
        /// <summary>
        /// Gets the configurations.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ISymbolConfiguration> GetConfigurations()
        {
            var configuration = (SymbolsConfigurationSection)ConfigurationManager.GetSection("SymbolsConfiguration");

            return configuration.Symbols.Cast<SymbolConfiguration>();
        }
    }
}
