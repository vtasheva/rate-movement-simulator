using Internovus.Wpf.Training.OfflineTrading.App;
using Internovus.Wpf.Training.OfflineTrading.App.RegionAdapters;
using Internovus.Wpf.Training.OfflineTrading.SymbolsModule;
using Internovus.Wpf.Training.OfflineTrading.TradingModule;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using System.Windows;
using System.Windows.Controls;
using Internovus.Wpf.Training.OfflineTrading.Common.Extensions;

namespace OfflineTrading.App
{
    public class Bootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// Creates the shell or main window of the application.
        /// </summary>
        /// <returns>
        /// The shell of the application.
        /// </returns>
        /// <remarks>
        /// If the returned instance is a <see cref="T:System.Windows.DependencyObject" />, the
        /// <see cref="T:Microsoft.Practices.Prism.Bootstrapper" /> will attach the default <see cref="T:Microsoft.Practices.Prism.Regions.IRegionManager" /> of
        /// the application in its <see cref="F:Microsoft.Practices.Prism.Regions.RegionManager.RegionManagerProperty" /> attached property
        /// in order to be able to add regions by using the <see cref="F:Microsoft.Practices.Prism.Regions.RegionManager.RegionNameProperty" />
        /// attached property from XAML.
        /// </remarks>
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        /// <summary>
        /// Initializes the shell.
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures the <see cref="T:Microsoft.Practices.Prism.Modularity.IModuleCatalog" /> used by Prism.
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var symbolsModuleType = typeof(SymbolsModule);
            ModuleCatalog.AddModule(new ModuleInfo { ModuleName = symbolsModuleType.Name, ModuleType = symbolsModuleType.AssemblyQualifiedName });

            var tradingModuleType = typeof(TradingModule);
            ModuleCatalog.AddModule(new ModuleInfo { ModuleName = tradingModuleType.Name, ModuleType = tradingModuleType.AssemblyQualifiedName });
        }

        /// <summary>
        /// Configures the default region adapter mappings to use in the application, in order
        /// to adapt UI controls defined in XAML to use a region and register it automatically.
        /// May be overwritten in a derived class to add specific mappings required by the application.
        /// </summary>
        /// <returns>
        /// The <see cref="T:Microsoft.Practices.Prism.Regions.RegionAdapterMappings" /> instance containing all the mappings.
        /// </returns>
        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());

            return mappings;
        }

        /// <summary>
        /// Configures the <see cref="T:Microsoft.Practices.Unity.IUnityContainer" />. May be overwritten in a derived class to add specific
        /// type mappings required by the application.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterAllContainerConfigurators();
        }

    }
}
