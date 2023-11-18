using ChallengeN5.Application.Core;
using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Events;

namespace ChallengeN5.Application.EventHandlers
{
    public class PermissionsFoundEventHandler : EventHandlerBase<PermissionsFoundEvent>
    {
        private readonly IPermissionAnalyticsRepository permissionAnalyticsRepository;

        public PermissionsFoundEventHandler(IServiceProvider serviceProvider, IPermissionAnalyticsRepository permissionAnalyticsRepository) : base(serviceProvider)
        {
            this.permissionAnalyticsRepository = permissionAnalyticsRepository;
        }

        public override async Task Handle(PermissionsFoundEvent notification, CancellationToken cancellationToken)
        {
            await base.Handle(notification, cancellationToken);
            await this.permissionAnalyticsRepository.InsertManyAsync(notification.Permissions.ToList());
        }
    }
}
