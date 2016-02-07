using System;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;

namespace Internovus.Wpf.Training.OfflineTrading.Common
{
    /// <summary>
    /// Class ApplicationArgs.
    /// </summary>
    public class ApplicationArgs : ISymbolConfiguration
    {
        public string Name
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the type of the wave.
        /// </summary>
        /// <value>The type of the wave.</value>
        public string WaveType { get; set; }

        /// <summary>
        /// Gets or sets the initial rate.
        /// </summary>
        /// <value>The initial rate.</value>
        public decimal InitialRate { get; set; }

        /// <summary>
        /// Gets or sets the amplitude.
        /// </summary>
        /// <value>The amplitude.</value>
        public decimal Amplitude { get; set; }

        /// <summary>
        /// Gets or sets the period in milliseconds.
        /// </summary>
        /// <value>The period in milliseconds.</value>
        public int PeriodInMilliseconds { get; set; }

        /// <summary>
        /// Gets or sets the step in milliseconds.
        /// </summary>
        /// <value>The step in milliseconds.</value>
        public int StepInMilliseconds { get; set; }

        /// <summary>
        /// Gets or sets the time to run in minutes.
        /// </summary>
        /// <value>The time to run in minutes.</value>
        public int TimeToRunInMinutes { get; set; }
    }
}
