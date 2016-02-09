using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
