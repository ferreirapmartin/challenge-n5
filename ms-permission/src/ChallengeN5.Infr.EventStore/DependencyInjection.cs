using ChallengeN5.Domain.Contracts;
using ChallengeN5.Infr.EventStore.Config;
using ChallengeN5.Infr.EventStore.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeN5.Infr.EventStore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrEventStore(this IServiceCollection services)
        {
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();

            return services;
        }
    }
}
