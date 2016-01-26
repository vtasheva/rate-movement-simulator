using Internovus.Wpf.Training.RateMovementSimulator.RateMovementSimulator.Constants;
using Internovus.Wpf.Training.RateMovementSimulator.RateMovementSimulator.Interfaces;
using Internovus.Wpf.Training.RateMovementSimulator.RateMovementSimulator.Waves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateMovementSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var arguments = args.Select(s => s.Split(new[] { '=' })).ToDictionary(s => s[0], s => s[1]);

            IWave wave = null;

            switch (arguments[ParameterName.WaveType].ToLower())
            { 
                case WaveName.Sine:
                    wave = new SineWave();
                    break;
            }
        }
    }
}
