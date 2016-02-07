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
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels;
using Internovus.Wpf.Training.OfflineTrading.TradingModule;
using System.Windows.Controls;
using Internovus.Wpf.Training.OfflineTrading.App.RegionAdapters;
using Abmes.UnityExtensions;
using System.Reflection;
using System.IO;

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

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            RegisterAllTypes();
        }

        private void RegisterAllTypes()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (var dll in Directory.GetFiles(path, "*.dll"))
            {
                var assembly = Assembly.LoadFile(dll);
                var types = assembly.GetTypes().Where(t => t.GetInterface(nameof(IUnityContainerConfigurator)) != null);

                foreach (var type in types)
                {
                    var instance = (IUnityContainerConfigurator)Activator.CreateInstance(type);
                    instance.RegisterTypes(Container);
                }
            }
        }
    }
}
