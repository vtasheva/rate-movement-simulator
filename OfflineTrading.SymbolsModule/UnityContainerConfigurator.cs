using Abmes.UnityExtensions;
using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Charting.Interfaces;
using Internovus.Wpf.Training.OfflineTrading.Common.Charting.ViewModels;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels;
using Internovus.Wpf.Training.RateFeed.Constants;
using Internovus.Wpf.Training.RateFeed.Factories;
using Internovus.Wpf.Training.RateFeed.Implementations;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Timers;
using Internovus.Wpf.Training.OfflineTrading.Configuration;

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

            container.RegisterType<Timer>(new InjectionConstructor());
            container.RegisterType<IRateMovementViewModel, RateMovementViewModel>();
            container.RegisterType<IWaveFuncProvider, WaveFuncProvider>();
            container.RegisterType<IRateGeneratorProvider, RateGeneratorProvider>();
            container.RegisterType<ISymbolConfiguration, SymbolConfiguration>();

            container.RegisterType<IRateGenerator>(new InjectionFactory(c => c.Resolve<IRateGeneratorProvider>().GetRateGenerator()));


            var configurations = container.Resolve<IEnumerable<ISymbolConfiguration>>();

            foreach (var configuration in configurations)
            {
                container.RegisterType<IWaveFunc>(configuration.Name, new InjectionFactory(c => c.Resolve<WaveFuncFactoryProvider>().GetWaveFuncFactory(configuration).Create()));
            }
          
        }
    }
}
