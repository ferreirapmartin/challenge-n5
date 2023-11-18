using ChallengeN5.Domain.Contracts;

namespace ChallengeN5.Domain.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPermissionRepository PermissionRepository { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
