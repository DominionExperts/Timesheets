using Microsoft.Extensions.DependencyInjection;

namespace DE.Timesheets.Data
{
    public sealed class BindRepositories
    {
        public static void Execute(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVerlofHistoriekRepository, VerlofHistoriekRepository>();
            services.AddScoped<ITimesheetDagRepository, TimesheetDagRepository>();
        }
    }
}
