using RallySimulator.Domain.Core.Errors;
using RallySimulator.Domain.Primitives;
using RallySimulator.Domain.Primitives.Result;
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
        public const decimal DefaultLength = 10_000;
        public LengthInKilometers LengthInKilometers { get; private set; }
        public RaceStatus Status { get; private set; }
        public DateTime? StartTimeUtc { get; private set; }
        public DateTime? FinishTimeUtc { get; private set; }
        public DateTime CreatedOnUtc { get; }
        public DateTime? ModifiedOnUtc { get; }

        private Race()
        {

        }
        public Race(LengthInKilometers lengthInKilometers)
        {
            Ensure.NotNull(lengthInKilometers, "The race length in kilometers is required.", nameof(lengthInKilometers));
            LengthInKilometers = lengthInKilometers;
            Status = RaceStatus.Pending;
        }
        public Result StartRace(DateTime utcNow)
        {
            if (StartTimeUtc.HasValue)
            {
                return Result.Failure(DomainErrors.Race.AlreadyStarted);
            }

            StartTimeUtc = utcNow;
            Status = RaceStatus.Running;

            return Result.Success();
        }
        public void CompleteRace(DateTime utcNow)
        {
            // TODO Add validation?
            FinishTimeUtc = utcNow;
            Status = RaceStatus.Finished;
        }
    }
}
