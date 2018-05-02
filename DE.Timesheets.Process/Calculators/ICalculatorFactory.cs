using System;
using System.Collections.Generic;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;
using DE.Timesheets.Domain.References;

namespace DE.Timesheets.Process.Calculators
{
    public interface ICalculatorFactory
    {
        VerlofTeller GeTeller(int verlofTypeId, int jaar, Guid userId, IEnumerable<VerlofHistoriek> historiek);
    }
}
