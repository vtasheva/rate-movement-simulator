using Internovus.Wpf.Training.OfflineTrading.Common;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using Internovus.Wpf.Training.RateMovementVisualizer.ViewModels.Interfaces;
using System.Collections.ObjectModel;

namespace Internovus.Wpf.Training.RateMovementVisualizer.ViewModels
{
    public class RateMovementViewModel : IRateMovementViewModel
    {
        private ApplicationArgs _applicationArgs;

        /// <summary>
        /// Gets the rate points.
        /// </summary>
        /// <value>
        /// The rate points.
        /// </value>
        public ObservableCollection<RatePoint> RatePoints { get; private set; }

        /// <summary>
        /// Gets the axis x step.
        /// </summary>
        /// <value>
        /// The axis x step.
        /// </value>
        public double AxisXStep => _applicationArgs.StepInMilliseconds;

        /// <summary>
        /// Gets the axis y minimum value.
        /// </summary>
        /// <value>
        /// The axis y minimum value.
        /// </value>
        public decimal AxisYMinValue => _applicationArgs.InitialRate - _applicationArgs.Amplitude;

        /// <summary>
        /// Gets the axis y maximum value.
        /// </summary>
        /// <value>
        /// The axis y maximum value.
        /// </value>
        public decimal AxisYMaxValue => _applicationArgs.InitialRate + _applicationArgs.Amplitude;

        /// <summary>
        /// Initializes a new instance of the <see cref="RateMovementViewModel"/> class.
        /// </summary>
        /// <param name="rateGenerator">The rate generator.</param>
        /// <param name="applicationArgs">The application arguments.</param>
        public RateMovementViewModel(IRateGenerator rateGenerator, ApplicationArgs applicationArgs)
        {
            _applicationArgs = applicationArgs;

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
