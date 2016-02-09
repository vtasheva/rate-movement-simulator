using Internovus.Wpf.Training.OfflineTrading.Common.Constants;
using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule
{
    public class SymbolsModule : IModule
    {
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SymbolsModule"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public SymbolsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.SelectionRegion, typeof(SelectionView));
            _regionManager.RegisterViewWithRegion(RegionNames.TabsRegion, typeof(TabsView));
            _regionManager.RegisterViewWithRegion(RegionNames.ControlsRegion, typeof(CloseAllView));
        }
    }
}
