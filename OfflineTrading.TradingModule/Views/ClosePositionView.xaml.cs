using Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces;
using System.Windows.Controls;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Views
{
    /// <summary>
    /// Interaction logic for ClosePositionView.xaml
    /// </summary>
    public partial class ClosePositionView : UserControl
    {
        public ClosePositionView(IClosePositionViewModel closePositionViewModel)
        {
            InitializeComponent();

            DataContext = closePositionViewModel;
        }
    }
}
