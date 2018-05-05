using System;
using System.Collections.Generic;
using System.Linq;
using DE.Timesheets.Data;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;
using DE.Timesheets.Domain.References;
using DE.Timesheets.Process.Calculators;
using DE.Timesheets.Process.Helpers;

namespace DE.Timesheets.Process
{
    internal sealed class VerlofProcess : IVerlofProcess
    {
        private readonly IVerlofHistoriekRepository _verlofHistoriekRepository;
        private readonly ICalculatorFactory _factory;

        public VerlofProcess(IVerlofHistoriekRepository verlofHistoriekRepository, ICalculatorFactory factory)
        {
            _verlofHistoriekRepository = verlofHistoriekRepository;
            _factory = factory;
        }

        public IEnumerable<VerlofHistoriek> GetHistoriek(Guid userId, int jaar)
        {
            return _verlofHistoriekRepository.GetByUserId(userId, jaar);
        }


        public IEnumerable<VerlofHistoriek> GetHistoriekByMonth(Guid userId, int maand, int jaar)
        {
            return _verlofHistoriekRepository.GetByUserIdAndMonth(userId, maand, jaar);
        }

        public IEnumerable<Feestdag> GetWettelijkeFeestdagen(int jaar)
        {
            var helper = new FeestdagenHelper(jaar);
            return helper.WettelijkeFeestdagen();
        }

        public IEnumerable<VerlofTeller> GetTellers(Guid userId, int jaar)
        {
            var historiek = _verlofHistoriekRepository.GetByUserId(userId, jaar);

            var tellers = new List<VerlofTeller>(VerlofType.List.Count());
            tellers.AddRange(VerlofType.List
                .Select(verlofType => _factory.GeTeller(verlofType.Id, jaar, userId, historiek))
                .Where(teller => teller != null));

            return tellers;
        }
    }
}
