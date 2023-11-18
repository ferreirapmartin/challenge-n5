using MediatR;

namespace ChallengeN5.Domain.Core
{
    public interface IDomainEventDispatcher
    {
        Task Publish(INotification notification);
        Task DispatchEventsAsync<T>(T aggregate) where T : AggregateRoot;
    }
}
