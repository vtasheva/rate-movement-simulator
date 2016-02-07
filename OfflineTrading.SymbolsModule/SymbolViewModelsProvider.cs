using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule
{
    public class SymbolViewModelsProvider : ISymbolViewModelsProvider
    {
        private readonly IEnumerable<ISymbolConfiguration> _symbolConfigurations;

        public SymbolViewModelsProvider(IEnumerable<ISymbolConfiguration> symbolConfigurations)
        {
            _symbolConfigurations = symbolConfigurations;
        }

        public IEnumerable<ISymbolViewModel> GetSymbolViewModels()
        {
            return _symbolConfigurations.Select(s => new SymbolViewModel(s)).ToList();
        }
    }
}
