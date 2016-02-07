using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule
{
    class SymbolViewModelsProvider : ISymbolViewModelsProvider
    {
        private readonly IEnumerable<ISymbolConfiguration> _symbolConfigurations;

        /// <summary>
        /// Initializes a new instance of the <see cref="SymbolViewModelsProvider"/> class.
        /// </summary>
        /// <param name="symbolConfigurations">The symbol configurations.</param>
        public SymbolViewModelsProvider(IEnumerable<ISymbolConfiguration> symbolConfigurations)
        {
            _symbolConfigurations = symbolConfigurations;
        }

        /// <summary>
        /// Gets the symbol view models.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ISymbolViewModel> GetSymbolViewModels()
        {
            return _symbolConfigurations.Select(s => new SymbolViewModel(s)).ToList();
        }
    }
}
