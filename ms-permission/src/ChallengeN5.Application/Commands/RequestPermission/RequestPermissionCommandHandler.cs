using ChallengeN5.Domain.AggregateRoots.Permission;
using ChallengeN5.Domain.Core;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeN5.Application.Commands.RequestPermission
{
    public class RequestPermissionCommandHandler : IRequestHandler<RequestPermissionCommand>
    {
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        private readonly IServiceProvider _serviceProvider;

        public RequestPermissionCommandHandler(IDomainEventDispatcher domainEventDispatcher, IServiceProvider serviceProvider)
        {
            _domainEventDispatcher = domainEventDispatcher;
            _serviceProvider = serviceProvider;
        }

        public async Task Handle(RequestPermissionCommand request, CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>())
                {
                    var permissionType = await uow.PermissionRepository.GetPermissionTypeById(request.PermissionType);

                    var permission = new Permission(request.Forename, request.Surname, permissionType);

                    uow.PermissionRepository.Add(permission);
                    await uow.SaveChangesAsync();

                    await _domainEventDispatcher.DispatchEventsAsync(permission);
                }
            }
        }
    }
}
