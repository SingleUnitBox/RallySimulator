using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallySimulator.Domain.Core
{
    public enum VehicleStatus
    {
        Pending = 0,
        Racing = 1,
        WaitingForRepair = 2,
        Broken = 3,
        CompletedRace = 4,
    }
}
