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
        public static class MalfunctionProbability
        {
            public static Error InvalidProbability
                => new Error(
                    "MalfunctionProbability.InvalidProbability",
                    "The provided probability is not between 0 and 1.");
        }
    }
}
