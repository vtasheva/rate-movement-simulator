using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.App.Config
{
    public class ScreenItemsConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("ScreenItems")]
        [ConfigurationCollection(typeof(ScreenItemsCollection), AddItemName = "add")]
        public ScreenItemsCollection ScreenItems => (ScreenItemsCollection)base["ScreenItems"];
    }
}
