using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Events;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Interfaces;
using Microsoft.Practices.Prism.PubSubEvents;

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
            _eventAggregator.GetEvent<OpenPosition>().Subscribe(OpenPositionHandler);
            _eventAggregator.GetEvent<ClosePosition>().Subscribe(pi => UserInfo.AddAmount(pi.OpenRate * pi.Amount + pi.Profit));
        }

        private void OpenPositionHandler(IPositionItem positionItem)
        {
            try
            {
                UserInfo.SubtractAmount(positionItem.OpenRate * positionItem.Amount);
            }
            catch
            {
                _eventAggregator.GetEvent<CancelPosition>().Publish(positionItem);
                throw;
            }
        }
    }
}
