using ChallengeN5.Domain.Contracts;
using ChallengeN5.Infr.AnalyticsStore.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace ChallengeN5.Infr.AnalyticsStore
{
    public static class DependencyInjection
    {
        private static ElasticClient GetElasticsearch(string uri)
        {
            var settings = new ConnectionSettings(new Uri(uri)).EnableApiVersioningHeader();

            return new ElasticClient(settings);
        }

        public static IServiceCollection AddInfrAnalytics(this IServiceCollection services, string uri)
        {
            services.AddSingleton<IElasticClient>(GetElasticsearch(uri));
            services.AddTransient<IPermissionAnalyticsRepository, PermissionAnalyticsRepository>();

            return services;
        }
    }
}
