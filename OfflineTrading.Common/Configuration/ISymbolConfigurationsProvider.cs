using System.Collections.Generic;

namespace Internovus.Wpf.Training.OfflineTrading.Common.Configuration
{
    public interface ISymbolConfigurationsProvider
    {
        /// <summary>
        /// Gets the configurations.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ISymbolConfiguration> GetConfigurations();
    }
}
