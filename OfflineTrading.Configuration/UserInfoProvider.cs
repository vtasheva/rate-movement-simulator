using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    public class UserInfoProvider : IUserInfoProvider
    {
        public IUserInfo GetUserInfo()
        {
            return (IUserInfo)ConfigurationManager.GetSection("UserConfiguration");
        }
    }
}
