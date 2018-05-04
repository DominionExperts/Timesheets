using DE.Timesheets.Process;
using DE.Timesheets.Service.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace DE.Timesheets.Service
{
    public sealed class BindServices
    {
        public static void Execute(IServiceCollection services)
        {
            services.AddTransient<IVerlofService, VerlofService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITimesheetService, TimesheetService>();

            services.AddTransient<IVerlofBuilder, VerlofBuilder>();
            services.AddTransient<ITimesheetBuilder, TimesheetBuilder>();

            BindProcesses.Execute(services);
        }

    }
}
