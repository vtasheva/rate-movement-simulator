using Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces;
using System.Windows.Controls;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Views
{
    /// <summary>
    /// Interaction logic for OpenPositionView.xaml
    /// </summary>
    public partial class OpenPositionView : UserControl
    {
        public OpenPositionView(IOpenPositionViewModel openPositionViewModel)
        {
            InitializeComponent();

            DataContext = openPositionViewModel;
        }
    }
}
