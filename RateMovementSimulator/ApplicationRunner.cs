﻿using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.RateFeed;
using Internovus.Wpf.Training.RateFeed.Implementations;
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

        public ApplicationRunner(IEnumerable<string> args)
        {
            _args = args;
        }

        /// <summary>
        /// Runs the main application flow.
        /// </summary>
        public void Run()
        {
            var applicationArgsParser = new ApplicationArgsParser();
            var arguments = applicationArgsParser.GetApplicationArgs(_args);

            var waveFuncFactory = new WaveFuncFactory();
            var waveFunc = waveFuncFactory.GetWaveFunc(arguments.WaveType, arguments.InitialRate, arguments.Amplitude, arguments.PeriodInMilliseconds);

            var timer = new Timer(arguments.StepInMilliseconds);
            var rateGenerator = new RateGenerator(waveFunc, timer);
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
    }
}