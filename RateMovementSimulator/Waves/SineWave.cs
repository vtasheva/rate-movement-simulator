using Internovus.Wpf.Training.RateMovementSimulator.RateMovementSimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.RateMovementSimulator.RateMovementSimulator.Waves
{
    class SineWave : IWave
    {
        public decimal InitialRate { get; set; }

        public int Step { get; set; }

        public int Period { get; set; }

        public decimal Amplitude { get; set; }

        public decimal GetValue(int x)
        {
            return InitialRate + Amplitude * Convert.ToDecimal(Math.Sin(2 * Math.PI * x / Period));
        }
    }
}
