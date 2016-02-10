using Internovus.Wpf.Training.OfflineTrading.Common.Charting.Interfaces;
using Internovus.Wpf.Training.OfflineTrading.Common.Charting.ViewModels;
using Microsoft.Practices.Unity;

namespace Internovus.Wpf.Training.OfflineTrading.Common.Charting
{
    public class UnityContainerConfigurator : IUnityContainerConfigurator
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IRateMovementViewModel, RateMovementViewModel>();
            container.RegisterType<IRateMovementViewModelFactory, RateMovementViewModelFactory>();
        }
    }
}
