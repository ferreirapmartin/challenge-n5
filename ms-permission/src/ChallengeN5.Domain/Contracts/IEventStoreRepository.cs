using ChallengeN5.Domain.Core;

namespace ChallengeN5.Domain.Contracts
{
    public interface IEventStoreRepository
    {
        Task SaveAsync(BaseEvent @event);
    }
}
