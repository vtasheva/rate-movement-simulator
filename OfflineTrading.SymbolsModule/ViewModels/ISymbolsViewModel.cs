using System.Collections.Generic;
using System.Windows.Input;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels
{
    public interface ISymbolsViewModel
    {
        /// <summary>
        /// Gets the symbol view models.
        /// </summary>
        /// <value>
        /// The symbol view models.
        /// </value>
        IEnumerable<ISymbolViewModel> SymbolViewModels { get; }

        /// <summary>
        /// Gets the selected symbol view model.
        /// </summary>
        /// <value>
        /// The selected symbol view model.
        /// </value>
        ISymbolViewModel SelectedSymbolViewModel { get; }

        /// <summary>
        /// Gets the close all command.
        /// </summary>
        /// <value>
        /// The close all command.
        /// </value>
        ICommand CloseAllCommand { get; }
    }
}
