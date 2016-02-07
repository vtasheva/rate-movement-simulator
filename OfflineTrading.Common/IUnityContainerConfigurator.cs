using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.Common
{
    public interface IUnityContainerConfigurator
    {
        void RegisterTypes(IUnityContainer containter);
    }
}
