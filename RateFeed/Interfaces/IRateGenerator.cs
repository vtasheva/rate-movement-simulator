using Internovus.Wpf.Training.OfflineTrading.Common;

namespace Internovus.Wpf.Training.RateFeed.Interfaces
{
    /// <summary>
    /// Delegate OnTickEventHandler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="rate">The rate.</param>
    public delegate void OnTickEventHandler(object sender, RatePoint rate);

    public interface IRateGenerator
    {
        /// <summary>
        /// Occurs when [on tick].
        /// </summary>
        event OnTickEventHandler OnTick;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops this instance.
        /// </summary>
        void Stop();
    }
}
