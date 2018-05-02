using System;
using System.Collections.Generic;
using System.Linq;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;

namespace DE.Timesheets.Data
{
    internal sealed class VerlofHistoriekRepository : IVerlofHistoriekRepository
    {
        private readonly ApplicationDbContext _context;

        public VerlofHistoriekRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<VerlofHistoriek> GetByUserId(Guid userId, int jaar)
        {
            return _context.VerlofHistoriek.Where(v => v.UserId == userId && v.Datum.Year == jaar);
        }

        public IEnumerable<VerlofHistoriek> GetByUserIdAndMonth(Guid userId, int maand, int jaar)
        {
            return _context.VerlofHistoriek.Where(v => v.UserId == userId && v.Datum.Month == maand && v.Datum.Year == jaar);
        }
    }
}
