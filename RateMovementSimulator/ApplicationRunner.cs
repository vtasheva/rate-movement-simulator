using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.RateFeed.Constants;
using Internovus.Wpf.Training.RateFeed.Factories;
using Internovus.Wpf.Training.RateFeed.Implementations;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Timers;

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

            var waveFuncProvider = _container.Resolve<IWaveFuncProvider>();
            var waveFunc = waveFuncProvider.GetWaveFunc(arguments.WaveType);

            var rateGenerator = _container.Resolve<IRateGenerator>();
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
            _container.RegisterType<Timer>(new InjectionConstructor());
            _container.RegisterType<IWaveFuncProvider, WaveFuncProvider>();
            _container.RegisterType<IRateGeneratorProvider, RateGeneratorProvider>();
            _container.RegisterType<IApplicationArgsParser, ApplicationArgsParser>();
            
            _container.RegisterType<IWaveFunc>(WaveNames.Sine, new InjectionFactory(c => c.Resolve<SineWaveFuncFactory>().Create()));
            _container.RegisterType<IWaveFunc>(WaveNames.Triangle, new InjectionFactory(c => c.Resolve<TriangleWaveFuncFactory>().Create()));
            _container.RegisterType<IWaveFunc>(WaveNames.Block, new InjectionFactory(c => c.Resolve<BlockWaveFuncFactory>().Create()));
            _container.RegisterType<IWaveFunc>(WaveNames.DoubleTriangle, new InjectionFactory(c => c.Resolve<DoubleTriangleWaveFuncFactory>().Create()));
            _container.RegisterType<IWaveFunc>(WaveNames.Random, new InjectionFactory(c => c.Resolve<RandomWaveFuncFactory>().Create()));
            
            _container.RegisterType<IRateGenerator>(new InjectionFactory(c => c.Resolve<IRateGeneratorProvider>().GetRateGenerator()));
            _container.RegisterType<ApplicationArgs>(new InjectionFactory(c => c.Resolve<IApplicationArgsParser>().GetApplicationArgs(args)));
        }
    }
}
