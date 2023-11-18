using ChallengeN5.Domain.Core;
using ChallengeN5.Domain.Events;

namespace ChallengeN5.Domain.AggregateRoots.Permission
{
    public class Permission : AggregateRoot
    {
        public int Id { get; set; }
        public string Forename { get; private set; }
        public string Surname { get; private set; }
        public int TypeId { get; private set; }
        public DateOnly CreatedDate { get; private set; }

        public PermissionType Type { get; private set; }

        private Permission() { }

        public Permission(string forename, string surname, int type)
        {
            ApplyChange(new PermissionRequestedEvent(this, forename, surname, type));
        }

        public void Apply(PermissionRequestedEvent @event)
        {
            Forename = @event.Forename;
            Surname = @event.Surname;
            TypeId = @event.Type;
            CreatedDate = DateOnly.FromDateTime(DateTime.Now);
        }

        public void Update(string forename, string surname, int type)
        {
            ApplyChange(new PermissionUpdatedEvent(this, Id, forename, surname, type));
        }

        public void Apply(PermissionUpdatedEvent @event)
        {
            Forename = @event.Forename;
            Surname = @event.Surname;
            TypeId = @event.Type;
        }
    }
}
