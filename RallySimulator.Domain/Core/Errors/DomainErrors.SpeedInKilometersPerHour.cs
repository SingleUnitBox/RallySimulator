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
        public static class SpeedInKilometersPerHour
        {
            public static Error LessThanOrEqualToZero
                => new Error(
                    "SpeenInKilometersPerHour.LessThanOrEqualToZero",
                    "The provided speed is less than or equal to zero.");
        }
    }
    
}
