using System;

namespace DE.Timesheets.Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime ModificationDate { get; set; }
    }
}
