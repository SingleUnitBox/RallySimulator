using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallySimulator.Domain.Primitives.Maybe
{
    public sealed class Maybe<T> : IEquatable<Maybe<T>>
    {
        private readonly T _value;
        private Maybe(T value) => _value = value;

        public static Maybe<T> None => new Maybe<T>(default);
        public bool HasValue => !HasNoValue;
        public bool HasNoValue => _value is null;
        public T Value => HasValue
            ? _value
            : throw new InvalidOperationException("The value cannot be accessed because ot does not exist.");
        public static implicit operator Maybe<T>(T value) => From(value);
        public static Maybe<T> From(T value) => new Maybe<T>(value);
        public bool Equals(Maybe<T>? other)
        {
            if (other is null)
            {
                return false;
            }
            if (HasNoValue && other.HasNoValue)
            {
                return true;
            }
            if (HasNoValue || other.HasNoValue)
            {
                return false;
            }
            return Value.Equals(other.Value);
        }
        public override bool Equals(object? obj)
            => obj switch
            {
                null => false,
                T value => Equals(new Maybe<T>(value)),
                _ => false
            };
        public override int GetHashCode() => HasValue ? Value.GetHashCode() : 0;

    }
}
