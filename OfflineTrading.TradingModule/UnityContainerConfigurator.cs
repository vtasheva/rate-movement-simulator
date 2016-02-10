using Abmes.UnityExtensions;
using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels;
using Internovus.Wpf.Training.OfflineTrading.TradingModule.ViewModels.Interfaces;
using Microsoft.Practices.Unity;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule
{
    public class UnityContainerConfigurator : IUnityContainerConfigurator
    {
        /// <summary>
        /// Registers the types.
        /// </summary>
        /// <param name="container">The container.</param>
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterTypeByFactoryFunc<IUserInfo, IUserInfoProvider>(p => p.GetUserInfo());
            container.RegisterType<IOpenedPositionsViewModel, OpenedPositionsViewModel>();
            container.RegisterType<IOpenPositionViewModel, OpenPositionViewModel>();
            container.RegisterType<IClosePositionViewModel, ClosePositionViewModel>();
            container.RegisterType<ITradingEventsManager, TradingEventsManager>();
            container.RegisterType<IPositionItemProvider, PositionItemProvider>();
        }
    }
}
