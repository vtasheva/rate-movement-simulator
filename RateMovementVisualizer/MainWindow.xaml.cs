using Internovus.Wpf.Training.RateMovementVisualizer.ViewModels.Interfaces;
using Microsoft.Practices.Unity;
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

            DataContext = App.Container.Resolve<IRateMovementViewModel>();
        }
    }
}
