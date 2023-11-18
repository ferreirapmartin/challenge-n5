using ChallengeN5.Application.DTOs;
using ChallengeN5.Domain.Core;
using ChallengeN5.Domain.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeN5.Application.Queries.FindPermission
{
    internal class FindPermissionsQueryHandler : IRequestHandler<FindPermissionsQuery, IEnumerable<PermissionDTO>>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public FindPermissionsQueryHandler(IServiceProvider serviceProvider, IDomainEventDispatcher domainEventDispatcher)
        {
            _serviceProvider = serviceProvider;
            _domainEventDispatcher = domainEventDispatcher;
        }

        public async Task<IEnumerable<PermissionDTO>> Handle(FindPermissionsQuery request, CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>())
                {
                    var permissions = await uow.PermissionRepository.GetAll();
                    await _domainEventDispatcher.Publish(new PermissionsFoundEvent(permissions));

                    return permissions.Select(i => new PermissionDTO()
                    {
                        Id = i.Id,
                        CreatedDate = i.CreatedDate,
                        Forename = i.Forename,
                        Surname = i.Surname,
                        TypeDescription = i.Type.Description,
                        TypeId = i.TypeId
                    }).ToList();
                }
            }
        }
    }
}