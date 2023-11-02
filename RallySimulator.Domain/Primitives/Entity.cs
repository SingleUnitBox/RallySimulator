using RallySimulator.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallySimulator.Domain.Primitives
{
    public abstract class Entity : IEquatable<Entity>
    {
        public int Id { get; private set; }
        protected Entity()
        {
            
        }
        protected Entity(int id)
        {
            Ensure.NotLessThanOrEqualToZero(id, "The entity identifier is required", nameof(id));
            Id = id;
        }
        public static bool operator ==(Entity left, Entity right)
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
        public static bool operator !=(Entity left, Entity right) => !(left == right);
        public bool Equals(Entity? other)
        {
            if (other is null)
            {
                return false;
            }
            return ReferenceEquals(this, other) || Id == other.Id;
        }
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            if (!(obj is Entity other))
            {
                return false;
            }

            return Id == other.Id;
        }
        public override int GetHashCode() => Id.GetHashCode() * 41;

    }
}
