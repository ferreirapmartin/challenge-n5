using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Core;
using ChallengeN5.Infr.DataAccess.Repositories;

namespace ChallengeN5.Infr.DataAccess.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext context;
        private bool disposed = false;

        public UnitOfWork(DatabaseContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IPermissionRepository PermissionRepository => new PermissionRepository(context);

        public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();

        public int SaveChanges() => context.SaveChanges();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing) context.Dispose();

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
