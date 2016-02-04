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

            //Container.RegisterType<IApplicationArgsParser, ApplicationArgsParser>();

            var a = ConfigurationManager.GetSection("ScreenItemsConfiguration");
            

            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var selectionModuleType = typeof(SelectionModule);
            ModuleCatalog.AddModule(new ModuleInfo() { ModuleName = selectionModuleType.Name, ModuleType = selectionModuleType.AssemblyQualifiedName });
        }
    }
}
