using DTOs;

using Microsoft.AspNetCore.Mvc;


using RepositoriesIAuthenticate.IAuthenticate;

namespace ControllersCAuthenticate.CAuthenticate
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticate _authenticationService;

        public AuthenticateController(IAuthenticate authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("validate-login")]
        public IActionResult ValidateLogin([FromBody] LoginRequest  request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.UserMail) || string.IsNullOrWhiteSpace(request.UserPassword))
                {
                    return BadRequest("Please enter the data");
                }

                var validatedUser = _authenticationService.ValidateUser(request.UserMail, request.UserPassword);

                if (validatedUser == null)
                {
                    return Unauthorized("User not found or invalid credentials");
                }

                string token = _authenticationService.GenerateToken(validatedUser.UserId, validatedUser.UserName);

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
