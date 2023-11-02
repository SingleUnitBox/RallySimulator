using RallySimulator.Domain.Primitives;
using RallySimulator.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallySimulator.Domain.Core
{
    public sealed class VehicleSubtypeSpeed : Entity
    {
        public VehicleSubtype VehicleSubtype => (VehicleSubtype)Id;
        public SpeedInKilometersPerHour SpeedInKilometersPerHour { get; private set; }
        public VehicleSubtypeSpeed(VehicleSubtype vehicleSubtype, 
            SpeedInKilometersPerHour speedInKilometersPerHour) : base((int)vehicleSubtype)
        {
            Ensure.NotNull(speedInKilometersPerHour, "The speed is required", nameof(speedInKilometersPerHour));

            SpeedInKilometersPerHour = speedInKilometersPerHour;
        }
    }
}
