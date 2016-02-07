using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    public class UserInfo : ConfigurationSection, IUserInfo
    {
        [ConfigurationProperty("userName")]
        public string UserName
        {
            get
            {
                return base["userName"] as string;
            }
            set
            {
                base["userName"] = value;
            }
        }

        [ConfigurationProperty("amount")]
        public decimal CurrentAmount
        {
            get
            {
                return (decimal)base["amount"];
            }
            set
            {
                base["amount"] = value;
            }
        }

    }
}
