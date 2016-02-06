using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Internovus.Wpf.Training.OfflineTrading.Common.Constants;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule
{
    public class SymbolsModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public SymbolsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.SelectionRegion, typeof(SelectionView));
        }
    }
}
