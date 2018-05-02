using System;
using System.Collections.Generic;
using DE.Timesheets.Domain;
using DE.Timesheets.Domain.Entities;
using DE.Timesheets.Domain.References;
using Microsoft.Extensions.DependencyInjection;

namespace DE.Timesheets.Process.Calculators
{
    internal sealed class CalculatorFactory : ICalculatorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        internal CalculatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public VerlofTeller GeTeller(int verlofTypeId, int jaar, Guid userId, IEnumerable<VerlofHistoriek> historiek)
        {
            ICalculator calculator;

            switch (verlofTypeId)
            {
                case (int)VerlofType.VerlofTypeId.Verlof:
                    calculator = _serviceProvider.GetService<IVerlofCalculator>();
                    break;
                case (int)VerlofType.VerlofTypeId.RecupFeestdagen:
                    calculator = _serviceProvider.GetService<IRecupFeestdagenCalculator>();
                    break;
                default:
                    return null; //throw new ApplicationException($"Geen teller gevonden voor type {verlofTypeId}");
            }

            return calculator.Calculate(jaar, userId, historiek);
        }
    }
}
