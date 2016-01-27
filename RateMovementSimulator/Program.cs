using Internovus.Wpf.Training.RateMovementSimulator.Constants;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using Internovus.Wpf.Training.RateFeed.Waves;
using System;
using System.Collections.Generic;
using System.Linq;
using Timers = System.Timers;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Internovus.Wpf.Training.RateFeed;

namespace RateMovementSimulator
{
    class Program
    {
        private static int _stepInMilliseconds;
        private static RateGenerator _rateGenerator;

        static void Main(string[] args)
        {
            var arguments = args.Select(s => s.Split('=')).ToDictionary(s => s[0], s => s[1]);

            IWave wave = null;

            switch (arguments[ParameterName.WaveType].ToLower())
            { 
                case WaveName.Sine:
                    wave = new SineWave();
                    break;
                case WaveName.Triangle:
                    wave = new TriangleWave();
                    break;
                case WaveName.Block:
                    wave = new BlockWave();
                    break;
                case WaveName.DoubleTriangle:
                    wave = new DoubleTriangleWave();
                    break;
                default:
                    wave = new RandomWave();
                    break;
            }

            wave.InitialRate = decimal.Parse(arguments[ParameterName.InitialRate]);
            wave.PeriodInMilliseconds = Int32.Parse(arguments[ParameterName.Period]);
            wave.Amplitude = decimal.Parse(arguments[ParameterName.Amplitude]);


            _stepInMilliseconds = Int32.Parse(arguments[ParameterName.Step]);
            var timeToRunInMinutes = Int32.Parse(arguments[ParameterName.Time]);

            var timer = new Timers.Timer(timeToRunInMinutes * 60000);
            timer.Elapsed += CloseApplication;
            timer.Start();

            _rateGenerator = new RateGenerator(wave, _stepInMilliseconds);
            _rateGenerator.OnTick += ShowRate;
            _rateGenerator.Start();

            Console.ReadLine();
        }

        private static void ShowRate(object sender, decimal rate)
        {
            Console.WriteLine(rate);
        }

        private static void CloseApplication(object sender, System.Timers.ElapsedEventArgs e)
        {
            _rateGenerator.Stop();
            Environment.Exit(0);
        }
    }
}
