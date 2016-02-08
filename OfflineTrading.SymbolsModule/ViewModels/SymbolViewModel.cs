using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel;
using System.Windows.Input;
using Internovus.Wpf.Training.OfflineTrading.Common.Charting;
using System;
using Internovus.Wpf.Training.OfflineTrading.Common.Charting.ViewModels;
using Internovus.Wpf.Training.RateFeed.Implementations;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using Internovus.Wpf.Training.OfflineTrading.Common.Charting.Interfaces;
using Microsoft.Practices.Unity;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels
{
    class SymbolViewModel : ISymbolViewModel, INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the symbol configuration.
        /// </summary>
        /// <value>
        /// The symbol configuration.
        /// </value>
        public ISymbolConfiguration SymbolConfiguration { get; private set; }

        public IRateMovementViewModel RateMovementViewModel { get; private set; }

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
        public SymbolViewModel(ISymbolConfiguration symbolConfiguration, IRateMovementViewModel rateMovementViewModel)
        {
            SymbolConfiguration = symbolConfiguration;
            RateMovementViewModel = rateMovementViewModel;
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
