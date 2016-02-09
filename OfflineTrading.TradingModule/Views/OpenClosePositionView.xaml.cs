using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels;
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
