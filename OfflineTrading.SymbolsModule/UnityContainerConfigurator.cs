using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abmes.UnityExtensions;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule
{
    public class UnityContainerConfigurator : IUnityContainerConfigurator
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ISymbolViewModelsProvider, SymbolViewModelsProvider>();
            container.RegisterTypeByFactoryFunc<IEnumerable<ISymbolConfiguration>, ISymbolConfigurationsProvider>(p => p.GetConfigurations());
            container.RegisterTypeSingleton<IEnumerable<ISymbolViewModel>>(new InjectionFactory(c => c.Resolve<ISymbolViewModelsProvider>().GetSymbolViewModels()));
            container.RegisterTypeSingleton<ISymbolsViewModel>(new InjectionFactory(c => c.Resolve<SymbolsViewModel>()));
        }
    }
}
