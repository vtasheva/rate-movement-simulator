using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    public class SymbolsConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("Symbols")]
        [ConfigurationCollection(typeof(SymbolsCollection), AddItemName = "add")]
        public SymbolsCollection Symbols => (SymbolsCollection)base["Symbols"];
    }
}
