using Abmes.UnityExtensions;
using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.OfflineTrading.Common.Extensions;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
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

            var mainWindow = Container.Resolve<MainWindow>();
            mainWindow.ShowDialog();
            Shutdown();
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var originalException = e.Exception.GetBaseException();
            MessageBox.Show(originalException.Message);
            Environment.Exit(1);
        }

        private void RegisterTypes(IEnumerable<string> args)
        {
            Container.RegisterIEnumerable();

            Container.RegisterType<Timer>(new InjectionConstructor());
            Container.RegisterType<IApplicationArgsParser, ApplicationArgsParser>();

            Container.RegisterTypeByFactoryFunc<ISymbolConfiguration, IApplicationArgsParser>(p => p.GetApplicationArgs(args));

            Container.RegisterTypeByFactoryFunc<IRateGenerator, IRateGeneratorProvider, ISymbolConfiguration>((p, sc) => p.GetRateGenerator(sc));

            Container.RegisterAllContainerConfigurators();
        }
    }
}
