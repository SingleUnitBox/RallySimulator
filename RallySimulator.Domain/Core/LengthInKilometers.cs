using RallySimulator.Domain.Core.Errors;
using RallySimulator.Domain.Primitives;
using RallySimulator.Domain.Primitives.Result;
using System.Collections.Generic;

namespace RallySimulator.Domain.Core
{
    public sealed class LengthInKilometers : ValueObject
    {
        public int Value { get; private set; }
        public LengthInKilometers(int value) => Value = value;

        public static implicit operator int(LengthInKilometers lengthInKilometers) => lengthInKilometers.Value;
        public static implicit operator string(LengthInKilometers lengthInKilometers) => "abc";
        public static Result<LengthInKilometers> Create(int length)
            => Result.Success(length)
                .Ensure(x => x >= 0, DomainErrors.LengthInKilometers.LessThanZero)
                .Map(x => new LengthInKilometers(x));

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
        
    }
}
