using RallySimulator.Domain.Primitives;
using RallySimulator.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallySimulator.Domain.Core
{
    public sealed class Race : Entity, IAuditableEntity
    {
        public const int DefaultLength = 10_000;
        public LengthInKilometers LengthInKilometers { get; private set; }
        public Race(int id, LengthInKilometers lengthInKilometers) : base(id)
        {
            Ensure.NotNull(lengthInKilometers, "The race length in kilometers is required.", nameof(lengthInKilometers));
            LengthInKilometers = lengthInKilometers;
        }
        public DateTime CreatedOnUtc { get; }

        public DateTime? ModifiedOnUtc { get; }

    }
}
