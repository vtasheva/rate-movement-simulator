using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using System.Configuration;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    /// <summary>
    /// Class ApplicationArgs.
    /// </summary>
    class SymbolConfiguration : ConfigurationElement, ISymbolConfiguration
    {
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

        [ConfigurationProperty("waveType", IsRequired = true, DefaultValue = "sine")]
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

        [ConfigurationProperty("initialRate", IsRequired = true, DefaultValue = "0")]
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

        [ConfigurationProperty("amplitude", IsRequired = true, DefaultValue = "1")]
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

        [ConfigurationProperty("period", DefaultValue = "60000")]
        public int Period
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

        [ConfigurationProperty("step", DefaultValue = "1000")]
        public int Step
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
