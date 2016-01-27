using Internovus.Wpf.Training.RateMovementSimulator.RateMovementSimulator.Constants;
using Internovus.Wpf.Training.RateMovementSimulator.RateMovementSimulator.Interfaces;
using Internovus.Wpf.Training.RateMovementSimulator.RateMovementSimulator.Waves;
using System;
using System.Collections.Generic;
using System.Linq;
using Timers = System.Timers;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RateMovementSimulator
{
    class Program
    {
        private static int _Step = 0;

        static void Main(string[] args)
        {
            var arguments = args.Select(s => s.Split(new[] { '=' })).ToDictionary(s => s[0], s => s[1]);

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
            wave.Step = Int32.Parse(arguments[ParameterName.Step]);
            wave.Period = Int32.Parse(arguments[ParameterName.Period]);
            wave.Amplitude = decimal.Parse(arguments[ParameterName.Amplitude]);


            _Step = Int32.Parse(arguments[ParameterName.Step]);
            var time = Int32.Parse(arguments[ParameterName.Time]);

            var timer = new Timers.Timer(time * 60000);
            timer.Elapsed += CloseApplication;
            timer.Start();

            var tickTimer = new Timer(ShowRate, wave, 0, _Step);
        }

        private static void ShowRate(object state)
        {
            IWave wave = (IWave)state;

            wave.Step += _Step;
            Console.WriteLine(wave.GetValue(wave.Step));

        }

        private static void CloseApplication(object sender, System.Timers.ElapsedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
