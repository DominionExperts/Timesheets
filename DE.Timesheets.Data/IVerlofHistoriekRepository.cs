using System;
using System.Collections.Generic;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;

namespace DE.Timesheets.Data
{
    public interface IVerlofHistoriekRepository
    {
        IEnumerable<VerlofHistoriek> GetByUserId(Guid userId, int jaar);
        IEnumerable<VerlofHistoriek> GetByUserIdAndMonth(Guid userId, int maand, int jaar);
    }
}