using DE.Timesheets.Data;
using DE.Timesheets.Process.Calculators;
using Microsoft.Extensions.DependencyInjection;

namespace DE.Timesheets.Process
{
    public sealed class BindProcesses
    {
        public static void Execute(IServiceCollection services)
        {
            services.AddTransient<IUserProcess, UserProcess>();
            services.AddTransient<IVerlofProcess, VerlofProcess>();
            services.AddTransient<ITimesheetProcess, TimesheetProcess>();

            services.AddTransient<ICalculatorFactory, CalculatorFactory>(f => new CalculatorFactory(services.BuildServiceProvider()));
            services.AddTransient<IVerlofCalculator, VerlofCalculator>();
            services.AddTransient<IRecupFeestdagenCalculator, RecupFeestdagenCalculator>();

            BindRepositories.Execute(services);
        }
    }
}
