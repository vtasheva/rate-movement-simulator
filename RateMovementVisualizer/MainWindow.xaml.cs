using Internovus.Wpf.Training.OfflineTrading.Common.Charting;
using System.Windows;

namespace Internovus.Wpf.Training.RateMovementVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(RateMovementView rateMovementView)
            : this()
        {
            MainGrid.Children.Add(rateMovementView);
        }
    }
}
