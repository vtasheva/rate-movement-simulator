using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels;
using System.Windows.Controls;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule.Views
{
    /// <summary>
    /// Interaction logic for TabsView.xaml
    /// </summary>
    partial class TabsView : UserControl
    {
        public TabsView(ISymbolsViewModel symbolsViewModel)
        {
            InitializeComponent();

            DataContext = symbolsViewModel;
        }
    }
}
