using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    public class SymbolsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new SymbolConfiguration();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SymbolConfiguration)element).Name;
        }
    }
}
