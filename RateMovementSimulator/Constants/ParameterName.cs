using System.Collections.Generic;

namespace Internovus.Wpf.Training.RateMovementSimulator.Constants
{
    static class ParameterName
    {
        /// <summary>
        /// The wave type parameter name
        /// </summary>
        public const string WaveType = "waveType";

        /// <summary>
        /// The initial rate parameter name
        /// </summary>
        public const string InitialRate = "initialRate";

        /// <summary>
        /// The step parameter name
        /// </summary>
        public const string Step = "step";

        /// <summary>
        /// The period parameter name
        /// </summary>
        public const string Period = "period";

        /// <summary>
        /// The amplitude parameter name
        /// </summary>
        public const string Amplitude = "amplitude";

        /// <summary>
        /// The time parameter name
        /// </summary>
        public const string Time = "time";

        public static IEnumerable<string> AllParameters = new[] { WaveType, InitialRate, Step, Period, Amplitude, Time };
    }
}
