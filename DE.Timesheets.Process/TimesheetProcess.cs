using System;
using System.Collections.Generic;
using DE.Timesheets.Data;
using DE.Timesheets.Domain.Entities;

namespace DE.Timesheets.Process
{
    internal sealed class TimesheetProcess : ITimesheetProcess
    {
        private readonly ITimesheetDagRepository _repository;

        public TimesheetProcess(ITimesheetDagRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TimesheetDag> Get(Guid userId, int maand)
        {
            var jaar = DateTime.Now.Year;

            return _repository.GetByUserIdAndMonth(userId, maand, jaar);
        }
    }
}
