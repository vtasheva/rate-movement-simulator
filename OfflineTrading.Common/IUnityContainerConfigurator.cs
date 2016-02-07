using Microsoft.Practices.Unity;

namespace Internovus.Wpf.Training.OfflineTrading.Common
{
    public interface IUnityContainerConfigurator
    {
        /// <summary>
        /// Registers the types.
        /// </summary>
        /// <param name="container">The container.</param>
        void RegisterTypes(IUnityContainer container);
    }
}
