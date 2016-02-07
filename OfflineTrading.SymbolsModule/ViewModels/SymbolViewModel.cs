using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels
{
    class SymbolViewModel : ISymbolViewModel, INotifyPropertyChanged
    {
        public ISymbolConfiguration SymbolConfiguration { get; private set; }

        private bool _isVisible;
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

        public SymbolViewModel(ISymbolConfiguration symbolConfiguration)
        {
            SymbolConfiguration = symbolConfiguration;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
