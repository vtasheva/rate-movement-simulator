using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using System.Configuration;
using System;
using System.ComponentModel;
using static System.Math;
using Internovus.Wpf.Training.OfflineTrading.Common;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    class UserInfo : ConfigurationSection, INotifyPropertyChanged, IUserInfo
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

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Subtracts the amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <exception cref="System.Exception">The user doesn't have enough money.</exception>
        public void SubtractAmount(decimal amount)
        {
            var newAmount = CurrentAmount - amount;
            if (newAmount > 0)
            {
                CurrentAmount = newAmount;
            }
            else
            {
                throw new Exception("The user doesn't have enough money.");
            }
        }

        /// <summary>
        /// Adds the amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public void AddAmount(decimal amount)
        {
            CurrentAmount += amount;
        }
    }
}
