using ChallengeN5.Application.Core;
using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Events;

namespace ChallengeN5.Application.EventHandlers
{
    public class PermissionUpdatedEventHandler : EventHandlerBase<PermissionUpdatedEvent>
    {
        private readonly IPermissionAnalyticsRepository permissionAnalyticsRepository;

        public PermissionUpdatedEventHandler(IServiceProvider serviceProvider, IPermissionAnalyticsRepository permissionAnalyticsRepository) : base(serviceProvider)
        {
            this.permissionAnalyticsRepository = permissionAnalyticsRepository;
        }

        public override async Task Handle(PermissionUpdatedEvent notification, CancellationToken cancellationToken)
        {
            await base.Handle(notification, cancellationToken);
            await this.permissionAnalyticsRepository.InsertAsync(notification.Permission);
        }
    }
}
