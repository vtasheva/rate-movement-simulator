using Internovus.Wpf.Training.OfflineTrading.App;
using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Regions;
using Internovus.Wpf.Training.OfflineTrading.SymbolsModule;
using Microsoft.Practices.Prism.Modularity;
using System.Configuration;
using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Configuration;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels;
using Internovus.Wpf.Training.OfflineTrading.TradingModule;
using System.Windows.Controls;
using Internovus.Wpf.Training.OfflineTrading.App.RegionAdapters;
using Abmes.UnityExtensions;

namespace OfflineTrading.App
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Container.RegisterType<IUserInfoProvider, UserInfoProvider>();
            Container.RegisterTypeByFactoryFunc<IUserInfo, IUserInfoProvider>(p => p.GetUserInfo());

            Container.RegisterType<ISymbolConfigurationsProvider, SymbolConfigurationsProvider>();
            Container.RegisterType<ISymbolViewModelsProvider, SymbolViewModelsProvider>();
            Container.RegisterTypeByFactoryFunc<IEnumerable<ISymbolConfiguration>, ISymbolConfigurationsProvider>(p => p.GetConfigurations());
            Container.RegisterTypeSingleton<IEnumerable<ISymbolViewModel>>(new InjectionFactory(c => c.Resolve<ISymbolViewModelsProvider>().GetSymbolViewModels()));
            Container.RegisterTypeSingleton<ISymbolsViewModel>(new InjectionFactory(c => c.Resolve<SymbolsViewModel>()));

            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var symbolsModuleType = typeof(SymbolsModule);
            ModuleCatalog.AddModule(new ModuleInfo { ModuleName = symbolsModuleType.Name, ModuleType = symbolsModuleType.AssemblyQualifiedName });

            var tradingModuleType = typeof(TradingModule);
            ModuleCatalog.AddModule(new ModuleInfo { ModuleName = tradingModuleType.Name, ModuleType = tradingModuleType.AssemblyQualifiedName });
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());

            return mappings;
        }
    }
}
