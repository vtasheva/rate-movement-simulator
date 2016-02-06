using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels
{
    public class SymbolsViewModel : INotifyPropertyChanged, ISymbolsViewModel
    {
        public IEnumerable<ISymbolViewModel> SymbolViewModels { get; private set; }

        private ISymbolViewModel _slectedSymbolViewModel;
        public ISymbolViewModel SlectedSymbolViewModel
        {
            get
            {
                return _slectedSymbolViewModel;
            }
            set
            {
                if (value != _slectedSymbolViewModel)
                {
                    _slectedSymbolViewModel = value;
                    NotifyPropertyChanged(nameof(SlectedSymbolViewModel));
                }
            }
        }

        public SymbolsViewModel(IEnumerable<ISymbolViewModel> symbolViewModels)
        {
            SymbolViewModels = symbolViewModels;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
