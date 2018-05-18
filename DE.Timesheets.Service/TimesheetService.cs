using System;
using System.Linq;
using DE.Timesheets.Process;
using DE.Timesheets.Service.Builders;
using DE.Timesheets.Service.Mappers;
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

        public TimesheetModel Get(Guid userId, int maand, int jaar)
        {
            var savedTimesheetDagen = _timesheetProcess.Get(userId, maand, jaar).ToArray();
            var maandHistoriek = _verlofProcess.GetHistoriekByMonth(userId, maand, jaar).ToArray();
            var feestdagen = _verlofProcess.GetWettelijkeFeestdagen(jaar).ToArray();

            return _builder.Build(maand, jaar, savedTimesheetDagen, maandHistoriek, feestdagen);
        }

        public void Update(SaveTimesheetDagModel dag)
        {
            var entity = ModelToDomainMapper.Map(dag);
            _timesheetProcess.Update(entity);
        }
    }
}
