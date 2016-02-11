using Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces;
using System.Windows.Controls;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Views
{
    /// <summary>
    /// Interaction logic for UserAmountView.xaml
    /// </summary>
    public partial class UserAmountView : UserControl
    {
        public UserAmountView(IUserInfoViewModel userInfoViewModel)
        {
            InitializeComponent();

            DataContext = userInfoViewModel;
        }
    }
}
