using System;
using DE.Timesheets.Process;
using DE.Timesheets.Process.Helpers;
using DE.Timesheets.Service.Builders;
using DE.Timesheets.Service.Models;

namespace DE.Timesheets.Service
{
    internal sealed class TimesheetService : ITimesheetService
    {
        private readonly ITimesheetProcess _timesheetProcess;
        private readonly IVerlofProcess _verlofProcess;
        private readonly ITimesheetBuilder _builder;

        public TimesheetService(ITimesheetProcess timesheetProcess, IVerlofProcess verlofProcess, ITimesheetBuilder builder)
        {
            _timesheetProcess = timesheetProcess;
            _verlofProcess = verlofProcess;
            _builder = builder;
        }

        public TimesheetModel Get(Guid userId, int maand)
        {
            var savedTimesheetDagen = _timesheetProcess.Get(userId, maand);
            var maandHistoriek = _verlofProcess.GetHistoriekByMonth(userId, maand);
            var feestdagen = _verlofProcess.GetWettelijkeFeestdagen();

            return _builder.Build(savedTimesheetDagen, maandHistoriek, feestdagen);
        }
    }
}
