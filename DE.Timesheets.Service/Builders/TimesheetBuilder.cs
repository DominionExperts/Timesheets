using System.Collections.Generic;
using DE.Timesheets.Domain.Entities;
using DE.Timesheets.Process.Helpers;
using DE.Timesheets.Service.Models;

namespace DE.Timesheets.Service.Builders
{
    internal sealed class TimesheetBuilder : ITimesheetBuilder
    {
        public TimesheetModel Build(IEnumerable<TimesheetDag> timesheetDagen, IEnumerable<VerlofHistoriek> historiek, IEnumerable<Feestdag> feestdagen)
        {
            //TODO add timesheets
            //TODO get verlofhistoriek
            //TODO get feestdagen
            return new TimesheetModel();
        }
    }
}
