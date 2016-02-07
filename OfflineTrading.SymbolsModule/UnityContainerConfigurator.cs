using Abmes.UnityExtensions;
using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule
{
    public class UnityContainerConfigurator : IUnityContainerConfigurator
    {
        /// <summary>
        /// Registers the types.
        /// </summary>
        /// <param name="container">The container.</param>
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ISymbolViewModelsProvider, SymbolViewModelsProvider>();
            container.RegisterTypeByFactoryFunc<IEnumerable<ISymbolConfiguration>, ISymbolConfigurationsProvider>(p => p.GetConfigurations());
            container.RegisterTypeSingleton<IEnumerable<ISymbolViewModel>>(new InjectionFactory(c => c.Resolve<ISymbolViewModelsProvider>().GetSymbolViewModels()));
            container.RegisterTypeSingleton<ISymbolsViewModel>(new InjectionFactory(c => c.Resolve<SymbolsViewModel>()));
        }
    }
}
