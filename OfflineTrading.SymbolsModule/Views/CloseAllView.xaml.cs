using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels;
using System.Windows.Controls;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule.Views
{
    /// <summary>
    /// Interaction logic for CloseAllView.xaml
    /// </summary>
    partial class CloseAllView : UserControl
    {
        public CloseAllView(ISymbolsViewModel symbolsViewModel)
        {
            InitializeComponent();

            DataContext = symbolsViewModel;
        }
    }
}
