using RallySimulator.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallySimulator.Domain.Core.Errors
{
    public static partial class DomainErrors
    {
        public static class Vehicle
        {
            public static Error RaceHasStarted => new Error(
                "Vehicle.RaceHasStarted",
                "The race has started and the vehicle information cannot be modified");

            public static Error RaceHasNotStarted => new Error(
                "Vehicle.RaceHasNotStarted",
                "The race has not started yet and the vehicle cannot suffer a malfunction.");

            public static Error Broken => new Error("Vehicle.Broken", "The vehicle is broken down and is out of the race.");
            public static Error WaitingForRepair => new Error(
                "Vehicle.WaitingForRepair",
                "The vehicle is waiting for repait and cannot be modified.");
        }
    }
    
}
