using System.Configuration;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    class SymbolsConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// Gets the symbols.
        /// </summary>
        /// <value>
        /// The symbols.
        /// </value>
        [ConfigurationProperty("Symbols")]
        [ConfigurationCollection(typeof(SymbolsCollection), AddItemName = "add")]
        public SymbolsCollection Symbols => (SymbolsCollection)base["Symbols"];
    }
}
