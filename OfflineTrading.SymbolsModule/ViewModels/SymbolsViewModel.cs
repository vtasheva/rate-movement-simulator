using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels
{
    class SymbolsViewModel : ISymbolsViewModel
    {
        public IEnumerable<ISymbolViewModel> SymbolViewModels { get; private set; }

        public ISymbolViewModel SlectedSymbolViewModel { get; set; }

        private ICommand _closeAllCommand;
        public ICommand CloseAllCommand
        {
            get
            {
                if (_closeAllCommand == null)
                {
                    _closeAllCommand = CreateCloseAllCommand();
                }

                return _closeAllCommand;
            }
        }

        public SymbolsViewModel(IEnumerable<ISymbolViewModel> symbolViewModels)
        {
            SymbolViewModels = symbolViewModels;
        }

        private ICommand CreateCloseAllCommand()
        {
            var command = new CompositeCommand();

            foreach (var symbolViewModel in SymbolViewModels)
            {
                command.RegisterCommand(symbolViewModel.HideSymbolCommand);
            }

            return command;
        }
    }
}
