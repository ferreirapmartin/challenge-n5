using ChallengeN5.Domain.Core;
using MediatR;

namespace ChallengeN5.Infr.CQRS
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IPublisher _mediator;

        public DomainEventDispatcher(IPublisher mediator)
        {
            _mediator = mediator;
        }

        public async Task DispatchEventsAsync<T>(T aggregate) where T : AggregateRoot
        {
            foreach (var domainEvent in aggregate.GetUncommittedChanges())
            {
                await _mediator.Publish(domainEvent);
            }

            aggregate.MarkChangesAsCommitted();
        }
    }
}
