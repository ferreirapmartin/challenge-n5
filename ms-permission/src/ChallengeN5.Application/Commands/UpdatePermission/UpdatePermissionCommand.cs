using MediatR;

namespace ChallengeN5.Application.Commands.UpdatePermission
{
    public class UpdatePermissionCommand : IRequest
    {
        public UpdatePermissionCommand(int id, string forename, string surname, int type)
        {
            Id = id;
            Forename = forename;
            Surname = surname;
            Type = type;
        }

        public int Id { get; }
        public string Forename { get; }
        public string Surname { get; }
        public int Type { get; }
    }
}
