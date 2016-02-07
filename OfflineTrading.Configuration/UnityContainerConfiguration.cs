using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    public class UnityContainerConfiguration : IUnityContainerConfigurator
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUserInfoProvider, UserInfoProvider>();
            container.RegisterType<ISymbolConfigurationsProvider, SymbolConfigurationsProvider>();
        }
    }
}
