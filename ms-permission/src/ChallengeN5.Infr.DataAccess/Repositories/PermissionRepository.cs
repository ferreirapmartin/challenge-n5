using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.AggregateRoots.Permission;
using ChallengeN5.Infr.DataAccess.Core;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN5.Infr.DataAccess.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly DatabaseContext context;

        public PermissionRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<List<Permission>> GetAll() => await context.Permissions.Include(i => i.Type).ToListAsync();


        public void Add(Permission entity) => context.Add(entity);

        public async Task<Permission?> GetById(int id) => await context.Permissions.Where(i => i.Id == id).Include(i => i.Type).FirstOrDefaultAsync();

        public async Task<PermissionType?> GetPermissionTypeById(int id) => await context.PermissionTypes.FirstOrDefaultAsync(i => i.Id == id);
    }
}
