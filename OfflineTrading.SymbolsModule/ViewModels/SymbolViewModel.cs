﻿using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels
{
    public class SymbolViewModel : INotifyPropertyChanged, ISymbolViewModel
    {
        public ISymbolConfiguration SymbolConfiguration { get; private set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    NotifyPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public SymbolViewModel(ISymbolConfiguration symbolConfiguration)
        {
            SymbolConfiguration = symbolConfiguration;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
