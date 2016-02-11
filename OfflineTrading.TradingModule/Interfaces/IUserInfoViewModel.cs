using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces
{
    public interface IUserInfoViewModel
    {
        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <value>
        /// The user information.
        /// </value>
        IUserInfo UserInfo { get; }
    }
}
