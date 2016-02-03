namespace Internovus.Wpf.Training.OfflineTrading.Common
{
    public class RatePoint
    {
        /// <summary>
        /// Gets the time in milliseconds.
        /// </summary>
        /// <value>
        /// The time in milliseconds.
        /// </value>
        public double TimeInMilliseconds { get; private set; }

        /// <summary>
        /// Gets the rate.
        /// </summary>
        /// <value>
        /// The rate.
        /// </value>
        public decimal Rate { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RatePoint"/> class.
        /// </summary>
        /// <param name="timeInMilliseconds">The time in milliseconds.</param>
        /// <param name="rate">The rate.</param>
        public RatePoint(double timeInMilliseconds, decimal rate)
        {
            TimeInMilliseconds = timeInMilliseconds;
            Rate = rate;
        }
    }
}
