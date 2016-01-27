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
        private static int _stepInMilliseconds;
        private static RateGenerator _rateGenerator;

        static void Main(string[] args)
        {
            var arguments = args.Select(s => s.Split('=')).ToDictionary(s => s[0], s => s[1]);

            var waveType = arguments[ParameterName.WaveType];
            var initialRate = decimal.Parse(arguments[ParameterName.InitialRate]);
            var amplitude = decimal.Parse(arguments[ParameterName.Amplitude]);
            var periodInMilliseconds = int.Parse(arguments[ParameterName.Period]);

            var waveFuncFactory = new WaveFuncFactory();
            var waveFunc = waveFuncFactory.GetWaveFunc(waveType, initialRate, amplitude, periodInMilliseconds);

            _stepInMilliseconds = int.Parse(arguments[ParameterName.Step]);
            var timeToRunInMinutes = int.Parse(arguments[ParameterName.Time]);

            _rateGenerator = new RateGenerator(waveFunc, _stepInMilliseconds);
            _rateGenerator.OnTick += ShowRate;
            _rateGenerator.Start();

            var applicationCloser = new ApplicationCloser(timeToRunInMinutes);
            applicationCloser.Activate();

            Console.ReadLine();
        }

        private static void ShowRate(object sender, decimal rate)
        {
            Console.WriteLine(rate);
        }
    }
}
