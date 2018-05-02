using System;
using System.Collections.Generic;
using DE.Timesheets.Domain.Entities;

namespace DE.Timesheets.Process
{
    public interface ITimesheetProcess
    {
        IEnumerable<TimesheetDag> Get(Guid userId, int maand);
    }
}