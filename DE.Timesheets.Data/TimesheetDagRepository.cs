using System;
using System.Collections.Generic;
using System.Linq;
using DE.Timesheets.Domain.Entities;

namespace DE.Timesheets.Data
{
    internal sealed class TimesheetDagRepository : ITimesheetDagRepository
    {
        private readonly ApplicationDbContext _context;

        public TimesheetDagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TimesheetDag> GetByUserIdAndMonth(Guid userId, int maand, int jaar)
        {
            return _context.TimesheetDagen.Where(d => d.UserId == userId && d.Datum.Month == maand && d.Datum.Year == jaar);

        }
    }
}
