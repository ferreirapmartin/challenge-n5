using ChallengeN5.Domain.AggregateRoots.Permission;
using ChallengeN5.Domain.Core;

namespace ChallengeN5.Domain.Events
{
    public class PermissionRequestedEvent : BaseEvent
    {
        public Permission Permission { get; }
        public string Forename { get; }
        public string Surname { get; }
        public int Type { get; }


        public PermissionRequestedEvent(Permission permission, string forename, string surname, int type) : base("request")
        {
            Forename = forename;
            Surname = surname;
            Type = type;
            Permission = permission;
        }
    }
}
