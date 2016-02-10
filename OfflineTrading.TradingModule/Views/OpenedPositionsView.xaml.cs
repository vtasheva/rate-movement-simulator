using Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces;
using System.Windows.Controls;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Views
{
    /// <summary>
    /// Interaction logic for OpenedPositions.xaml
    /// </summary>
    public partial class OpenedPositionsView : UserControl
    {
        public OpenedPositionsView(IOpenedPositionsViewModel openedPositionsViewModel)
        {
            InitializeComponent();

            DataContext = openedPositionsViewModel;
        }
    }
}
