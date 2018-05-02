using System.Collections.Generic;
using System.Linq;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;
using DE.Timesheets.Domain.References;

namespace DE.Timesheets.Process.Calculators
{
    internal abstract class BaseCalculator
    {
        protected VerlofTeller GetTeller(VerlofType type, IEnumerable<VerlofHistoriek> historiek, int totaalDagen)
        {
            var verlofHistoriek = historiek as VerlofHistoriek[] ?? historiek.Where(h => h.Type == type.Id).ToArray();

            var inAanvraag = GetSum(verlofHistoriek.Where(h => h.Status == VerlofStatus.InAanvraag.Id));
            var genomen = GetSum(verlofHistoriek.Where(h => h.Status == VerlofStatus.Goedgekeurd.Id));
            var beschikbaar = totaalDagen - inAanvraag - genomen;

            return new VerlofTeller
            {
                Type = type,
                Beschikbaar = beschikbaar,
                InAanvraag = inAanvraag,
                Genomen = genomen
            };
        }

        private static decimal GetSum(IEnumerable<VerlofHistoriek> historiek)
        {
            var verlofHistoriek = historiek as VerlofHistoriek[] ?? historiek.ToArray();

            return !verlofHistoriek.Any()
                ? 0
                : verlofHistoriek.Aggregate<VerlofHistoriek, decimal>(0, (current, histo) => current + EenheidsType.GetById(histo.EenheidsType).Eenheid);
        }

    }
}
