using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.RateMovementSimulator.RateMovementSimulator.Interfaces
{
    public interface IWave
    {
        decimal InitialRate { get; set; }

        int Step { get; set; }

        int Period { get; set; }

        decimal Amplitude { get; set; }
        
        decimal GetValue(int x);
    }
}
