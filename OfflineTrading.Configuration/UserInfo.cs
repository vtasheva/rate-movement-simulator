using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using System.Configuration;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    class UserInfo : ConfigurationSection, IUserInfo
    {
        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
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

        /// <summary>
        /// Gets the current amount.
        /// </summary>
        /// <value>
        /// The current amount.
        /// </value>
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
