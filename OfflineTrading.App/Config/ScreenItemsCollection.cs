using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.App.Config
{
    public class ScreenItemsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ScreenItem();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ScreenItem)element).Name;
        }
    }
}
