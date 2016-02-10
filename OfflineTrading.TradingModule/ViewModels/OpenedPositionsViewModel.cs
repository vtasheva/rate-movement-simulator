using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using System.Collections.Generic;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels
{
    public class OpenedPositionsViewModel
    {
        private IUserInfo _userInfo;

        IEnumerable<OpenPosition> OpenedPositions { get; set; }

        public OpenedPositionsViewModel(IUserInfo userInfo)
        {
            _userInfo = userInfo;
        }


    }
}
