using System;
using System.Linq;
using Internovus.Wpf.Training.RateFeed;
using Internovus.Wpf.Training.RateFeed.Waves;
using Internovus.Wpf.Training.RateMovementSimulator;
using Internovus.Wpf.Training.RateMovementSimulator.Constants;

namespace RateMovementSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var applicationArgsParser = new ApplicationArgsParser();
            var arguments = applicationArgsParser.GetApplicationArgs(args);

            var waveFuncFactory = new WaveFuncFactory();
            var waveFunc = waveFuncFactory.GetWaveFunc(arguments.WaveType, arguments.InitialRate, arguments.Amplitude, arguments.PeriodInMilliseconds);

            var rateGenerator = new RateGenerator(waveFunc, arguments.StepInMilliseconds);
            rateGenerator.OnTick += ShowRate;
            rateGenerator.Start();

            var applicationCloser = new ApplicationCloser(arguments.TimeToRunInMinutes);
            applicationCloser.Activate();

            Console.ReadLine();
        }

        private static void ShowRate(object sender, decimal rate)
        {
            Console.WriteLine(rate);
        }
    }
}
