using ChallengeN5.Domain.Core;
using ChallengeN5.Domain.Permission;
using ChallengeN5.Infr.DataAccess.Core;
using ChallengeN5.Infr.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeN5.Infr.IoC
{
    public static class ServiceCollectionExtension 
    {
        public static IServiceCollection AddInfrDataAccess(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddDbContext<DatabaseContext>();

            serviceCollection.AddScoped<IPermissionRepository, PermissionRepository>();

            return serviceCollection;
        }
    }
}
