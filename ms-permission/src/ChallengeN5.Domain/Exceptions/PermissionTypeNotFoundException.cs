using ChallengeN5.Domain.Core;

namespace ChallengeN5.Domain.Exceptions
{
    public class PermissionTypeNotFoundException : BusinessException
    {
        public PermissionTypeNotFoundException() : base("The permission type does not exist")
        { }
    }
}
