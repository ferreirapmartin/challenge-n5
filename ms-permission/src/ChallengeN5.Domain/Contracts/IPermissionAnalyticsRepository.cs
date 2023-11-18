using ChallengeN5.Domain.AggregateRoots.Permission;

namespace ChallengeN5.Domain.Contracts
{
    public interface IPermissionAnalyticsRepository
    {
        Task InsertAsync(Permission permission);
        Task InsertManyAsync(IList<Permission> permissions);
    }
}
