using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.Common.Configuration
{
    public interface IUserInfoProvider
    {
        IUserInfo GetUserInfo();
    }
}
