using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels;
using System.Windows.Controls;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Views
{
    /// <summary>
    /// Interaction logic for OpenClosePositionView.xaml
    /// </summary>
    public partial class OpenClosePositionView : UserControl
    {
        public OpenClosePositionView(ISymbolsViewModel symbolsViewModel)
        {
            InitializeComponent();

            DataContext = symbolsViewModel;
        }
    }
}
