using RallySimulator.Domain.Primitives;
using RallySimulator.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallySimulator.Domain.Core
{
    public sealed class VehicleSubtypeMalfunctionProbability : Entity
    {
        public VehicleSubtype VehicleSubtype => (VehicleSubtype)Id;
        public MalfunctionProbability LightMalfunctionProbability { get; private set; }
        public MalfunctionProbability HeavyMalfunctionProbabilty { get; private set; }
        private VehicleSubtypeMalfunctionProbability()
        {
            
        }
        public VehicleSubtypeMalfunctionProbability(
            VehicleSubtype vehicleSubtype,
            MalfunctionProbability lightMalfunctionProbability,
            MalfunctionProbability heavyMalfunctionProbability) : base((int)vehicleSubtype)
        {
            Ensure.NotNull(lightMalfunctionProbability,
                "The ligth malfunction probability is required",
                nameof(lightMalfunctionProbability));
            Ensure.NotNull(heavyMalfunctionProbability,
                "The heavy malfunction probability is required.",
                nameof(heavyMalfunctionProbability));

            LightMalfunctionProbability = lightMalfunctionProbability;
            HeavyMalfunctionProbabilty = heavyMalfunctionProbability;
        }
    }
}
