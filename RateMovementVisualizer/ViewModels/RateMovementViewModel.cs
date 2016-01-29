using Internovus.Wpf.Training.RateFeed;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateMovementVisualizer.ViewModels
{
    public class RateMovementViewModel
    {
        public RateMovementViewModel() { }

        public RateMovementViewModel(IRateGenerator rateGenerator)
        {
            Rates = new ObservableCollection<decimal>();

            rateGenerator.OnTick += RateGenerator_OnTick;
        }

        public ObservableCollection<decimal> Rates { get; private set; }

        private void RateGenerator_OnTick(object sender, decimal rate)
        {
            Rates.Add(rate);
        }
    }
}
