using System.Collections.Generic;

namespace Internovus.Wpf.Training.OfflineTrading.Common
{
    public interface IApplicationArgsParser
    {
        /// <summary>
        /// Gets the application arguments.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        /// <returns></returns>
        ApplicationArgs GetApplicationArgs(IEnumerable<string> args);
    }
}
