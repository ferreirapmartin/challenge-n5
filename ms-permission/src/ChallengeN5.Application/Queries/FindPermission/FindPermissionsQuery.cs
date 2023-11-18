using ChallengeN5.Application.DTOs;
using MediatR;

namespace ChallengeN5.Application.Queries.FindPermission
{
    public class FindPermissionsQuery : IRequest<IEnumerable<PermissionDTO>>
    {
    }
}
