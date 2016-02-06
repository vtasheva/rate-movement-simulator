using Internovus.Wpf.Training.OfflineTrading.Common.Constants;
using Internovus.Wpf.Training.OfflineTrading.TabsModule.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.TabsModule
{
    public class TabsModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public TabsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //_regionManager.RegisterViewWithRegion(RegionNames.TabsRegion, typeof(TabsView));
        }
    }
}
