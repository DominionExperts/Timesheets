using System;
using System.Collections.Generic;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;

namespace DE.Timesheets.Process.Calculators
{
    public interface ICalculator
    {
        VerlofTeller Calculate(int jaar, Guid userId, IEnumerable<VerlofHistoriek> historiek);
    }
}