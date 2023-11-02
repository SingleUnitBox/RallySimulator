using RallySimulator.Domain.Primitives;
using RallySimulator.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallySimulator.Domain.Core
{
    public sealed class Vehicle : Entity, IAuditableEntity
    {
        public Vehicle(
            int id,
            TeamName teamName,
            ModelName modelName,
            DateTime manufacturingDate,
            VehicleType vehicleType,
            VehicleSubtype vehicleSubtype)
            : base (id)
        {
            Ensure.NotNull(teamName, "The team name is required.", nameof(teamName));
            Ensure.NotNull(modelName, "The model name is required.", nameof(modelName));
            Ensure.NotEmpty(manufacturingDate, "The manufacturing date is required", nameof(manufacturingDate));

            TeamName = teamName;
            ModelName = modelName;
            ManufacturingDate = manufacturingDate;
            VehicleType = vehicleType;
            VehicleSubtype = vehicleSubtype;
        }
        public TeamName TeamName { get; private set; }
        public ModelName ModelName { get; private set; }
        public DateTime ManufacturingDate { get; private set; }
        public VehicleType VehicleType { get; private set; }
        public VehicleSubtype VehicleSubtype { get; private set; }
        public VehicleSubtypeSpeed VehicleSubtypeSpeed { get; private set; }
        public VehicleTypeRepairmentLength VehicleTypeRepairmentLength { get; private set; }
        public VehicleSubtypeMalfunctionProbability VehicleSubtypeMalfunctionProbability { get; private set; }

        public DateTime CreatedOnUtc { get; }

        public DateTime? ModifiedOnUtc { get; }
    }
}
