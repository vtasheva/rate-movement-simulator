using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.RateFeed.Constants;
using Internovus.Wpf.Training.RateFeed.Factories;
using Internovus.Wpf.Training.RateFeed.Implementations;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Timers;
using Abmes.UnityExtensions;

namespace Internovus.Wpf.Training.RateMovementSimulator
{
    /// <summary>
    /// Class ApplicationRunner.
    /// </summary>
    public class ApplicationRunner
    {
        private readonly IEnumerable<string> _args;
        private static IUnityContainer _container = new UnityContainer();

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRunner"/> class.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public ApplicationRunner(IEnumerable<string> args)
        {
            _args = args;
        }

        /// <summary>
        /// Runs the main application flow.
        /// </summary>
        public void Run()
        {
            RegisterTypes(_args);

            var arguments = _container.Resolve<ApplicationArgs>();

            var waveFuncFactory = _container.Resolve<IWaveFuncFactoryProvider>().GetWaveFuncFactory(arguments.WaveType);
            var waveFunc = waveFuncFactory.Create(arguments);

            var rateGenerator = _container.Resolve<IRateGeneratorProvider>().GetRateGenerator(arguments);
            rateGenerator.OnTick += ShowRate;
            rateGenerator.Start();

            var applicationCloser = new ApplicationCloser(arguments.TimeToRunInMinutes);
            applicationCloser.Activate();

            Console.ReadLine();
        }

        private static void ShowRate(object sender, RatePoint ratePoint)
        {
            Console.WriteLine(ratePoint.Rate);
        }

        private void RegisterTypes(IEnumerable<string> args)
        {
            _container.RegisterIEnumerable();

            _container.RegisterType<Timer>(new InjectionConstructor());
            _container.RegisterType<IRateGeneratorProvider, RateGeneratorProvider>();
            _container.RegisterType<IApplicationArgsParser, ApplicationArgsParser>();

            _container.RegisterType<IWaveFuncFactory, SineWaveFuncFactory>(WaveNames.Sine);
            _container.RegisterType<IWaveFuncFactory, TriangleWaveFuncFactory>(WaveNames.Triangle);
            _container.RegisterType<IWaveFuncFactory, DoubleTriangleWaveFuncFactory>(WaveNames.DoubleTriangle);
            _container.RegisterType<IWaveFuncFactory, BlockWaveFuncFactory>(WaveNames.Block);
            _container.RegisterType<IWaveFuncFactory, RandomWaveFuncFactory>(WaveNames.Random);
            _container.RegisterType<IWaveFuncFactoryProvider, WaveFuncFactoryProvider>();

            _container.RegisterType<ApplicationArgs>(new InjectionFactory(c => c.Resolve<IApplicationArgsParser>().GetApplicationArgs(args)));
        }
    }
}
