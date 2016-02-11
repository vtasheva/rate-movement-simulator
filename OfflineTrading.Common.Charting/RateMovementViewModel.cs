using Internovus.Wpf.Training.OfflineTrading.Common.Charting.Interfaces;
using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.OfflineTrading.Common.Events;
using Internovus.Wpf.Training.OfflineTrading.Common.Events.Arguments;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using Microsoft.Practices.Prism.PubSubEvents;
using System.Collections.ObjectModel;

namespace Internovus.Wpf.Training.OfflineTrading.Common.Charting.ViewModels
{
    public class RateMovementViewModel : IRateMovementViewModel
    {
        private ISymbolConfiguration _symbolConfiguration;
        private IEventAggregator _eventAggregator;

        /// <summary>
        /// Gets the rate points.
        /// </summary>
        /// <value>
        /// The rate points.
        /// </value>
        public ObservableCollection<RatePoint> RatePoints { get; }

        /// <summary>
        /// Gets the axis x step.
        /// </summary>
        /// <value>
        /// The axis x step.
        /// </value>
        public double AxisXStep => _symbolConfiguration.StepInMilliseconds;

        /// <summary>
        /// Gets the axis y minimum value.
        /// </summary>
        /// <value>
        /// The axis y minimum value.
        /// </value>
        public decimal AxisYMinValue => _symbolConfiguration.InitialRate - _symbolConfiguration.Amplitude;

        /// <summary>
        /// Gets the axis y maximum value.
        /// </summary>
        /// <value>
        /// The axis y maximum value.
        /// </value>
        public decimal AxisYMaxValue => _symbolConfiguration.InitialRate + _symbolConfiguration.Amplitude;


        /// <summary>
        /// Initializes a new instance of the <see cref="RateMovementViewModel"/> class.
        /// </summary>
        /// <param name="rateGenerator">The rate generator.</param>
        /// <param name="applicationArgs">The application arguments.</param>
        public RateMovementViewModel(IRateGenerator rateGenerator, ISymbolConfiguration symbolConfiguration, IEventAggregator eventAggregator)
        {
            _symbolConfiguration = symbolConfiguration;
            _eventAggregator = eventAggregator;

            RatePoints = new ObservableCollection<RatePoint>();

            rateGenerator.OnTick += RateGenerator_OnTick;
            rateGenerator.Start();
        }

        private void RateGenerator_OnTick(object sender, RatePoint ratePoint)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                RatePoints.Add(ratePoint);
                var rateChangedEventArgs = new RateChangedEventArgs(_symbolConfiguration.Name, ratePoint.Rate);
                _eventAggregator.GetEvent<RateChanged>().Publish(rateChangedEventArgs);
            });
        }
    }
}
