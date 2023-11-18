using ChallengeN5.Domain.AggregateRoots.Permission;
using ChallengeN5.Domain.Core;

namespace ChallengeN5.Domain.Events
{
    public class PermissionsFoundEvent : BaseEvent
    {
        public PermissionsFoundEvent(IEnumerable<Permission> permissions) : base("get")
        {
            Permissions = permissions;
        }

        public IEnumerable<Permission> Permissions { get; }
    }
}
