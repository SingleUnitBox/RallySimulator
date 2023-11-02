using RallySimulator.Domain.Core.Errors;
using RallySimulator.Domain.Primitives;
using RallySimulator.Domain.Primitives.Result;
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
        private readonly List<Malfunction> _malfunctions = new List<Malfunction>();
        public int RaceId { get; private set; }
        public TeamName TeamName { get; private set; }
        public ModelName ModelName { get; private set; }
        public DateTime ManufacturingDate { get; private set; }
        public VehicleType VehicleType { get; private set; }
        public VehicleSubtype VehicleSubtype { get; private set; }
        public VehicleSubtypeSpeed VehicleSubtypeSpeed { get; private set; }
        public VehicleTypeRepairmentLength VehicleTypeRepairmentLength { get; private set; }
        public VehicleSubtypeMalfunctionProbability VehicleSubtypeMalfunctionProbability { get; private set; }
        public IReadOnlyCollection<Malfunction> Malfunctions => _malfunctions.ToList();
        public VehicleStatus Status { get; private set; }
        public LengthInKilometers DistanceCovered { get; private set; }
        public DateTime? RepairCompletesOnUtc { get; private set; }
        public DateTime? StartTimeUtc { get; private set; }
        public DateTime? FinishTimeUtc { get; private set; }
        public DateTime CreatedOnUtc { get; }
        public DateTime? ModifiedOnUtc { get; }
        private Vehicle()
        {
            
        }
        public Vehicle(
            int raceId,
            TeamName teamName,
            ModelName modelName,
            DateTime manufacturingDate,
            VehicleType vehicleType,
            VehicleSubtype vehicleSubtype)
            : base (raceId)
        {
            Ensure.GreaterThanZero(raceId, "The race id is required.", nameof(raceId));
            Ensure.NotNull(teamName, "The team name is required.", nameof(teamName));
            Ensure.NotNull(modelName, "The model name is required.", nameof(modelName));
            Ensure.NotEmpty(manufacturingDate, "The manufacturing date is required", nameof(manufacturingDate));

            TeamName = teamName;
            ModelName = modelName;
            ManufacturingDate = manufacturingDate;
            VehicleType = vehicleType;
            VehicleSubtype = vehicleSubtype;
            Status = VehicleStatus.Pending;
            DistanceCovered = LengthInKilometers.Zero;
        }
        private bool Pending => Status == VehicleStatus.Pending;
        private bool Broken => Status == VehicleStatus.Broken;
        private bool WaitingForRepair => Status == VehicleStatus.WaitingForRepair && RepairCompletesOnUtc.HasValue;
        public Result UpdateInformation(
            TeamName teamName,
            ModelName modelName,
            DateTime manufacturingDate,
            VehicleType vehicleType,
            VehicleSubtype vehicleSubtype)
        {
            if (!Pending)
            {
                return Result.Failure(DomainErrors.Vehicle.RaceHasStarted);
            }

            Ensure.NotNull(teamName, "The team name is required.", nameof(teamName));
            Ensure.NotNull(modelName, "The model name is required", nameof(modelName));
            Ensure.NotEmpty(manufacturingDate, "The manufacturing date is required.", nameof(manufacturingDate));

            TeamName = teamName;
            ModelName = modelName;
            ManufacturingDate = manufacturingDate;
            VehicleType = vehicleType;
            VehicleSubtype = vehicleSubtype;

            return Result.Success();
        }
        public Result AddLightMalfunction(DateTime utcNow)
        {
            Result result = CheckIfVehicleCanSufferMalfunction();
            if (result.IsFailure)
            {
                return result;
            }
            AddMalfunction(MalfunctionType.Light);

            Status = VehicleStatus.WaitingForRepair;

            RepairCompletesOnUtc = utcNow.AddHours(VehicleTypeRepairmentLength.RepairmentLengthInHours);

            return Result.Success();
        }
        public void ChangeDistance(LengthInKilometers distance) => DistanceCovered = distance;
        public void StartRace(DateTime utcNow)
        {
            // TODO: add valid??
            Status = VehicleStatus.Racing;
            StartTimeUtc = utcNow;
        }
        public void Repair()
        {
            // TODO: add valid??
            Status = VehicleStatus.Racing;
            RepairCompletesOnUtc = null;
        }
        public void CompleteRace(DateTime utcNow)
        {
            Status = VehicleStatus.CompletedRace;
            FinishTimeUtc = utcNow;
        }
        private void AddMalfunction(MalfunctionType malfunctionType)
        {
            _malfunctions.Add(new Malfunction(this, malfunctionType));
        }

        private Result CheckIfVehicleCanSufferMalfunction()
        {
            if (Pending)
            {
                return Result.Failure(DomainErrors.Vehicle.RaceHasStarted);
            }
            if (Broken)
            {
                return Result.Failure(DomainErrors.Vehicle.Broken);
            }
            if (WaitingForRepair)
            {
                return Result.Failure(DomainErrors.Vehicle.WaitingForRepair);
            }
            return Result.Success();
        }

    }
}
