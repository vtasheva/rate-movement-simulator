using Internovus.Wpf.Training.OfflineTrading.Common.Constants;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule
{
    public class TradingModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public TradingModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ControlsRegion, typeof(UserAmountView));
        }
    }
}
