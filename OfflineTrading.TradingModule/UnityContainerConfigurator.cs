using Internovus.Wpf.Training.OfflineTrading.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Abmes.UnityExtensions;

namespace Internovus.Wpf.Training.OfflineTrading.TradingModule
{
    public class UnityContainerConfigurator : IUnityContainerConfigurator
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterTypeByFactoryFunc<IUserInfo, IUserInfoProvider>(p => p.GetUserInfo());
        }
    }
}
