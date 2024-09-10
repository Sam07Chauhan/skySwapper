using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace skySwapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController(ILogger logger)
        {
            Logger = logger;
        }

        public Microsoft.Extensions.Logging.ILogger Logger { get; }
    }
}
