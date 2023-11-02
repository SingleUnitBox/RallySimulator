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
    public sealed class ModelName : ValueObject
    {
        public const int MaxLength = 100;
        public string Value { get; }
        public ModelName(string value) => Value = value;
        public static implicit operator string(ModelName name) => name?.Value ?? string.Empty;
        public static Result<ModelName> Create(string name)
            => Result.Create(name, DomainErrors.ModelName.NullOrEmpty)
                .Ensure(x => !string.IsNullOrWhiteSpace(x), DomainErrors.ModelName.NullOrEmpty)
                .Ensure(x => x.Length <= MaxLength, DomainErrors.ModelName.LongerThanAllowed)
                .Map(x => new ModelName(x));

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
