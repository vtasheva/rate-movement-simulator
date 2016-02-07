using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels;
using System.Collections.Generic;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule
{
    interface ISymbolViewModelsProvider
    {
        /// <summary>
        /// Gets the symbol view models.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ISymbolViewModel> GetSymbolViewModels();
    }
}
