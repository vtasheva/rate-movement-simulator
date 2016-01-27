using Internovus.Wpf.Training.RateMovementSimulator.RateMovementSimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.RateMovementSimulator.RateMovementSimulator.Waves
{
    class TriangleWave : IWave
    {
        public decimal InitialRate { get; set; }

        public int Step { get; set; }

        public int Period { get; set; }

        public decimal Amplitude { get; set; }

        public decimal GetValue(int x)
        {
            return InitialRate + 2 * Amplitude / Convert.ToDecimal(Math.PI * Math.Asin(Math.Sin(2 * Math.PI * x / Period)));
        }
    }
}
