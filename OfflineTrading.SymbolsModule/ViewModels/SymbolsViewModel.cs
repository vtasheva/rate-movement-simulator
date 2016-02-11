using Internovus.Wpf.Training.OfflineTrading.Common.Events;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using System.Collections.Generic;
using System.Windows.Input;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels
{
    class SymbolsViewModel : ISymbolsViewModel
    {
        private IEventAggregator _eventAggregator;

        /// <summary>
        /// Gets the symbol view models.
        /// </summary>
        /// <value>
        /// The symbol view models.
        /// </value>
        public IEnumerable<ISymbolViewModel> SymbolViewModels { get; }

        /// <summary>
        /// Gets the selected symbol view model.
        /// </summary>
        /// <value>
        /// The selected symbol view model.
        /// </value>
        private ISymbolViewModel _selectedSymbolViewModel;
        public ISymbolViewModel SelectedSymbolViewModel
        {
            get
            {
                return _selectedSymbolViewModel;
            }
            set
            {
                if (_selectedSymbolViewModel != value)
                {
                    _selectedSymbolViewModel = value;
                    _eventAggregator.GetEvent<SelectedSymbolNameChanged>().Publish((_selectedSymbolViewModel != null)? _selectedSymbolViewModel.SymbolName : string.Empty);
                }
            }
        }

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
        public SymbolsViewModel(IEnumerable<ISymbolViewModel> symbolViewModels, IEventAggregator eventAggregator)
        {
            SymbolViewModels = symbolViewModels;
            _eventAggregator = eventAggregator;
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
