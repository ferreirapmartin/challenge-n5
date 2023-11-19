using ChallengeN5.Application.Core;

namespace ChallengeN5.Application.Exceptions
{
    public class PermissionNotFoundException : AppException
    {
        public PermissionNotFoundException() : base("The permission does not exist") { }
    }
}
