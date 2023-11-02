using RallySimulator.Domain.Core.Errors;
using RallySimulator.Domain.Primitives;
using RallySimulator.Domain.Primitives.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallySimulator.Domain.Core
{
    public sealed class MalfunctionProbability : ValueObject
    {
        public decimal Value { get; private set; }
        private MalfunctionProbability(decimal value) => Value = value;
        public static Result<MalfunctionProbability> Create(decimal probability)
            => Result.Success(probability)
                .Ensure(x => x >= decimal.Zero && x <= 1.0m, DomainErrors.MalfunctionProbability.InvalidProbability)
                .Map(x => new MalfunctionProbability(x));
        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
