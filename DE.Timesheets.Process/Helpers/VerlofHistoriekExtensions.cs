using System.Collections.Generic;
using System.Linq;
using DE.Timesheets.Domain.Entities;
using DE.Timesheets.Domain.References;

namespace DE.Timesheets.Process.Helpers
{
    public static class VerlofHistoriekExtensions
    {
        public static decimal Sum(this IEnumerable<VerlofHistoriek> historiek)
        {
            var verlofHistoriek = historiek as VerlofHistoriek[] ?? historiek.ToArray();

            return !verlofHistoriek.Any()
                ? 0
                : verlofHistoriek.Aggregate<VerlofHistoriek, decimal>(0, (current, histo) => current + EenheidsType.GetById(histo.EenheidsType).Eenheid);
        }
    }
}
