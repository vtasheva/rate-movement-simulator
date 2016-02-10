using Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
