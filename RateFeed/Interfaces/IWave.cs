using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.RateFeed.Interfaces
{
    public interface IWave
    {
        decimal InitialRate { get; set; }

        int PeriodInMilliseconds { get; set; }

        decimal Amplitude { get; set; }
        
        decimal GetValue(double x);
    }
}
