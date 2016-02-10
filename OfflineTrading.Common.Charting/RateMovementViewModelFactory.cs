using Internovus.Wpf.Training.OfflineTrading.Common.Charting.Interfaces;
using Internovus.Wpf.Training.OfflineTrading.Common.Charting.ViewModels;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.RateFeed.Interfaces;

namespace Internovus.Wpf.Training.OfflineTrading.Common.Charting
{
    public class RateMovementViewModelFactory : IRateMovementViewModelFactory
    {
        private readonly IRateGeneratorProvider _rateGeneratorProvider;

        public RateMovementViewModelFactory(IRateGeneratorProvider rateGeneratorProvider)
        {
            _rateGeneratorProvider = rateGeneratorProvider;
        }

        public IRateMovementViewModel Create(ISymbolConfiguration symbolConfiguration)
        {
            return new RateMovementViewModel(_rateGeneratorProvider.GetRateGenerator(symbolConfiguration), symbolConfiguration);
        }
    }
}
