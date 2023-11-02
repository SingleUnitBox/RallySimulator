using RallySimulator.Domain.Primitives;
using RallySimulator.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallySimulator.Domain.Core
{
    public sealed class VehicleTypeRepairmentLength : Entity
    {
        private VehicleTypeRepairmentLength()
        {
            
        }
        public VehicleTypeRepairmentLength(VehicleType vehicleType, int repairmentLengthInHours)
            : base((int)vehicleType)
        {
            Ensure.GreaterThanOrEqualToZero(repairmentLengthInHours,
                "The repairment length must be greater than or equal to zero.",
                nameof(repairmentLengthInHours));
        }
        public VehicleType VehicleType => (VehicleType)Id;
        public int RepairmentLengthInHours { get; private set; }
    }
}
