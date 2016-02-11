namespace Internovus.Wpf.Training.OfflineTrading.Common.Configuration
{
    public interface IUserInfo
    {
        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        string UserName { get; }

        /// <summary>
        /// Gets the current amount.
        /// </summary>
        /// <value>
        /// The current amount.
        /// </value>
        decimal CurrentAmount { get; }

        /// <summary>
        /// Subtract the amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        void SubtractAmount(decimal amount);

        /// <summary>
        /// Adds the amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        void AddAmount(decimal amount);
    }
}
