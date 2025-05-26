using DTOs;
using Microsoft.AspNetCore.Mvc;
using ModelsUsers.Users;
using RepositoriesIAuthenticate.IAuthenticate;

namespace ControllersCAuthenticate.CAuthenticate
{
    [ApiController]
    [Route("[controller]")]
    public class CAuthenticateController : ControllerBase
    {
        private readonly IAuthenticate _authenticationUser;

        public CAuthenticateController(IAuthenticate authenticationUser)
        {
            this._authenticationUser = authenticationUser;
        }

        [HttpPost("/userValidateLogin")]
        public IActionResult Validate([FromBody] LoginRequest user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.UserMail) || string.IsNullOrEmpty(user.UserPassword))
                {
                    return BadRequest("Please enter the data");
                }

                var validatedResult = this._authenticationUser.ValidateUser(user.UserMail, user.UserPassword);

                if (validatedResult.user == null)
                {
                    throw new Exception("User Not found");
                }

                // Aquí generas el token con id, userProfilesId y username
                string token = _authenticationUser.GenerateToken(
                    validatedResult.user.UserId,
                    validatedResult.userProfilesId,
                    validatedResult.user.UserName
                );

                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
