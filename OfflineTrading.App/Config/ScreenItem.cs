using System.Configuration;

namespace Internovus.Wpf.Training.OfflineTrading.App.Config
{
    /// <summary>
    /// Class ApplicationArgs.
    /// </summary>
    public class ScreenItem : ConfigurationElement
    {

        [ConfigurationProperty("name", IsKey = true)]
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

        ///// <summary>
        ///// Gets or sets the type of the wave.
        ///// </summary>
        ///// <value>The type of the wave.</value>
        //[ConfigurationProperty("waveType")]
        //public string WaveType { get; set; }

        ///// <summary>
        ///// Gets or sets the initial rate.
        ///// </summary>
        ///// <value>The initial rate.</value>
        //[ConfigurationProperty("initialRate")]
        //public decimal InitialRate { get; set; }

        ///// <summary>
        ///// Gets or sets the amplitude.
        ///// </summary>
        ///// <value>The amplitude.</value>
        //[ConfigurationProperty("amplitude")]
        //public decimal Amplitude { get; set; }

        ///// <summary>
        ///// Gets or sets the period in milliseconds.
        ///// </summary>
        ///// <value>The period in milliseconds.</value>
        //[ConfigurationProperty("period")]
        //public int PeriodInMilliseconds { get; set; }

        ///// <summary>
        ///// Gets or sets the step in milliseconds.
        ///// </summary>
        ///// <value>The step in milliseconds.</value>
        //[ConfigurationProperty("step")]
        //public int StepInMilliseconds { get; set; }
    }
}
