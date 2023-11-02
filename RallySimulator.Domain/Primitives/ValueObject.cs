using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallySimulator.Domain.Primitives
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public static bool operator ==(ValueObject left, ValueObject right)
        {
            if (left is null && right is null)
            {
                return true;
            }
            if (left is null || right is null)
            {
                return false;
            }
            return left.Equals(right);
        }
        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !(left == right);
        }
        public bool Equals(ValueObject? other)
        {
            if (other is null)
            {
                return false;
            }
            return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
        }
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (GetType() != obj.GetType())
            {
                return false;
            }
            if (!(obj is ValueObject valueObject))
            {
                return false;
            }
            return GetAtomicValues().SequenceEqual(valueObject.GetAtomicValues());
        }
        public override int GetHashCode()
            => GetAtomicValues()
                .Aggregate(default(HashCode), (hashCode, obj) =>
                {
                    hashCode.Add(obj.GetHashCode());

                    return hashCode;
                }).ToHashCode();
        protected abstract IEnumerable<object> GetAtomicValues();
    }
}
