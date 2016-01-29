using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Internovus.Wpf.Training.RateMovementVisualizer.ViewModels;
using Internovus.Wpf.Training.RateFeed;

namespace Internovus.Wpf.Training.RateMovementVisualizer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IUnityContainer _container = new UnityContainer();
        public static IUnityContainer Container => _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            RegisterTypes();
        }

        private void RegisterTypes()
        {
            Container.RegisterType<RateMovementViewModel>();
            Container.RegisterType<IRateGenerator, RateGenerator>();
        }
    }
}
