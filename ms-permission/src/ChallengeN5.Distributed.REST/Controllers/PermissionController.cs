using ChallengeN5.Application.Commands.RequestPermission;
using ChallengeN5.Application.Commands.UpdatePermission;
using ChallengeN5.Application.Exceptions;
using ChallengeN5.Application.Queries.FindPermission;
using ChallengeN5.Distributed.REST.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeN5.Distributed.REST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly ISender _mediator;

        public PermissionController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "FindPermission")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Find()
        {
            var result = await _mediator.Send(new FindPermissionsQuery());

            return Ok(result);
        }

        [HttpPost(Name = "RequestPermission")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] RequestPermissionModel request)
        {
            await _mediator.Send(new RequestPermissionCommand(request.Forename, request.Surname, request.Type.Value));

            return Created();
        }

        [HttpPut("{id}", Name = "ModifyPermission")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, UpdatePermissionModel request)
        {
            try
            {
                await _mediator.Send(new UpdatePermissionCommand(id, request.Forename, request.Surname, request.Type.Value));
            }
            catch (PermissionNotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
