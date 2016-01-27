using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.RateMovementSimulator
{
    public class ApplicationArgs
    {
        public string WaveType { get; set; }
        public decimal InitialRate { get; set; }
        public decimal Amplitude { get; set; }
        public int PeriodInMilliseconds { get; set; }
        public int StepInMilliseconds { get; set; }
        public int TimeToRunInMinutes { get; set; }
    }
}
