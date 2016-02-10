using Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Microsoft.Practices.Prism.PubSubEvents;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Events;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Implementations
{
    class UserInfoViewModel : IUserInfoViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public IUserInfo UserInfo { get; private set; }

        public UserInfoViewModel(IUserInfo userInfo, IEventAggregator eventAggregator)
        {
            UserInfo = userInfo;
            _eventAggregator = eventAggregator;

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            _eventAggregator.GetEvent<OpenPosition>().Subscribe(pi => UserInfo.SubstractAmount(pi.Amount));
            _eventAggregator.GetEvent<ClosePosition>().Subscribe(pi =>
            {
                UserInfo.AddAmount(pi.Profit);
            });
        }
    }
}
