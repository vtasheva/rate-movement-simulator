namespace Internovus.Wpf.Training.RateFeed.Interfaces
{
    public interface IWaveFuncProvider
    {
        /// <summary>
        /// Gets the wave function.
        /// </summary>
        /// <param name="waveType">Type of the wave.</param>
        /// <returns></returns>
        IWaveFunc GetWaveFunc(string symbolName);
    }
}
