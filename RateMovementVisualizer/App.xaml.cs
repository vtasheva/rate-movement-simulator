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
using Internovus.Wpf.Training.OfflineTrading.Common;
using System.Timers;
using System.Windows.Threading;
using Internovus.Wpf.Training.RateMovementVisualizer.ViewModels.Interfaces;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using Internovus.Wpf.Training.RateFeed.Implementations;
using Internovus.Wpf.Training.RateFeed.Implementations.Waves;
using Internovus.Wpf.Training.RateFeed.Factories;
using Internovus.Wpf.Training.RateFeed.Constants;

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
            Container.RegisterType<Timer>(new InjectionConstructor());
            Container.RegisterType<IRateMovementViewModel, RateMovementViewModel>();
            Container.RegisterType<IWaveFuncProvider, WaveFuncProvider>();
            Container.RegisterType<IRateGeneratorProvider, RateGeneratorProvider>();
            Container.RegisterType<IApplicationArgsParser, ApplicationArgsParser>();

            Container.RegisterType<IWaveFunc>(WaveNames.Sine, new InjectionFactory(c => c.Resolve<SineWaveFuncFactory>().Create()));
            Container.RegisterType<IWaveFunc>(WaveNames.Triangle, new InjectionFactory(c => c.Resolve<TriangleWaveFuncFactory>().Create()));
            Container.RegisterType<IWaveFunc>(WaveNames.Block, new InjectionFactory(c => c.Resolve<BlockWaveFuncFactory>().Create()));
            Container.RegisterType<IWaveFunc>(WaveNames.DoubleTriangle, new InjectionFactory(c => c.Resolve<DoubleTriangleWaveFuncFactory>().Create()));
            Container.RegisterType<IWaveFunc>(WaveNames.Random, new InjectionFactory(c => c.Resolve<RandomWaveFuncFactory>().Create()));

            Container.RegisterType<IRateGenerator>(new InjectionFactory(c => c.Resolve<IRateGeneratorProvider>().GetRateGenerator()));
            Container.RegisterType<ApplicationArgs>(new InjectionFactory(c => c.Resolve<IApplicationArgsParser>().GetApplicationArgs(args)));
        }
    }
}
