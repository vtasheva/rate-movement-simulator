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
using Internovus.Wpf.Training.OfflineTrading.SelectionModule;
using Microsoft.Practices.Prism.Modularity;
using System.Configuration;
using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Configuration;
using Internovus.Wpf.Training.OfflineTrading.TabsModule;

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

            Container.RegisterType<IConfigurationReader, ConfigurationReader>();
            Container.RegisterType<IEnumerable<Symbol>>(new InjectionFactory(c => c.Resolve<IConfigurationReader>().Read()));

            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var selectionModuleType = typeof(SelectionModule);
            ModuleCatalog.AddModule(new ModuleInfo { ModuleName = selectionModuleType.Name, ModuleType = selectionModuleType.AssemblyQualifiedName });

            var tabsModuleType = typeof(TabsModule);
            ModuleCatalog.AddModule(new ModuleInfo { ModuleName = tabsModuleType.Name, ModuleType = tabsModuleType.AssemblyQualifiedName });
        }
    }
}
