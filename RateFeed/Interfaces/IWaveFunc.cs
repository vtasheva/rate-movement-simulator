namespace Internovus.Wpf.Training.RateFeed.Interfaces
{
    public interface IWaveFunc
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="timeInMilliseconds">The time in milliseconds.</param>
        /// <returns></returns>
        decimal GetValue(double timeInMilliseconds);
    }
}
