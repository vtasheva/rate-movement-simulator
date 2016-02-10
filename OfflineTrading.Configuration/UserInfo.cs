using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using System.Configuration;
using System;
using System.ComponentModel;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    class UserInfo : ConfigurationSection, IUserInfo, INotifyPropertyChanged
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
        public decimal InitialAmount
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

        private decimal _currentAmount = decimal.MaxValue;
        public decimal CurrentAmount
        {
            get
            {
                if (_currentAmount == decimal.MaxValue)
                {
                    _currentAmount = InitialAmount;
                }

                return _currentAmount;
            }
            private set
            {
                if (_currentAmount != value)
                {
                    _currentAmount = value;
                    NotifyPropertyChanged(nameof(CurrentAmount));
                }
            }
        }

        public void SubstractAmount(decimal amount)
        {
            CurrentAmount -= amount;
        }

        public void AddAmount(decimal amount)
        {
            CurrentAmount += amount;
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
