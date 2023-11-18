using MediatR;

namespace ChallengeN5.Application.Commands.RequestPermission
{
    public class RequestPermissionCommand : IRequest
    {
        public RequestPermissionCommand(string forename, string surname, int permissionType)
        {
            Forename = forename;
            Surname = surname;
            PermissionType = permissionType;
        }

        public string Forename { get; }
        public string Surname { get; }
        public int PermissionType { get; }
    }
}
