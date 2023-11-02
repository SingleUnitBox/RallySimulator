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
    public sealed class SpeedInKilometersPerHour : ValueObject
    {
        public decimal Value { get; private set; }
        private SpeedInKilometersPerHour(decimal value) => Value = value;
        private SpeedInKilometersPerHour()
        {
            
        }
        public static LengthInKilometers operator *(SpeedInKilometersPerHour speed, decimal numberOfHours)
        {
            Ensure.GreaterThanOrEqualToZero(
                numberOfHours,
                "The number of hours must be greater that or equal to zero,",
                nameof(numberOfHours));

            return LengthInKilometers.Create(speed.Value * numberOfHours).Value;
        }
        public static Result<SpeedInKilometersPerHour> Create(decimal speed)
            => Result.Success(speed)
                .Ensure(x => x > decimal.Zero, DomainErrors.SpeedInKilometersPerHour.LessThanOrEqualToZero)
                .Map(x => new SpeedInKilometersPerHour(x));
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
