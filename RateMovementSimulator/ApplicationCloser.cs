using System;
using System.Timers;

namespace Internovus.Wpf.Training.RateMovementSimulator
{
    public class ApplicationCloser
    {
        private readonly Timer _timer;

        public ApplicationCloser(int timeToRunInMinutes)
        {
            _timer = new Timer(timeToRunInMinutes * 60000);
            _timer.Elapsed += CloseApplication;
        }

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
