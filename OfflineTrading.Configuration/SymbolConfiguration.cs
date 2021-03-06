﻿using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using System.Configuration;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    /// <summary>
    /// Class ApplicationArgs.
    /// </summary>
    public class SymbolConfiguration : ConfigurationElement, ISymbolConfiguration
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return base["name"] as string;
            }
            set
            {
                base["name"] = value;
            }
        }

        /// <summary>
        /// Gets the type of the wave.
        /// </summary>
        /// <value>
        /// The type of the wave.
        /// </value>
        [ConfigurationProperty("waveType", IsRequired = true)]
        public string WaveType
        {
            get
            {
                return base["waveType"] as string;
            }
            set
            {
                base["waveType"] = value;
            }
        }

        /// <summary>
        /// Gets the initial rate.
        /// </summary>
        /// <value>
        /// The initial rate.
        /// </value>
        [ConfigurationProperty("initialRate", IsRequired = true)]
        public decimal InitialRate
        {
            get
            {
                return (decimal)base["initialRate"];
            }
            set
            {
                base["initialRate"] = value;
            }
        }

        /// <summary>
        /// Gets the amplitude.
        /// </summary>
        /// <value>
        /// The amplitude.
        /// </value>
        [ConfigurationProperty("amplitude", IsRequired = true)]
        public decimal Amplitude
        {
            get
            {
                return (decimal)base["amplitude"];
            }
            set
            {
                base["amplitude"] = value;
            }
        }

        /// <summary>
        /// Gets the period.
        /// </summary>
        /// <value>
        /// The period.
        /// </value>
        [ConfigurationProperty("period")]
        public int PeriodInMilliseconds
        {
            get
            {
                return (int)base["period"];
            }
            set
            {
                base["period"] = value;
            }
        }

        /// <summary>
        /// Gets the step.
        /// </summary>
        /// <value>
        /// The step.
        /// </value>
        [ConfigurationProperty("step")]
        public int StepInMilliseconds
        {
            get
            {
                return (int)base["step"];
            }
            set
            {
                base["step"] = value;
            }
        }
    }
}
