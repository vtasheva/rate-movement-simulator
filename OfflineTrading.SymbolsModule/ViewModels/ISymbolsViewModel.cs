﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels
{
    public interface ISymbolsViewModel
    {
        IEnumerable<ISymbolViewModel> SymbolViewModels { get; }
        ISymbolViewModel SlectedSymbolViewModel { get; }
    }
}