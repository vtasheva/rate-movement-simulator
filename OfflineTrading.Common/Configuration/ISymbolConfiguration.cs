namespace Internovus.Wpf.Training.OfflineTrading.Common.Configuration
{
    public interface ISymbolConfiguration
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }

        /// <summary>
        /// Gets the type of the wave.
        /// </summary>
        /// <value>
        /// The type of the wave.
        /// </value>
        string WaveType { get; }

        /// <summary>
        /// Gets the initial rate.
        /// </summary>
        /// <value>
        /// The initial rate.
        /// </value>
        decimal InitialRate { get; }

        /// <summary>
        /// Gets the amplitude.
        /// </summary>
        /// <value>
        /// The amplitude.
        /// </value>
        decimal Amplitude { get; }

        /// <summary>
        /// Gets the period.
        /// </summary>
        /// <value>
        /// The period.
        /// </value>
        int PeriodInMilliseconds { get; }

        /// <summary>
        /// Gets the step.
        /// </summary>
        /// <value>
        /// The step.
        /// </value>
        int StepInMilliseconds { get; }
    }
}
