using Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces;
using System.Windows.Controls;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Views
{
    /// <summary>
    /// Interaction logic for CurrentPositions.xaml
    /// </summary>
    public partial class CurrentPositionsView : UserControl
    {
        public CurrentPositionsView(ICurrentPositionsViewModel currentPositionsViewModel)
        {
            InitializeComponent();

            DataContext = currentPositionsViewModel;
        }
    }
}
