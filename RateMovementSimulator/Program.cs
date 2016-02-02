using Internovus.Wpf.Training.RateFeed;
using Internovus.Wpf.Training.RateFeed.Interfaces;
using Internovus.Wpf.Training.RateMovementSimulator;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Timers;

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
