using ChallengeN5.Domain.AggregateRoots.Permission;
using ChallengeN5.Domain.Contracts;
using ChallengeN5.Infr.AnalyticsStore.Indices;
using Nest;


namespace ChallengeN5.Infr.AnalyticsStore.Repositories
{
    public class PermissionAnalyticsRepository : IPermissionAnalyticsRepository
    {
        private readonly IElasticClient _elasticClient;

        public PermissionAnalyticsRepository(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public string IndexName { get; } = "indexpermission";

        public async Task InsertAsync(Permission permission)
        {
            var model = new PermissionIndex(permission);

            var response = await _elasticClient.IndexAsync(model, descriptor => descriptor.Index(IndexName));

            if (!response.IsValid)
                throw new Exception(response.ServerError?.ToString(), response.OriginalException);
        }

        public async Task InsertManyAsync(IList<Permission> permissions)
        {
            var response = await _elasticClient.IndexManyAsync(permissions.Select(i => new PermissionIndex(i)).ToList(), IndexName);

            if (!response.IsValid)
                throw new Exception(response.ServerError?.ToString(), response.OriginalException);
        }
    }
}
