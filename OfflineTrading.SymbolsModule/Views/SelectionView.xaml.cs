using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels;
using System.Windows.Controls;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule.Views
{
    /// <summary>
    /// Interaction logic for SelectionView.xaml
    /// </summary>
    partial class SelectionView : UserControl
    {
        public SelectionView(ISymbolsViewModel symbolsViewModel)
        {
            InitializeComponent();
            
            DataContext = symbolsViewModel;
        }
    }
}
