using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using System.Windows.Controls;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Views
{
    /// <summary>
    /// Interaction logic for UserAmountView.xaml
    /// </summary>
    public partial class UserAmountView : UserControl
    {
        public UserAmountView(IUserInfo userInfo)
        {
            InitializeComponent();

            DataContext = userInfo;
        }
    }
}
