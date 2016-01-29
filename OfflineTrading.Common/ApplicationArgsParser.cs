using Internovus.Wpf.Training.OfflineTrading.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Internovus.Wpf.Training.OfflineTrading.Common
{
    /// <summary>
    /// Class ApplicationArgsParser.
    /// </summary>
    public class ApplicationArgsParser
    {
        /// <summary>
        /// Gets the application arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Instance of the <see cref="ApplicationArgs"/> class containing all arguments.</returns>
        /// <exception cref="ArgumentException">All arguments are required.</exception>
        public ApplicationArgs GetApplicationArgs(IEnumerable<string> args)
        {
            var arguments = args.Select(s => s.Split('=')).ToDictionary(s => s[0], s => s[1]);

            if (ParameterName.AllParameters.Any(a => !arguments.ContainsKey(a)))
            {
                throw new ArgumentException("All arguments are required.");
            }

            return new ApplicationArgs()
            {
                WaveType = arguments[ParameterName.WaveType],
                InitialRate = decimal.Parse(arguments[ParameterName.InitialRate]),
                Amplitude = decimal.Parse(arguments[ParameterName.Amplitude]),
                PeriodInMilliseconds = int.Parse(arguments[ParameterName.Period]),
                StepInMilliseconds = int.Parse(arguments[ParameterName.Step]),
                TimeToRunInMinutes = int.Parse(arguments[ParameterName.Time]),
            };
        }
    }
}
