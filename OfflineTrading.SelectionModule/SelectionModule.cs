using Internovus.Wpf.Training.OfflineTrading.SelectionModule.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Internovus.Wpf.Training.OfflineTrading.Common.Constants;

namespace Internovus.Wpf.Training.OfflineTrading.SelectionModule
{
    public class SelectionModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public SelectionModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.SelectionRegion, typeof(SelectionView));
        }
    }
}
