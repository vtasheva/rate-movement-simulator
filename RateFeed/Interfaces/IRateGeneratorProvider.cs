using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.RateFeed.Interfaces
{
    public interface IRateGeneratorProvider
    {
        IRateGenerator GetRateGenerator();
    }
}
