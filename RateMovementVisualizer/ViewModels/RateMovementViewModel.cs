using Internovus.Wpf.Training.RateFeed;
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
    public class RatePoint
    {
        public double Time { get; set; }
        public decimal Rate { get; set; }
    }

    public class RateMovementViewModel
    {
        public ObservableCollection<RatePoint> RatePoints { get; private set; }

        private int time = 0;

        public RateMovementViewModel(IRateGenerator rateGenerator)
        {
            RatePoints = new ObservableCollection<RatePoint>();

            rateGenerator.OnTick += RateGenerator_OnTick;
            rateGenerator.Start();
        }

        private void RateGenerator_OnTick(object sender, decimal rate)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                RatePoints.Add(new RatePoint { Time = time, Rate = rate });
                time++;
            });
        }
    }
}
