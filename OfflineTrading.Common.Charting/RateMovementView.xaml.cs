using Internovus.Wpf.Training.OfflineTrading.Common.Charting.Interfaces;
using System.Windows.Controls;

namespace Internovus.Wpf.Training.OfflineTrading.Common.Charting
{
    /// <summary>
    /// Interaction logic for RateMovementView.xaml
    /// </summary>
    public partial class RateMovementView : UserControl
    {
        public RateMovementView()
        {
            InitializeComponent();
        }

        public RateMovementView(IRateMovementViewModel rateMovementViewModel)
            : this()
        {
            DataContext = rateMovementViewModel;
        }
    }
}
