using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebPerfomanceIndividualSystem.Models;

namespace PerformanceIndividualDataAccess
{
    public static class Dependencies
    {
        public static void ConfigureService(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<PerformanceAppsContext>
                (
                    options => options.UseNpgsql(configuration.GetConnectionString("PerformanceAppsConnection"))
                );
        }
    }
}
