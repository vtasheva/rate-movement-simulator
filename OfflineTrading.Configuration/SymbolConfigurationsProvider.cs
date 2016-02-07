using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    class SymbolConfigurationsProvider : ISymbolConfigurationsProvider
    {
        public IEnumerable<ISymbolConfiguration> GetConfigurations()
        {
            var configuration = (SymbolsConfigurationSection)ConfigurationManager.GetSection("SymbolsConfiguration");

            return configuration.Symbols.Cast<SymbolConfiguration>();
        }
    }
}
