using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.RateFeed.Constants;
using Internovus.Wpf.Training.RateFeed.Factories;
using Internovus.Wpf.Training.RateFeed.Implementations;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using Internovus.Wpf.Training.RateMovementVisualizer.ViewModels;
using Internovus.Wpf.Training.RateMovementVisualizer.ViewModels.Interfaces;
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
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var originalException = e.Exception.GetBaseException();
            MessageBox.Show(originalException.Message);
            Environment.Exit(1);
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
