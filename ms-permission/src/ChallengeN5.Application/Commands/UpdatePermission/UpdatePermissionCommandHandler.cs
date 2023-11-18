using ChallengeN5.Application.Exceptions;
using ChallengeN5.Domain.Core;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeN5.Application.Commands.UpdatePermission
{
    public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand>
    {
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        private readonly IServiceProvider _serviceProvider;

        public UpdatePermissionCommandHandler(IDomainEventDispatcher domainEventDispatcher, IServiceProvider serviceProvider)
        {
            _domainEventDispatcher = domainEventDispatcher;
            _serviceProvider = serviceProvider;
        }

        public async Task Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>())
                {
                    var permission = await uow.PermissionRepository.GetById(request.Id) ?? throw new PermissionNotFoundException();
                    permission.Update(request.Forename, request.Surname, request.Type);
                    uow.SaveChanges();

                    await _domainEventDispatcher.DispatchEventsAsync(permission);
                }
            }
        }
    }
}
