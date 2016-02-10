using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using System.Collections.Generic;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels
{
    public class OpenedPositionsViewModel
    {
        private IUserInfo _userInfo;

        /// <summary>
        /// Gets or sets the opened positions.
        /// </summary>
        /// <value>
        /// The opened positions.
        /// </value>
        IEnumerable<OpenPosition> OpenedPositions { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenedPositionsViewModel"/> class.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        public OpenedPositionsViewModel(IUserInfo userInfo)
        {
            _userInfo = userInfo;
        }


    }
}
