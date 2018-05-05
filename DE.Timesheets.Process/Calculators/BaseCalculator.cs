using System.Collections.Generic;
using System.Linq;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;
using DE.Timesheets.Domain.References;
using DE.Timesheets.Process.Helpers;

namespace DE.Timesheets.Process.Calculators
{
    internal abstract class BaseCalculator
    {
        protected VerlofTeller GetTeller(VerlofType type, IEnumerable<VerlofHistoriek> historiek, int totaalDagen)
        {
            var verlofHistoriek = historiek as VerlofHistoriek[] ?? historiek.Where(h => h.Type == type.Id).ToArray();

            var inAanvraag = verlofHistoriek.Where(h => h.Status == VerlofStatus.InAanvraag.Id).Sum();
            var genomen = verlofHistoriek.Where(h => h.Status == VerlofStatus.Goedgekeurd.Id).Sum();
            var beschikbaar = totaalDagen - inAanvraag - genomen;

            return new VerlofTeller
            {
                Type = type,
                Beschikbaar = beschikbaar,
                InAanvraag = inAanvraag,
                Genomen = genomen
            };
        }
    }
}
