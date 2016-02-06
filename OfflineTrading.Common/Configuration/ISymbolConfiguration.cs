using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.OfflineTrading.Common.Configuration
{
    public interface ISymbolConfiguration
    {
        string Name { get; }

        string WaveType { get; }

        decimal InitialRate { get; }

        decimal Amplitude { get; }

        int Period { get; }

        int Step { get; }
    }
}
