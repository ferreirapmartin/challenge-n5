using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Core;
using ChallengeN5.Infr.DataAccess.Core;
using ChallengeN5.Infr.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeN5.Infr.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrDataAccess(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<DatabaseContext>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();

            return services;
        }
    }
}