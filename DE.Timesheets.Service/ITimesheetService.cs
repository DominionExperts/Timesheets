using System;
using DE.Timesheets.Service.Models;

namespace DE.Timesheets.Service
{
    public interface ITimesheetService
    {
        TimesheetModel Get(Guid userId, int maand, int jaar);
    }
}