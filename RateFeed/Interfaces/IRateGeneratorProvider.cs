namespace Internovus.Wpf.Training.RateFeed.Interfaces
{
    public interface IRateGeneratorProvider
    {
        /// <summary>
        /// Gets the rate generator.
        /// </summary>
        /// <returns></returns>
        IRateGenerator GetRateGenerator();
    }
}
