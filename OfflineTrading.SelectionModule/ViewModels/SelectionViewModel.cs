using Internovus.Wpf.Training.OfflineTrading.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.SelectionModule.ViewModels
{
    public class SelectionViewModel
    {
        public IEnumerable<Symbol> Symbols { get; private set; }

        public SelectionViewModel(IEnumerable<Symbol> symbols)
        {
            Symbols = symbols;
        }
    }
}
