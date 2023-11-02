using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallySimulator.Domain.Primitives
{
    public interface IAuditableEntity
    {
        DateTime CreatedOnUtc { get; }
        DateTime? ModifiedOnUtc { get; }
    }
}
