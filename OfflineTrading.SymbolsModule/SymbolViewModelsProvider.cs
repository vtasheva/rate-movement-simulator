using Internovus.Wpf.Training.OfflineTrading.Common.Charting.Interfaces;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Linq;

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule
{
    class SymbolViewModelsProvider : ISymbolViewModelsProvider
    {
        private readonly IEnumerable<ISymbolConfiguration> _symbolConfigurations;
        private readonly IUnityContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="SymbolViewModelsProvider"/> class.
        /// </summary>
        /// <param name="symbolConfigurations">The symbol configurations.</param>
        public SymbolViewModelsProvider(IEnumerable<ISymbolConfiguration> symbolConfigurations, IUnityContainer container)
        {
            _symbolConfigurations = symbolConfigurations;
            _container = container;
        }

        /// <summary>
        /// Gets the symbol view models.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ISymbolViewModel> GetSymbolViewModels()
        { 
            var result = _symbolConfigurations.Select(s => new SymbolViewModel(s, _container.Resolve<IRateMovementViewModel>(new ParameterOverride("symbolConfiguration", s), new ParameterOverride("rateGenerator", _container.Resolve<IRateGeneratorProvider>(new ParameterOverride("symbolConfiguration", s)).GetRateGenerator())))).ToList();
            return result;
        }
    }
}
