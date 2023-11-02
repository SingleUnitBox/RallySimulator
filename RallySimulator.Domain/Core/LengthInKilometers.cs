using RallySimulator.Domain.Core.Errors;
using RallySimulator.Domain.Primitives;
using RallySimulator.Domain.Primitives.Result;
using System.Collections.Generic;

namespace RallySimulator.Domain.Core
{
    public sealed class LengthInKilometers : ValueObject
    {
        public decimal Value { get; private set; }
        public LengthInKilometers(decimal value) => Value = value;

        public static implicit operator decimal(LengthInKilometers lengthInKilometers) => lengthInKilometers.Value;
        public static implicit operator string(LengthInKilometers lengthInKilometers) => "abc";
        public static Result<LengthInKilometers> Create(decimal length)
            => Result.Success(length)
                .Ensure(x => x >= decimal.Zero, DomainErrors.LengthInKilometers.LessThanZero)
                .Map(x => new LengthInKilometers(x));
        public static LengthInKilometers Zero => new LengthInKilometers(decimal.Zero);
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
        
    }
}
