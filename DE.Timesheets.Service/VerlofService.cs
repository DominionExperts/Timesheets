using System;
using DE.Timesheets.Process;
using DE.Timesheets.Service.Builders;
using DE.Timesheets.Service.Models;

namespace DE.Timesheets.Service
{
    internal sealed class VerlofService : IVerlofService
    {
        private readonly IVerlofProcess _process;
        private readonly IVerlofBuilder _builder;

        public VerlofService(IVerlofProcess process, IVerlofBuilder builder)
        {
            _process = process;
            _builder = builder;
        }

        public VerlofModel Get(Guid userId, int jaar)
        {
            var historiek = _process.GetHistoriek(userId, jaar);
            var tellers = _process.GetTellers(userId, jaar);

            return _builder.Build(userId, historiek, tellers);
        }
    }
}
