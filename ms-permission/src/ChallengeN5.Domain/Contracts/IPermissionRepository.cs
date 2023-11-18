using ChallengeN5.Domain.AggregateRoots.Permission;

namespace ChallengeN5.Domain.Contracts
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetAll();
        Task<Permission?> GetById(int id);
        void Add(Permission entity);
    }
}
