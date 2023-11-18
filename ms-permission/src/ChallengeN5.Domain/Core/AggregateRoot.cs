using MediatR;

namespace ChallengeN5.Domain.Core
{
    public abstract class AggregateRoot
    {
        private readonly IList<INotification> _changes = new List<INotification>();

        public IReadOnlyCollection<INotification> GetUncommittedChanges() => _changes.AsReadOnly();

        public void MarkChangesAsCommitted() => _changes.Clear();

        protected void ApplyChange(INotification @event)
        {
            var method = GetType().GetMethod("Apply", [@event.GetType()]);

            if (method == null)
            {
                throw new ArgumentNullException(nameof(method), $"The Apply method was not found in the aggregate for {@event.GetType().Name}!");
            }

            method.Invoke(this, new object[] { @event });

            _changes.Add(@event);
        }
    }
}
