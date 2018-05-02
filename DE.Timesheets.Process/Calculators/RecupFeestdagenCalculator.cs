using System;
using System.Collections.Generic;
using System.Linq;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;
using DE.Timesheets.Domain.References;
using DE.Timesheets.Process.Helpers;

namespace DE.Timesheets.Process.Calculators
{
    internal sealed class RecupFeestdagenCalculator : BaseCalculator, IRecupFeestdagenCalculator
    {
        public VerlofTeller Calculate(int jaar, Guid userId, IEnumerable<VerlofHistoriek> historiek)
        {
            var helper = new FeestdagenHelper(jaar);
            var totaalRecupFeestdagen = helper.WettelijkeFeestdagen().Count(f => f.InWeekend);

            return GetTeller(VerlofType.RecupFeestdagen, historiek, totaalRecupFeestdagen);
        }
    }
}
