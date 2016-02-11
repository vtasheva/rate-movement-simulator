using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Charting.Interfaces;
using Microsoft.Practices.Prism.Commands;
using System.Windows.Input;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels
{
    class SymbolViewModel : NotifyPropertyChangedBase, ISymbolViewModel
    {
        /// <summary>
        /// Gets the symbol configuration.
        /// </summary>
        /// <value>
        /// The symbol configuration.
        /// </value>
        public string SymbolName { get; }

        /// <summary>
        /// Gets the rate movement view model.
        /// </summary>
        /// <value>
        /// The rate movement view model.
        /// </value>
        public IRateMovementViewModel RateMovementViewModel { get; }

        private bool _isVisible;
        /// <summary>
        /// Gets or sets a value indicating whether this instance is visible.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                if (value != _isVisible)
                {
                    _isVisible = value;
                    NotifyPropertyChanged(nameof(IsVisible));
                }
            }
        }

        private ICommand _hideSymbolCommand;
        /// <summary>
        /// Gets the hide symbol command.
        /// </summary>
        /// <value>
        /// The hide symbol command.
        /// </value>
        public ICommand HideSymbolCommand
        {
            get
            {
                if (_hideSymbolCommand == null)
                {
                    _hideSymbolCommand = new DelegateCommand(() => IsVisible = false);
                }

                return _hideSymbolCommand;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymbolViewModel"/> class.
        /// </summary>
        /// <param name="symbolConfiguration">The symbol configuration.</param>
        public SymbolViewModel(string symbolName, IRateMovementViewModel rateMovementViewModel)
        {
            SymbolName = symbolName;
            RateMovementViewModel = rateMovementViewModel;
        }
    }
}
