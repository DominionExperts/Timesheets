using System;
using System.Collections.Generic;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;
using DE.Timesheets.Process.Helpers;

namespace DE.Timesheets.Process
{
    public interface IVerlofProcess
    {
        IEnumerable<VerlofHistoriek> GetHistoriek(Guid userId);
        IEnumerable<VerlofHistoriek> GetHistoriekByMonth(Guid userId, int maand);
        IEnumerable<VerlofTeller> GetTellers(Guid userId);
        IEnumerable<Feestdag> GetWettelijkeFeestdagen();
    }
}
