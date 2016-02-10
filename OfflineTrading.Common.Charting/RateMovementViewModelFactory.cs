using Internovus.Wpf.Training.OfflineTrading.Common.Charting.Interfaces;
using Internovus.Wpf.Training.OfflineTrading.Common.Charting.ViewModels;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using Microsoft.Practices.Prism.PubSubEvents;

namespace Internovus.Wpf.Training.OfflineTrading.Common.Charting
{
    public class RateMovementViewModelFactory : IRateMovementViewModelFactory
    {
        private readonly IRateGeneratorProvider _rateGeneratorProvider;
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// Initializes a new instance of the <see cref="RateMovementViewModelFactory"/> class.
        /// </summary>
        /// <param name="rateGeneratorProvider">The rate generator provider.</param>
        public RateMovementViewModelFactory(IRateGeneratorProvider rateGeneratorProvider, IEventAggregator eventAggregator)
        {
            _rateGeneratorProvider = rateGeneratorProvider;
            _eventAggregator = eventAggregator;
        }

        /// <summary>
        /// Creates the specified symbol configuration.
        /// </summary>
        /// <param name="symbolConfiguration">The symbol configuration.</param>
        /// <returns></returns>
        public IRateMovementViewModel Create(ISymbolConfiguration symbolConfiguration)
        {
            return new RateMovementViewModel(_rateGeneratorProvider.GetRateGenerator(symbolConfiguration), symbolConfiguration, _eventAggregator);
        }
    }
}
