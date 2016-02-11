using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Events;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces;
using Microsoft.Practices.Prism.PubSubEvents;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.Implementations
{
    class UserInfoViewModel : IUserInfoViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public IUserInfo UserInfo { get; }

        public UserInfoViewModel(IUserInfo userInfo, IEventAggregator eventAggregator)
        {
            UserInfo = userInfo;
            _eventAggregator = eventAggregator;

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            _eventAggregator.GetEvent<OpenPosition>().Subscribe(pi => UserInfo.CurrentAmount -= pi.OpenRate * pi.Amount);
            _eventAggregator.GetEvent<ClosePosition>().Subscribe(pi => UserInfo.CurrentAmount += pi.OpenRate * pi.Amount + pi.Profit);
        }
    }
}
