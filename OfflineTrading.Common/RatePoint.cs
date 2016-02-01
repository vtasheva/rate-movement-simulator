using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.Common
{
    public class RatePoint
    {
        public double TimeInMilliseconds { get; private set; }
        public decimal Rate { get; private set; }

        public RatePoint(double timeInMilliseconds, decimal rate)
        {
            TimeInMilliseconds = timeInMilliseconds;
            Rate = rate;
        }
    }
}
