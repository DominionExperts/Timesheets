using System.Collections.Generic;
using DE.Timesheets.Domain.Entities;
using DE.Timesheets.Process.Helpers;
using DE.Timesheets.Service.Models;

namespace DE.Timesheets.Service.Builders
{
    public interface ITimesheetBuilder
    {
        TimesheetModel Build(int maand, int jaar, TimesheetDag[] timesheetDagen, VerlofHistoriek[] historiek, Feestdag[] feestdagen);
    }
}
