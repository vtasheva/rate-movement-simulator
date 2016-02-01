using Internovus.Wpf.Training.RateFeed;
using Internovus.Wpf.Training.RateMovementSimulator;
using System;

namespace Internovus.Wpf.Training.RateMovementSimulator.RateMovementSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var applicationRunner = new ApplicationRunner(args);
                applicationRunner.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
