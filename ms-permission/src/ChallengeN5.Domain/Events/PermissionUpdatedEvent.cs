using ChallengeN5.Domain.AggregateRoots.Permission;
using ChallengeN5.Domain.Core;

namespace ChallengeN5.Domain.Events
{
    public class PermissionUpdatedEvent : BaseEvent
    {
        public PermissionUpdatedEvent(Permission permission, int id, string forename, string surname, int type) : base("modify")
        {
            Permission = permission;
            Id = id;
            Forename = forename;
            Surname = surname;
            Type = type;
        }

        public Permission Permission { get; }

        public int Id { get; }
        public string Forename { get; }
        public string Surname { get; }
        public int Type { get; }
    }
}
