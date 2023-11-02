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
    public sealed class TeamName : ValueObject
    {
        public const int MaxLength = 100;
        public string Value { get; }
        private TeamName(string value) => Value = value;
        public static implicit operator string(TeamName name) => name.Value != null ? name.Value : string.Empty;
        public static Result<TeamName> Create(string name)
            => Result.Create(name, DomainErrors.TeamName.NullOrEmpty)
                .Ensure(x => !string.IsNullOrEmpty(x), DomainErrors.TeamName.NullOrEmpty)
                .Ensure(x => x.Length > MaxLength, DomainErrors.TeamName.LongerThanAllowed)
                .Map(x => new TeamName(x));
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
