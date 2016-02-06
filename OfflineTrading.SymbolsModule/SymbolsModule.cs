using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Internovus.Wpf.Training.OfflineTrading.Common.Constants;
using Microsoft.Practices.Unity;
using Abmes.UnityExtensions;
using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule
{
    public class SymbolsModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public SymbolsModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterTypeSingleton<IEnumerable<ISymbolViewModel>>(new InjectionFactory(c => c.Resolve<ISymbolConfigurationsProvider>().GetConfigurations().Select(s => new SymbolViewModel(s))));
            _container.RegisterTypeSingleton<ISymbolsViewModel, SymbolsViewModel>();

            _regionManager.RegisterViewWithRegion(RegionNames.SelectionRegion, typeof(SelectionView));
            _regionManager.RegisterViewWithRegion(RegionNames.TabsRegion, typeof(TabsView));
        }
    }
}
