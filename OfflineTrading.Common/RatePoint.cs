using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.Common
{
    public class RatePoint
    {
        public double Time { get; private set; }
        public decimal Rate { get; private set; }

        public RatePoint(double time, decimal rate)
        {
            Time = time;
            Rate = rate;
        }
    }
}
