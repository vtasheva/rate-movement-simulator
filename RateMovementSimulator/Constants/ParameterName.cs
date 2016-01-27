using System.Collections.Generic;

namespace Internovus.Wpf.Training.RateMovementSimulator.Constants
{
    static class ParameterName
    {
        public const string WaveType = "waveType";
        public const string InitialRate = "initialRate";
        public const string Step = "step";
        public const string Period = "period";
        public const string Amplitude = "amplitude";
        public const string Time = "time";

        public static IEnumerable<string> AllParameters = new[] { WaveType, InitialRate, Step, Period, Amplitude, Time };
    }
}
