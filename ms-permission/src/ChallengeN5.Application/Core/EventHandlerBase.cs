using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Core;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeN5.Application.Core
{
    public abstract class EventHandlerBase<T> : INotificationHandler<T> where T : BaseEvent
    {
        private readonly IServiceProvider _serviceProvider;

        public EventHandlerBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public virtual async Task Handle(T notification, CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var eventStoreRepository = scope.ServiceProvider.GetRequiredService<IEventStoreRepository>();
                await eventStoreRepository.SaveAsync(notification);
            }
        }
    }
}
