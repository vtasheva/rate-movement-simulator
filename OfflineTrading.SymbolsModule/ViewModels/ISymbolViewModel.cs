using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels
{
    public interface ISymbolViewModel
    {
        ISymbolConfiguration SymbolConfiguration { get; }
        bool IsSelected { get; set; }
    }
}
