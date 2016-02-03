using System;
using System.Timers;

namespace Internovus.Wpf.Training.RateMovementSimulator
{
    /// <summary>
    /// Closes the main application after specified time has elapsed.
    /// </summary>
    public class ApplicationCloser
    {
        private readonly Timer _timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationCloser" /> class.
        /// </summary>
        /// <param name="timeToRunInMinutes">The time to run in minutes.</param>
        public ApplicationCloser(int timeToRunInMinutes)
        {
            _timer = new Timer(timeToRunInMinutes * 60000);
            _timer.Elapsed += CloseApplication;
        }

        /// <summary>
        /// Activates the application closer.
        /// </summary>
        public void Activate()
        {
            _timer.Start();
        }

        private static void CloseApplication(object sender, System.Timers.ElapsedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
