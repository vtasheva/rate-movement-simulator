using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule
{
    public interface ISymbolViewModelsProvider
    {
        IEnumerable<ISymbolViewModel> GetSymbolViewModels();
    }
}
