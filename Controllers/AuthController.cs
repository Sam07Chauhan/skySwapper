using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using skySwapper.Data;
using skySwapper.IRepository;
using skySwapper.Model;

namespace skySwapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _token;

        public AuthController(ILogger logger,TokenService token,IUserRepo repo)
        {
            Logger = logger;
            _token = token;
            _Repo = repo;
        }

        public Microsoft.Extensions.Logging.ILogger Logger { get; }
        public IUserRepo _Repo { get; }

        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser(User user) 
        {
            if (user == null)
            {
                return BadRequest(ModelState);
            }
            var Check = _Repo.CheackUser(user.Email);
            if (!Check)
            {
                _Repo.CreateUser(user);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
            }
            return Ok("Successfully created");
        }
        [HttpPost("Login")]
        public IActionResult UserLogin(string email, string pwd)
        {
            // Validate input
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pwd))
            {
                return BadRequest("Please provide both email and password.");
            }

            // Check user credentials
            var usd = _Repo.GetUser(email, pwd);
            if (usd != null)
            {
                // Generate token (assuming TokenService is an instance, not static)
                var token = _token.GenerateToken(usd.Name, usd.Role);

                // Return token in response
                return Ok(new { token });
            }

            // If user not found or password is incorrect
            return Unauthorized("Invalid email or password.");
        }

    }
}
