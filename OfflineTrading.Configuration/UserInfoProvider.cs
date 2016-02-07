using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using System.Configuration;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    class UserInfoProvider : IUserInfoProvider
    {
        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <returns></returns>
        public IUserInfo GetUserInfo()
        {
            return (IUserInfo)ConfigurationManager.GetSection("UserConfiguration");
        }
    }
}
