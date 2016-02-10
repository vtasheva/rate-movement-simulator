using Microsoft.Practices.Unity;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Internovus.Wpf.Training.OfflineTrading.Common.Extensions
{
    public static class UnityContainerExtensions
    {
        public static void RegisterAllContainerConfigurators(this IUnityContainer container)
        {
            var currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var assemblyFileNames = Directory.GetFiles(currentPath, "*.dll");
            var assemblies = assemblyFileNames.Select(Assembly.LoadFile);

            var unityContainerConfigurators = assemblies.SelectMany(a => a.GetTypes().Where(IsAssemblyConfigurator));

            foreach (var type in unityContainerConfigurators)
            {
                var instance = (IUnityContainerConfigurator)Activator.CreateInstance(type);
                instance.RegisterTypes(container);
            }
        }

        private static bool IsAssemblyConfigurator(Type type) => type.GetInterface(nameof(IUnityContainerConfigurator)) != null;
    }
}
