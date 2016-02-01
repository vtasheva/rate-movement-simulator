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
using Internovus.Wpf.Training.RateFeed.Waves;
using Internovus.Wpf.Training.OfflineTrading.Common;
using System.Timers;
using System.Windows.Threading;

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

            this.DispatcherUnhandledException += App_DispatcherUnhandledException;

            RegisterTypes(e.Args);
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        private void RegisterTypes(IEnumerable<string> args)
        {
            Container.RegisterType<RateMovementViewModel>();
            Container.RegisterType<Timer>(new InjectionConstructor());
            Container.RegisterType<IRateGenerator>(new InjectionFactory(c => c.Resolve<RateGeneratorProvider>().GetRateGenerator()));
            Container.RegisterType<WaveFuncFactory>();
            Container.RegisterType<ApplicationArgs>(new InjectionFactory(c => c.Resolve<ApplicationArgsParser>().GetApplicationArgs(args)));
        }
    }
}
