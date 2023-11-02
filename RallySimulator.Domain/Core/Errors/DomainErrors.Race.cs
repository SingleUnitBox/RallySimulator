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
        public static class Race
        {
            public static Error AlreadyStarted => new Error("Race.AlreadyStarted", "The race has already started.");
        }
    }   
}
