using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Microsoft.Practices.Unity;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    public class UnityContainerConfiguration : IUnityContainerConfigurator
    {
        /// <summary>
        /// Registers the types.
        /// </summary>
        /// <param name="container">The container.</param>
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUserInfoProvider, UserInfoProvider>();
            container.RegisterType<ISymbolConfigurationsProvider, SymbolConfigurationsProvider>();
        }
    }
}
