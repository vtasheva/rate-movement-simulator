using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using System.Configuration;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    /// <summary>
    /// Class ApplicationArgs.
    /// </summary>
    public class SymbolConfiguration : ConfigurationElement, ISymbolConfiguration
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

        [ConfigurationProperty("waveType", IsKey = true, IsRequired = true, DefaultValue = "sine")]
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

        [ConfigurationProperty("initialRate", IsKey = true, IsRequired = true, DefaultValue = "0")]
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

        [ConfigurationProperty("amplitude", IsKey = true, IsRequired = true, DefaultValue = "1")]
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

        [ConfigurationProperty("period", IsKey = true, DefaultValue = "60000")]
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

        [ConfigurationProperty("step", IsKey = true, DefaultValue = "1000")]
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
