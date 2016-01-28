using Internovus.Wpf.Training.RateFeed;
using Internovus.Wpf.Training.RateFeed.Waves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.RateMovementSimulator
{
    public class ApplicationRunner
    {
        private IEnumerable<string> _args;

        public ApplicationRunner(IEnumerable<string> args)
        {
            _args = args;
        }

        public void Run()
        {
            var applicationArgsParser = new ApplicationArgsParser();
            var arguments = applicationArgsParser.GetApplicationArgs(_args);

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
