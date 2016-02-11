using System.ComponentModel;

namespace Internovus.Wpf.Training.OfflineTrading.Common
{
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
