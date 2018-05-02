using System;
using System.Collections.Generic;
using DE.Timesheets.Domain.Entities;

namespace DE.Timesheets.Data
{
    public interface ITimesheetDagRepository
    {
        IEnumerable<TimesheetDag> GetByUserIdAndMonth(Guid userId, int maand, int jaar);
    }
}