using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels
{
    public class SymbolsViewModel : ISymbolsViewModel
    {
        public IEnumerable<ISymbolViewModel> SymbolViewModels { get; private set; }

        public ISymbolViewModel SlectedSymbolViewModel { get; set; }

        public SymbolsViewModel(IEnumerable<ISymbolViewModel> symbolViewModels)
        {
            SymbolViewModels = symbolViewModels;
        }
    }
}
