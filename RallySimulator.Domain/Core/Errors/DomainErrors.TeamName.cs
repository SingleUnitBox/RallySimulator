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
        public static class TeamName
        {
            public static Error NullOrEmpty
                => new Error(
                    "TeamName.NullOrEmpty",
                    "The team name is required");
            public static Error LongerThanAllowed
                => new Error(
                    "TeamName.LongerThanAllowed",
                    "The team name is longer than allowed.");
        }
    }
    
}
