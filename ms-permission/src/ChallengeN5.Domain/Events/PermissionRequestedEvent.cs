using ChallengeN5.Domain.AggregateRoots.Permission;
using ChallengeN5.Domain.Core;

namespace ChallengeN5.Domain.Events
{
    public class PermissionRequestedEvent : BaseEvent
    {
        public Permission Permission { get; }
        public string Forename { get; }
        public string Surname { get; }
        public PermissionType Type { get; }


        public PermissionRequestedEvent(Permission permission, string forename, string surname, PermissionType permissionType) : base("request")
        {
            Forename = forename;
            Surname = surname;
            Type = permissionType;
            Permission = permission;
        }
    }
}
