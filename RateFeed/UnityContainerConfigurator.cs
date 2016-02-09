using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.RateFeed.Constants;
using Internovus.Wpf.Training.RateFeed.Factories;
using Internovus.Wpf.Training.RateFeed.Implementations;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internovus.Wpf.Training.RateFeed
{
    public class UnityContainerConfigurator : IUnityContainerConfigurator
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IRateGeneratorProvider, RateGeneratorProvider>();

            container.RegisterType<IWaveFuncFactory, SineWaveFuncFactory>(WaveNames.Sine);
            container.RegisterType<IWaveFuncFactory, TriangleWaveFuncFactory>(WaveNames.Triangle);
            container.RegisterType<IWaveFuncFactory, DoubleTriangleWaveFuncFactory>(WaveNames.DoubleTriangle);
            container.RegisterType<IWaveFuncFactory, BlockWaveFuncFactory>(WaveNames.Block);
            container.RegisterType<IWaveFuncFactory, RandomWaveFuncFactory>(WaveNames.Random);
            container.RegisterType<IWaveFuncFactoryProvider, WaveFuncFactoryProvider>();
        }
    }
}
