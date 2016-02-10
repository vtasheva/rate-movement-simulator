using Internovus.Wpf.Training.OfflineTrading.Common.Constants;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule
{
    public class TradingModule : IModule
    {
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="TradingModule"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public TradingModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ControlsRegion, typeof(UserAmountView));
            _regionManager.RegisterViewWithRegion(RegionNames.OpenedPositionsRegion, typeof(OpenedPositionsView));
            _regionManager.RegisterViewWithRegion(RegionNames.BuySellRegion, typeof(OpenPositionView));
            _regionManager.RegisterViewWithRegion(RegionNames.BuySellRegion, typeof(ClosePositionView));
        }

    }
}
