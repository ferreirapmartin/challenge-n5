using MediatR;

namespace ChallengeN5.Domain.Core
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IPublisher _mediator;

        public DomainEventDispatcher(IPublisher mediator)
        {
            _mediator = mediator;
        }

        public async Task Publish(INotification notification) => await _mediator.Publish(notification);

        public async Task DispatchEventsAsync<T>(T aggregate) where T : AggregateRoot
        {
            foreach (var domainEvent in aggregate.GetUncommittedChanges())
            {
                await Publish(domainEvent);
            }

            aggregate.MarkChangesAsCommitted();
        }
    }
}
