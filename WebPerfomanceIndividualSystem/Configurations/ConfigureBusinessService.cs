using Microsoft.EntityFrameworkCore.Migrations;
using PerformanceIndividualBusiness.Interfaces;
using PerformanceIndividualBusiness.Repositories;
using WebPerfomanceIndividualSystem.Services;

namespace WebPerfomanceIndividualSystem.Configurations
{
    public static class ConfigureBusinessService
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<AuthService>();
            return services;
        }
    }
}
