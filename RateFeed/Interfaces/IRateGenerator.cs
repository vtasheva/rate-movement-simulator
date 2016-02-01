using Internovus.Wpf.Training.OfflineTrading.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.RateFeed.Interfaces
{
    /// <summary>
    /// Delegate OnTickEventHandler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="rate">The rate.</param>
    public delegate void OnTickEventHandler(object sender, RatePoint rate);

    public interface IRateGenerator
    {
        event OnTickEventHandler OnTick;

        void Start();
        void Stop();
    }
}
