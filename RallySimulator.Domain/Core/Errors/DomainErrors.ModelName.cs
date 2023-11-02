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
        public static class ModelName
        {
            public static Error NullOrEmpty
                => new Error(
                    "ModelName.NullOrEmpty",
                    "The model name is required.");
            public static Error LongerThanAllowed
                => new Error(
                    "ModelName.LongerThanAllowed",
                    "The model name is longer than allowed.");
        }
    }
}
