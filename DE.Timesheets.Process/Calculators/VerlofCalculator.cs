using System;
using System.Collections.Generic;
using DE.Timesheets.Data;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;
using DE.Timesheets.Domain.References;

namespace DE.Timesheets.Process.Calculators
{
    internal sealed class VerlofCalculator : BaseCalculator, IVerlofCalculator
    {
        private readonly IUserRepository _userRepository;

        public VerlofCalculator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public VerlofTeller Calculate(int jaar, Guid userId, IEnumerable<VerlofHistoriek> historiek)
        {
            var jaarlijksVerlof = _userRepository.Get(userId).JaarlijksVerlof;
            return GetTeller(VerlofType.Verlof, historiek, jaarlijksVerlof);
        }
    }
}
