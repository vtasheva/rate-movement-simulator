﻿using Internovus.Wpf.Training.OfflineTrading.Common.Charting.Interfaces;
using System.Windows.Input;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels
{
    public interface ISymbolViewModel
    {
        /// <summary>
        /// Gets the symbol configuration.
        /// </summary>
        /// <value>
        /// The symbol configuration.
        /// </value>
        string SymbolName { get; }

        /// <summary>
        /// Gets the rate movement view model.
        /// </summary>
        /// <value>
        /// The rate movement view model.
        /// </value>
        IRateMovementViewModel RateMovementViewModel { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is visible.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is visible; otherwise, <c>false</c>.
        /// </value>
        bool IsVisible { get; set; }

        /// <summary>
        /// Gets the hide symbol command.
        /// </summary>
        /// <value>
        /// The hide symbol command.
        /// </value>
        ICommand HideSymbolCommand { get; }
    }
}
