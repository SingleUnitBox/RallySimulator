using RallySimulator.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallySimulator.Domain.Core
{
    public sealed class Malfunction : Entity, IAuditableEntity
    {
        public int VehicleId { get; private set; }
        public MalfunctionType Type { get; private set; }

        public DateTime CreatedOnUtc { get; }

        public DateTime? ModifiedOnUtc { get; }
        private Malfunction()
        {
            
        }
        public Malfunction(Vehicle vehicle, MalfunctionType malfunctionType)
        {
            VehicleId = vehicle.Id;
            Type = malfunctionType;
        }
    }
}
