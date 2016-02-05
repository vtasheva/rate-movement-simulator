using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    public class ConfigurationReader : IConfigurationReader
    {
        public IEnumerable<Symbol> Read()
        {
            var configuration = (SymbolsConfigurationSection)ConfigurationManager.GetSection("SymbolsConfiguration");

            return configuration.Symbols.Cast<Symbol>();
        }
    }
}
