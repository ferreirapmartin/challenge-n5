using Microsoft.AspNetCore.Mvc;

namespace ChallengeN5.Distributed.REST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        public IActionResult ErrorHandler() => Problem();
    }
}
