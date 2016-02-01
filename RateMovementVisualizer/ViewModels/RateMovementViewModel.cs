﻿using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.RateFeed;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using Internovus.Wpf.Training.RateMovementVisualizer.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using static System.Math;

namespace Internovus.Wpf.Training.RateMovementVisualizer.ViewModels
{
    public class RateMovementViewModel : IRateMovementViewModel
    {
        public ObservableCollection<RatePoint> RatePoints { get; private set; }

        public RateMovementViewModel(IRateGenerator rateGenerator)
        {
            RatePoints = new ObservableCollection<RatePoint>();

            rateGenerator.OnTick += RateGenerator_OnTick;
            rateGenerator.Start();
        }

        private void RateGenerator_OnTick(object sender, RatePoint ratePoint)
        {
            App.Current.Dispatcher.Invoke(() => RatePoints.Add(ratePoint));
        }
    }
}
