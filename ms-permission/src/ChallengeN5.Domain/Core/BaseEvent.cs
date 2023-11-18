using MediatR;

namespace ChallengeN5.Domain.Core
{
    public abstract class BaseEvent: INotification
    {
        public string EventType { get; }

        public Guid EventId { get; }

        protected BaseEvent(string eventType)
        {
            EventId = Guid.NewGuid();
            EventType = eventType;
        }
    }
}
