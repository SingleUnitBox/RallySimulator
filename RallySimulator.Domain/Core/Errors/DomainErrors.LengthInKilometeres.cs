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
        public static class LengthInKilometers
        {
            public static Error LessThanZero
                => new Error(
                    "LengthInKilometers.LessThanZero",
                    "The provided length is less than 0.");
        }
    }
}
