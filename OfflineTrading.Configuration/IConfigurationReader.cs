using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.Configuration
{
    public interface IConfigurationReader
    {
        IEnumerable<Symbol> Read();
    }
}
