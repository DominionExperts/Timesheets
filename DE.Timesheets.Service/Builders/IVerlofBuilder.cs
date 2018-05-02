using System;
using System.Collections.Generic;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;
using DE.Timesheets.Service.Models;

namespace DE.Timesheets.Service.Builders
{
    public interface IVerlofBuilder
    {
        VerlofModel Build(Guid userId, IEnumerable<VerlofHistoriek> historiek, IEnumerable<VerlofTeller> tellers);
    }
}