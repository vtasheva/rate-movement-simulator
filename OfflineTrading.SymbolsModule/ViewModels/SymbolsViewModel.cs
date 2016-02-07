using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels
{
    class SymbolsViewModel : ISymbolsViewModel
    {
        /// <summary>
        /// Gets the symbol view models.
        /// </summary>
        /// <value>
        /// The symbol view models.
        /// </value>
        public IEnumerable<ISymbolViewModel> SymbolViewModels { get; private set; }

        /// <summary>
        /// Gets the selected symbol view model.
        /// </summary>
        /// <value>
        /// The selected symbol view model.
        /// </value>
        public ISymbolViewModel SelectedSymbolViewModel { get; set; }

        private ICommand _closeAllCommand;
        /// <summary>
        /// Gets the close all command.
        /// </summary>
        /// <value>
        /// The close all command.
        /// </value>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="SymbolsViewModel"/> class.
        /// </summary>
        /// <param name="symbolViewModels">The symbol view models.</param>
        public SymbolsViewModel(IEnumerable<ISymbolViewModel> symbolViewModels)
        {
            SymbolViewModels = symbolViewModels;
        }

        /// <summary>
        /// Creates the close all command.
        /// </summary>
        /// <returns></returns>
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
