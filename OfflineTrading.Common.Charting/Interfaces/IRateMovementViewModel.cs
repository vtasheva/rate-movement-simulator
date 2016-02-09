using System.Collections.ObjectModel;

namespace Internovus.Wpf.Training.OfflineTrading.Common.Charting.Interfaces
{
    public interface IRateMovementViewModel
    {
        /// <summary>
        /// Gets the rate points.
        /// </summary>
        /// <value>
        /// The rate points.
        /// </value>
        ObservableCollection<RatePoint> RatePoints { get; }

        decimal CurrentRate { get; }

        /// <summary>
        /// Gets the axis x step.
        /// </summary>
        /// <value>
        /// The axis x step.
        /// </value>
        double AxisXStep { get; }

        /// <summary>
        /// Gets the axis y minimum value.
        /// </summary>
        /// <value>
        /// The axis y minimum value.
        /// </value>
        decimal AxisYMinValue { get; }

        /// <summary>
        /// Gets the axis y maximum value.
        /// </summary>
        /// <value>
        /// The axis y maximum value.
        /// </value>
        decimal AxisYMaxValue { get; }
    }
}
