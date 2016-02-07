namespace Internovus.Wpf.Training.OfflineTrading.Common.Configuration
{
    public interface IUserInfoProvider
    {
        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <returns></returns>
        IUserInfo GetUserInfo();
    }
}
